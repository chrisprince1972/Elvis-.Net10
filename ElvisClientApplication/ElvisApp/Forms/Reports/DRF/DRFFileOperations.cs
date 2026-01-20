using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using NLog;

namespace Elvis.Forms.Reports.DRF
{
    /// <summary>
    /// To wrap the complexity of io operations and impersonation.
    /// </summary>
    internal class DRFFileOperations
    {
        private bool AlreadyHasAttachments { get; set; }

        private bool Disposed { get; set; }

        private string DRFAttachmentPath { get; set; }

        private int DRFID { get; set; }

        private long DRFMaxFileSize { get; set; }

        private string DRFOperationDomainName { get; set; }

        private string DRFOperationPassword { get; set; }

        private string DRFOperationUserName { get; set; }

        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Constructor.
        /// throws
        /// </summary>
        /// <param name="alreadyHasAttachments">For efficiency reasons the database keeps track of if the DRF has any attachments.</param>
        /// <param name="drfIndex">To build to folder structure with.</param>
        public DRFFileOperations(bool alreadyHasAttachments, int drfIndex)
        {
            this.AlreadyHasAttachments = alreadyHasAttachments;
            this.Disposed = false;
            this.DRFAttachmentPath = Settings.Default.DRFFolderForAttachment;
            this.DRFID = drfIndex;
            this.DRFMaxFileSize = Settings.Default.DRFFileMaxSize;
            this.DRFOperationDomainName = Settings.Default.DRFFileOperationDomain;
            this.DRFOperationPassword = Settings.Default.DRFFileOperationUserPassword;
            this.DRFOperationUserName = Settings.Default.DRFFileOperationUserUserName;
        }

        /// <summary>
        /// Add file to DRF directory.
        /// </summary>
        /// <param name="filenameAndPath">File that needs to be added.</param>
        /// <returns>If the operation was a success.</returns>
        public bool Add(string filenameAndPath)
        {
            bool success = false;

            string pureFileName = System.IO.Path.GetFileName(filenameAndPath);
            string destinationFile = GetDRFFileAbsolutePath(pureFileName);

            using (Impersonate Impersionation = new Impersonate(DRFOperationDomainName, DRFOperationUserName, DRFOperationPassword))
            {
                if (!System.IO.Directory.Exists(GetDRFAbsoluteFolderPath()))
                {
                    if (this.AlreadyHasAttachments)
                    {
                        logger.Warn("DRFFileOperations::Add Created new directory even though the has attachment flag was set for {0}.", GetDRFAbsoluteFolderPath());
                    }

                    CreateDRFDirectory();
                }

                if (!this.AlreadyHasAttachments)
                {
                    ElvisDataModel.EntityHelper.DRFReport.SetHasAttachment(DRFID);
                    this.AlreadyHasAttachments = true;
                }
            }

            success = CopyFile(filenameAndPath, destinationFile);

            logger.Info("DRFFileOperations -- Add() -- Username: {0} -- Attachment: {1}.", WindowsIdentity.GetCurrent().Name, destinationFile);

            return success;
        }

        /// <summary>
        /// Get the list of files in the DRF attachment directory.
        /// </summary>
        /// <returns>List of files without their paths.</returns>
        public List<string> GetFileList()
        {
            List<string> fileList = new List<string>();
            if (this.AlreadyHasAttachments)
            {
                using (Impersonate Impersionation = new Impersonate(DRFOperationDomainName, DRFOperationUserName, DRFOperationPassword))
                {
                    string destinationFolder = GetDRFAbsoluteFolderPath();
                    if (System.IO.Directory.Exists(destinationFolder))
                    {
                        fileList = System.IO.Directory.GetFiles(destinationFolder).ToList();
                    }
                    else
                    {
                        //Uh oh, we shouldn't be here!
                        logger.Error("DRFFileOperations::GetFileList Did not create directory as one already exists. "
                                + "To get here the boolean flag HasAttachments must have been wrong.");
                    }
                }
            }
            return fileList;
        }

