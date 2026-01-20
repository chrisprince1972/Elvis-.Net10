using System;
using System.Drawing;
using System.Windows.Forms;
using Elvis.Properties;
using System.ComponentModel;

namespace Elvis.UserControls.Options
{
    public partial class OptionOEEReport : UserControl
    {
        #region Properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color L1BackColour { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color L1TextColour { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color L2BackColour { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color L2TextColour { get; set; }
        #endregion

        public OptionOEEReport()
        {
            InitializeComponent();
            SetupColourPanelsAndProperties();
        }

        private void SetupColourPanelsAndProperties()
        {
            pnlLevel1Back.BackColor = this.L1BackColour = Settings.Default.OEELevel1Background;
            pnlLevel1Text.BackColor = this.L1TextColour = Settings.Default.OEEL1Text;
            pnlLevel2Back.BackColor = this.L2BackColour = Settings.Default.OEELevel2Background;
            pnlLevel2Text.BackColor = this.L2TextColour = Settings.Default.OEEL2Text;
        }


        /// <summary>
        /// Sets a new colour setting when the user changes
        /// a value.
        /// </summary>
        /// <param name="name">The Name of the property to change.</param>
        /// <param name="colour">The colour to change it to.</param>
        private void SetNewColourSetting(string name, Color colour)
        {
            switch (name)
            {
                case "L1Back":
                    pnlLevel1Back.BackColor = this.L1BackColour = colour;
                    break;
                case "L1Text":
                    pnlLevel1Text.BackColor = this.L1TextColour = colour;
                    break;
                case "L2Back":
                    pnlLevel2Back.BackColor = this.L2BackColour = colour;
                    break;
                case "L2Text":
                    pnlLevel2Text.BackColor = this.L2TextColour = colour;
                    break;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Control ctrlClicked = (Control)sender;

            DialogResult result = colourPicker.ShowDialog();
            if (result == DialogResult.OK)
            {
                SetNewColourSetting(ctrlClicked.Tag.ToString(), colourPicker.Color);
            }
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            Button btnDefault = (Button)sender;

            switch (btnDefault.Tag.ToString())
            {
                case "L1Back":
                    pnlLevel1Back.BackColor = this.L1BackColour = Common.DefaultSettings.OEEL1Background;
                    break;
                case "L1Text":
                    pnlLevel1Text.BackColor = this.L1TextColour = Common.DefaultSettings.OEEL1Text;
                    break;
                case "L2Back":
                    pnlLevel2Back.BackColor = this.L2BackColour = Common.DefaultSettings.OEEL2Background;
                    break;
                case "L2Text":
                    pnlLevel2Text.BackColor = this.L2TextColour = Common.DefaultSettings.OEEL2Text;
                    break;
            }
        }

    }
}
