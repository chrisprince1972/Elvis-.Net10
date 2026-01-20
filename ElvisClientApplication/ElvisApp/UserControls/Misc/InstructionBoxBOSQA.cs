using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Elvis.Properties;

namespace Elvis.UserControls.Misc
{
    public partial class InstructionBoxBOSQA : UserControl
    {
        /// <summary>
        /// Used for determining the height of the textbox text.
        /// </summary>
        private const int EM_GETLINECOUNT = 0xba;
        [DllImport("user32", EntryPoint = "SendMessageA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int SendMessage(int hwnd, int wMsg, int wParam, int lParam);

        public InstructionBoxBOSQA()
        {
            InitializeComponent();
            CustomiseColours();
        }

        /// <summary>
        /// Sets up the user control.
        /// </summary>
        /// <param name="unit">The Unit.</param>
        /// <param name="initialText">The initial instructions for that unit.</param>
        public void SetupUserControl(string unit, string initialText)
        {
            grpInstruction.Text = unit;
            txtInstruction.Text = initialText.Trim();
        }

        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                grpInstruction.BackColor =
                Settings.Default.ColourBackground;

            this.ForeColor =
                grpInstruction.ForeColor =
                Settings.Default.ColourText;
        }

        /// <summary>
        /// Adds additional text to the text box;
        /// </summary>
        /// <param name="additionalText">The text to add.</param>
        public void AddInstruction(string additionalText)
        {
            txtInstruction.Text += Environment.NewLine + additionalText.Trim();
        }

        /// <summary>
        /// Resizes the form so that the textbox fits it's contents without scrollbars.
        /// </summary>
        private void ResizeToFitText()
        {
            var numberOfLines = SendMessage(txtInstruction.Handle.ToInt32(), EM_GETLINECOUNT, 0, 0);
            this.Height = (txtInstruction.Font.Height + 2) * numberOfLines + 36;
        }

        /// <summary>
        /// Resize whenever the text is changed.
        /// </summary>
        private void txtInstruction_TextChanged(object sender, EventArgs e)
        {
            ResizeToFitText();
        }
    }
}