        /// <summary>
        /// Open's file using the default windows application.
        /// </summary>
        /// <param name="fileName">File name to open (without path).</param>
        public void Open(string fileName)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            string pathAndFileName = System.IO.Path.Combine(DRFAttachmentPath, DRFID.ToString(), fileName);
            process.StartInfo = new System.Diagnostics.ProcessStartInfo() { UseShellExecute = true, FileName = pathAndFileName };
            process.Start();
        }

        /// <summary>
        /// File to delete.
        /// </summary>
        /// <param name="fileName">File name to delete (without path).</param>
        public void Delete(string fileName)
        {
            using (Impersonate Impersionation = new Impersonate(DRFOperationDomainName, DRFOperationUserName, DRFOperationPassword))
            {
                System.IO.File.Delete(GetDRFFileAbsolutePath(fileName));
                if (GetFileList().Count < 1)
                {
                    this.AlreadyHasAttachments = false;
                    ElvisDataModel.EntityHelper.DRFReport.SetHasAttachment(DRFID, false);
                }
            }

            logger.Info("DRFFileOperations -- Delete() -- Username: {0} -- Attachment: {1}.", WindowsIdentity.GetCurrent().Name, GetDRFFileAbsolutePath(fileName));
        }

        #region Private Helper Functions.

        /// <summary>
        /// Copy from one file location to another.
        /// </summary>
        /// <param name="source">Location of the source file.</param>
        /// <param name="target">Location of the target file.</param>
        private bool CopyFile(string source, string target)
        {
            bool success = false;

            if (!System.IO.File.Exists(target))
            {
                FileInfo fileInfo = new FileInfo(source);

                if (fileInfo.Length < this.DRFMaxFileSize)
                {
                    // Copy from local directory under current user.
                    MemoryStream inMemoryCopy = new MemoryStream();
                    using (FileStream fs = File.OpenRead(source))
                    {
                        fs.CopyTo(inMemoryCopy);

                        using (Impersonate Impersionation = new Impersonate(DRFOperationDomainName, DRFOperationUserName, DRFOperationPassword))
                        {
                            using (FileStream fswrite = new FileStream(target, FileMode.Create, FileAccess.Write))
                            {
                                inMemoryCopy.WriteTo(fswrite);
                                success = true;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(
                        string.Format(
                            "Unable to add file. Max file size is {0:n0}MB.",
                            HelperFunctions.ConvertBytesToMegabytes(this.DRFMaxFileSize)),
                        "File Size Too Large",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
            }
            else
            {
                MessageBox.Show(
                    "File name already exists. Please rename file.",
                    "Duplicate File Name",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
            return success;
        }

        /// <summary>
        /// Creates a directory in a specific path.
        /// </summary>
        /// <param name="path">The path of the directory to create.</param>
        private void CreateDirectory(string path)
        {
            try
            {
                if (!System.IO.File.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                else
                {
                    //Uh oh, we shouldn't be here!
                    logger.Error("DRFFileOperations::CreateDirectory Did not create directory as one already exists. "
                            + "To get here the boolean flag HasAttachments must have been wrong.");
                }
            }
            catch (System.IO.IOException exIo)
            {
                logger.ErrorException(String.Format("DRFFileOperations::CreateDirectory Error Creating directory {0}. ", path), exIo);
            }
        }

        /// <summary>
        /// Creates a DRF directory.
        /// </summary>
        private void CreateDRFDirectory()
        {
            CreateDirectory(GetDRFAbsoluteFolderPath());
        }

        /// <summary>
        /// Returns the full path name of the DRF folder.
        /// </summary>
        /// <returns>Full path name of the folder.</returns>
        private string GetDRFAbsoluteFolderPath()
        {
            return System.IO.Path.Combine(DRFAttachmentPath, DRFID.ToString());
        }

        /// <summary>
        /// Returns the full path of the file including DRF folder.
        /// </summary>
        /// <returns>Full path name of the folder.</returns>
        private string GetDRFFileAbsolutePath(string filename)
        {
            return System.IO.Path.Combine(GetDRFAbsoluteFolderPath(), filename);
        }

        #endregion Private Helper Functions.
    }
}