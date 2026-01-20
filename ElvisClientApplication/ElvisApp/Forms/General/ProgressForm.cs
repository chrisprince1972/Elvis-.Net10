using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Elvis.Forms
{
    public partial class ProgressForm : Form
    {
        private bool _allowUserAbort;
        private bool _userAborted;
        private int _counter;
        private static readonly int CancelVisibleWidth = 264;
        private static readonly int CancelHiddenWidth = 345;
        public static bool bDoCollect;

        public ProgressForm()
        {
            InitializeComponent();
            Text = "Progress";
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AllowUserAbort
        {
            get
            {
                return _allowUserAbort;
            }
            set
            {
                _allowUserAbort = value;
                cancelButton.Enabled = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool UserAborted
        {
            get { return _userAborted; }
            set { _userAborted = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CancelButtonText
        {
            get { return cancelButton.Text; }
            set { cancelButton.Text = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CancelButtonVisible
        {
            get { return cancelButton.Visible; }
            set
            {
                cancelButton.Visible = value;
                if (cancelButton.Visible)
                {
                    progressBar.Width = CancelVisibleWidth;
                }
                else
                {
                    progressBar.Width = CancelHiddenWidth;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long Maximum
        {
            get { return (long)progressBar.Maximum; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                progressBar.Maximum = (int)value;
                if (value == 0)
                {
                    progressBar.Visible = false;
                    progressLabel.Visible = false;
                }
                else
                {
                    progressBar.Visible = true;
                    progressLabel.Visible = true;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long Current
        {
            get { return (long)progressBar.Value; }
            set
            {
                if (Maximum != 0)
                {
                    try
                    {
                        progressBar.Value = (int)value;
                        string text = ((((double)value) / ((double)this.Maximum)) * 100).ToString("#0");
                        progressLabel.Text = text + "% complete";
                    }
                    catch (ArgumentException)
                    {
                    }
                    progressBar.Update();
                    DoEvents();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Description
        {
            get { return descriptionLabel.Text; }
            set
            {
                descriptionLabel.Text = value;
                descriptionLabel.Update();
                DoEvents();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Title
        {
            get { return Text; }
            set { Text = value; }
        }

        // Helpers
        private void Collect()
        {
            _counter++;
            if (_counter == 50)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                _counter = 0;
            }
        }

        private void DoEvents()
        {
            if (AllowUserAbort)
            {
                Application.DoEvents();
            }
            else if (bDoCollect)
            {
                Collect();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            UserAborted = true;
        }

        private void ProgressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Visible = false;
        }

        private void ProgressForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                UserAborted = false;
            }
        }
    }
}