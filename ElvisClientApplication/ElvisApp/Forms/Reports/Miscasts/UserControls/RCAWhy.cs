using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ElvisDataModel.EDMX;
using Elvis.Common;
using ElvisDataModel;
using NLog;

namespace Elvis.Forms.Reports.Miscasts.UserControls
{
    public partial class RCAWhy : UserControl
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private MiscastWhy why;

        /// <summary>
        /// Fires when a Miscast Investigation is Deleted.
        /// </summary>
        public delegate void MiscastWhyDeletedEventHandler(int deletedWhyID);

        public event MiscastWhyDeletedEventHandler MiscastWhyDeletedEvent;

        /// <summary>
        /// Fires when a Miscast Why is Changed.
        /// </summary>
        public delegate void MiscastWhyChangedEventHandler();

        public event MiscastWhyChangedEventHandler MiscastWhyChangedEvent;

        public int WhyID 
        {
            get { return this.why.WhyID; } 
        }

        public RCAWhy(MiscastWhy why, bool readOnly)
        {
            InitializeComponent();
            this.why = why;
            txtWhy.Text = this.why.WhyText;
            txtWhy.ReadOnly = readOnly;
            btnDelete.Enabled = !readOnly;
            btnDelete.Visible = !readOnly;

            if (this.why.SortNumber == 0)
                btnDelete.Visible = false;
        }

        private void txtWhy_TextChanged(object sender, EventArgs e)
        {
            this.why.WhyText = txtWhy.Text;
            if (this.MiscastWhyChangedEvent != null)
            {
                this.MiscastWhyChangedEvent();
            }
        }

        private void RCAWhy_Load(object sender, EventArgs e)
        {
            if (this.why != null)
            {
                txtWhy.Text = why.WhyText;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DeleteWhy();
            this.Cursor = Cursors.Default;
        }

        public void UpdateValues()
        {
            this.why.WhyText = txtWhy.Text;
        }

        private void DeleteWhy()
        {
            if (this.why != null &&
                FormControl.ConfirmDeleteRecord("Miscast Why"))
            {
                try
                {
                    EntityHelper.MiscastWhy.DeleteByID(this.why.WhyID);
                    if (this.MiscastWhyDeletedEvent != null)
                    {
                        this.MiscastWhyDeletedEvent(this.why.WhyID);
                    }
                }
                catch (Exception ex)
                {
                    logger.ErrorException(
                        "DATA ERROR -- DeleteWhy() -- Error Deleting Miscast Why -- ",
                        ex);
                    MessageBox.Show(
                        "Error Deleting Miscast Why!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
            }
        }
    }
}
