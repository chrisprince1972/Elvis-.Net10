using System.Drawing;
using System.Windows.Forms;

namespace Elvis.Common
{
    class FormControl
    {
        /// <summary>
        /// Method that displays a confirmation box to ensure no accidental
        /// closing of forms happens without saving
        /// </summary>
        /// <param name="formToClose">The Form you wish to close.</param>
        public static void ConfirmCloseForm(Form formToClose)
        {
            DialogResult result = MessageBox.Show(
                "All unsaved changes will be lost. Continue?",
                "Please Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                formToClose.DialogResult = DialogResult.OK;
                formToClose.Close();
            }
        }

        /// <summary>
        /// Method that displays a confirmation box to ensure no accidental
        /// deleting of records happen.
        /// </summary>
        /// <param name="nameOfDeleteObject">The Name of the thing you are deleting 
        /// (will be shown in the user message box).</param>
        public static bool ConfirmDeleteRecord(string nameOfDeleteObject)
        {
            DialogResult result = MessageBox.Show(
                string.Format(
                    "Are you sure you wish to delete this {0}? This process cannot be undone.", 
                    nameOfDeleteObject),
                "Delete Confirmation Required",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

            return result == DialogResult.Yes;
        }

        /// <summary>
        /// Method to find the parent form of the current control
        /// Will loop until found or find null
        /// </summary>
        /// <param name="parent">The Control to find parent of.</param>
        /// <returns>The Parent Form.</returns>
        public static Form FindParentForm(Control parent)
        {
            Form form = parent as Form;

            if (form != null)
                return form;
            else if (parent != null)
                return FindParentForm(parent.Parent);//Loop until form found
            else
                return null;
        }

        /// <summary>
        /// Copies the current screen to the clipboard as a bitmap.
        /// </summary>
        /// <returns>The bitmap saved to the clipboard.</returns>
        public static Bitmap CopyScreen()
        {
            Bitmap screenImage;
            SendKeys.SendWait("%{PRTSC}");
            screenImage = Clipboard.GetDataObject().GetData("Bitmap") as Bitmap;
            return screenImage;
        }

        /// <summary>
        /// Enables or Disables controls passed in based on 
        /// the parameters.  Also loops any child controls.
        /// </summary>
        /// <param name="value">True for Enable, false for Disable.</param>
        /// <param name="controls">The List of Controls to Check.</param>
        public static void EnableControls(bool value, Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                ctrl.Enabled = value;

                if (ctrl.Controls != null && ctrl.Controls.Count > 0)
                {
                    EnableControls(value, ctrl.Controls);
                }
            }
        }
    }
}
