using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NLog;

namespace Elvis.Forms.General
{
    public partial class ReleaseNotes : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ReleaseNotes()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Populate the text box with notes.
        /// </summary>
        private void ReleaseNotes_Load(object sender, EventArgs e)
        {
            try
            {
                txtNotes.Text = File.ReadAllText("Elvis Release Notes.txt");
            }
            catch (Exception ex)
            {
                logger.ErrorException("ERROR -- Cannot open elvis release notes file! -- ", ex);
                MessageBox.Show(
                    "Error opening the Release Notes file.",
                    "File Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                this.Close();
            }
        }

        /// <summary>
        /// Close form on esc key press
        /// </summary>
        private void ReleaseNotes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Auto Scroll to bottom of textbox to show latest additions
        /// </summary>
        private void ReleaseNotes_Shown(object sender, EventArgs e)
        {
            txtNotes.SelectionStart = txtNotes.Text.Length;
            txtNotes.ScrollToCaret();
        }
    }
}
