using System;
using System.ComponentModel;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using System.Drawing;

namespace Elvis.UserControls.Generic
{
    public class ElvisUserControl : UserControl
    {
        //Thread to do the work separately and call the overridden functions when completed.
        public BackgroundWorker worker = new BackgroundWorker();
        public string error = String.Empty;
        public Panel pnlMainBase = new Panel();
        private bool loadedEvents = false;
        protected NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Constructor.  Initialises the component and sets the object up.
        /// </summary>
        public ElvisUserControl()
        {
            this.Controls.Add(pnlMainBase);
        }


        /// <summary>
        /// The following 3 methods must be overridden.  The reason that we 
        /// did not use an abstract method is that we would not be able to 
        /// use the designer on subsequent objects.  As the next best solution
        /// we have decided to make them throw a un implemented exception if
        /// they are called.
        /// </summary>
        /// <returns>string of any error encountered during execution.</returns>
        protected virtual string GetData()
        {
            throw new NotImplementedException();
        }
        protected virtual void ShowMainPanel()
        {
            throw new NotImplementedException();
        }
        protected virtual void PopulateForm()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This hides the panel with the loading image on it by putting the 
        /// derived objects main panel over the top of it.
        /// </summary>
        /// <param name="main">The main panel.</param>
        protected void ShowMainPanel(Panel main)
        {
            this.Controls.Clear();
            this.Controls.Add(main);
            main.Visible = true;
            main.Dock = DockStyle.Fill;
            main.BringToFront();
            main.Refresh();
        }

        /// <summary>
        /// Shows an error screen if page has errored.
        /// </summary>
        private void ShowErrorForm()
        {
            CommonMethods.LoadImageIntoPanel(Resources.error, this, pnlMainBase);
        }

        /// <summary>
        /// Show image.
        /// </summary>
        protected void ShowImage(System.Drawing.Bitmap img)
        {
            CommonMethods.LoadImageIntoPanel(img, this, pnlMainBase);
        }


        /// <summary>
        /// Entry point of the object.  This is what the client code calls to put the values into the control.
        /// </summary>
        /// <param name="image">The image to show on loading.</param>
        public virtual void SetupUserControl(Bitmap image)
        {
            CommonMethods.LoadImageIntoPanel(image, this, pnlMainBase);
            this.SetupBackgroundWorker();

            if (!this.worker.IsBusy)
            {
                this.worker.RunWorkerAsync();
            }
        }

        #region thread events
        /// <summary>
        /// Sets up the background worker control to load data
        /// asynchronously
        /// </summary>
        private void SetupBackgroundWorker()
        {
            //Shove the DB access on a different thread to protect the UI.
            //Only add one set of worker events otherwise it will call the functions for each worker event thats added.
            if (!this.loadedEvents)
            {
                this.worker.DoWork += new DoWorkEventHandler(worker_DoWork);
                this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                this.worker.WorkerSupportsCancellation = true;
                this.loadedEvents = true;
            }
        }

        /// <summary>
        /// Background worker event to get the forms data.
        /// </summary>
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.error = GetData();
        }

        /// <summary>
        /// Background worker completed event.
        /// </summary>
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.error == String.Empty)
            {
                this.ShowMainPanel();
                this.PopulateForm();
            }
            else
            {
                this.ShowErrorForm();
            }
        }
        #endregion



    }
}
