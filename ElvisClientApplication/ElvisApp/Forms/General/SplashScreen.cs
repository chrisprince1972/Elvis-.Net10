using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Deployment.Application;
using System.Runtime.InteropServices;
using Elvis.Common;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using ElvisDataModel.EDMX;
namespace Elvis.Forms
{
    public partial class SplashScreen : Form
    {
        #region Variables and Attributes
        private MainForm main;

        //These are used for the moveable slash screen
        public const int WMNCLButtonDown = 0xA1;
        public const int HTCaption = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion

        #region Constructor
        public SplashScreen(MainForm mainForm)
        {
            this.main = mainForm;

            if (Debugger.IsAttached)
            {
                var asm = typeof(ElvisDataModel.EDMX.EventSchemaEntities).Assembly;

                // Show which DLL is actually being used at runtime
                MessageBox.Show(asm.Location, "ElvisDataModel.dll loaded from");

                // Show any embedded resources that mention ElvisEventSchema
                var names = asm.GetManifestResourceNames()
                               .Where(n => n.IndexOf("ElvisEventSchema", StringComparison.OrdinalIgnoreCase) >= 0)
                               .ToArray();

                MessageBox.Show(names.Length == 0 ? "NO ElvisEventSchema resources found"
                                                  : string.Join("\n", names),
                                "ElvisEventSchema embedded resources");
            }
        }



        #endregion

        #region Methods
        //Event to control the movement of the splash screen
        private void SplashScreen_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WMNCLButtonDown, HTCaption, 0);
            }
        }

        //Skips the Splash Screen for development
        private void btnSkip_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.main.SkipSplash = true;
            this.main.Show();
        }
        #endregion
    }
}
