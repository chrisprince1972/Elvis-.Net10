using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TapWatchPlayback
{
    public partial class BackgroundFileCopy : Form
    {
        private string tempFileName;
        private string inputFileName;
        private string outputFileName;
        private BackgroundWorker threadHeats;
        private BackgroundFileCopiedCallback callback;

        private Brush tataBrush = new SolidBrush(Color.FromArgb(0x3D, 0x7E, 0xDB));

        public delegate void BackgroundFileCopiedCallback(string fnam);

        public BackgroundFileCopy(string input, string output, BackgroundWorker thread)
        {
            InitializeComponent();
            inputFileName = input;
            outputFileName = output;
            tempFileName = Path.GetTempFileName();
            threadHeats = thread;
        }

        public BackgroundFileCopy(string input, string output, BackgroundFileCopiedCallback cb)
        {
            InitializeComponent();
            inputFileName = input;
            outputFileName = output;
            tempFileName = Path.GetTempFileName();
            callback = cb;
        }

        private void BackgroundFileCopy_Load(object sender, EventArgs e)
        {
            lblInputFileName.Text = "Copying " + inputFileName;
            lblOutputFileName.Text = "to " + outputFileName;
            threadCopy.RunWorkerAsync();
        }

        private void threadCopy_DoWork(object sender, DoWorkEventArgs e)
        {
            FileInfo file = new FileInfo(inputFileName);

            string fnam = outputFileName.ToLower();
            if (fnam.EndsWith(".twv")) CopyFile(file);
            else if (fnam.EndsWith(".csv")) CopyToCSV(file);
            else return;

            if (!threadCopy.CancellationPending)
            {
                File.SetCreationTime(tempFileName, file.CreationTime);
                File.SetLastWriteTime(tempFileName, file.LastWriteTime);
                File.SetAttributes(tempFileName, file.Attributes);
                if (File.Exists(outputFileName)) File.Delete(outputFileName);
                File.Move(tempFileName, outputFileName);
                if (threadHeats != null && threadHeats.IsBusy == false) threadHeats.RunWorkerAsync();
                if (callback != null) callback(outputFileName);
            }
            else
            {
                File.Delete(tempFileName);
            }

            try
            {
                BeginInvoke(new MethodInvoker(delegate { this.Close(); }));
            }
            catch { }
        }

        private void CopyFile(FileInfo file)
        {
            long bytesRead = 0;
            FileStream reader = new FileStream(inputFileName, FileMode.OpenOrCreate, FileAccess.Read);
            FileStream writer = new FileStream(tempFileName, FileMode.Create, FileAccess.ReadWrite);
            byte[] buffer = new byte[4*1024];

            for (;;)
            {
                if (threadCopy.CancellationPending) break;
                int len = reader.Read(buffer, 0, buffer.Length);
                if (len == 0) break;
                writer.Write(buffer, 0, len);
                bytesRead += len;

                ShowProgress((float)bytesRead/file.Length);
            }

            writer.Flush();
            writer.Close();
            reader.Close();
        }

        private void CopyToCSV(FileInfo file)
        {
            TWVReader twv = new TWVReader(inputFileName);
            StreamWriter writer = new StreamWriter(tempFileName);

            twv.ReadHeader();

            writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}",
                             "TIMESTAMP",
                             "SECONDS",
                             "PERCENT_STEEL",
                             "PERCENT_SLAG",
                             "ALARM",
                             "TILTER_ANGLE",
                             "TILTER_SPEED",
                             "NUM_PIXELS",
                             "MODE_PIXEL",
                             "MAX_PIXEL");

            for (int frame = 0; frame < twv.Header.FrameCount; frame++)
            {
                if (threadCopy.CancellationPending) break;
                twv.ReadFrame();

                float steelpct = 0;
                float slagpct = 0;
                float totpix = twv.Frame.SteelPixels + twv.Frame.SlagPixels;
                if (totpix > 0)
                {
                    steelpct = 100*twv.Frame.SteelPixels/totpix;
                    slagpct = 100*twv.Frame.SlagPixels/totpix;
                }

                int p = 0;
                int[] histoCount = new int[256];
                int pixMax=0, pixMode=0, pixModeCount=0;
                for (int pix=0; pix<histoCount.Length; pix++) histoCount[pix] = 0;
                for (int yy=0; yy<TWV.YPIX; yy++)
                {
                    for (int xx=0; xx<TWV.XPIX; xx++)
                    {
                        int pix = twv.Frame.Pixels[p++];
                        if (xx >= twv.Header.Left && xx <= twv.Header.Right && yy >= twv.Header.Top && yy <= twv.Header.Bottom)
                        {
                            histoCount[pix]++;
                        }
                    }
                }
                for (int pix=0; pix<histoCount.Length; pix++)
                {
                    if (histoCount[pix] > 0)
                    {
                        if (pix > pixMax) pixMax = pix;
                        if (pix > twv.Header.L1 && histoCount[pix] >= pixModeCount)
                        {
                            pixModeCount = histoCount[pix];
                            pixMode = pix;
                        }
                    }
                }

                writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}",
                                 twv.Frame.Timestamp.ToString("dd/MM/yyyy HH:mm:ss.ff"),
                                 (twv.Frame.Timestamp-twv.Header.StartTap).TotalSeconds,
                                 steelpct,
                                 slagpct,
                                 twv.Frame.Alarm,
                                 twv.Frame.Angle,
                                 twv.Frame.Speed,
                                 totpix,
                                 pixMode,
                                 pixMax);

                ShowProgress((float)frame / twv.Header.FrameCount);
            }

            writer.Flush();
            writer.Close();
            twv.Close();
        }

        private void ShowProgress(float frac)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gc = Graphics.FromImage(bmp);
            gc.Clear(Color.DarkGray);
            gc.FillRectangle(tataBrush, 0, 0, bmp.Width * frac, bmp.Height);
            gc.Dispose();
            BeginInvoke(new MethodInvoker(delegate { pictureBox1.Image = bmp; }));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            threadCopy.CancelAsync();
            this.Close();
        }

        private void BackgroundFileCopy_FormClosing(object sender, FormClosingEventArgs e)
        {
            threadCopy.CancelAsync();
            try
            {
                File.Delete(tempFileName);
            }
            catch { }
        }
    }
}