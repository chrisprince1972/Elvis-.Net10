using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using NLog;
using System.ComponentModel;

namespace Elvis.Common
{
    public class PrintScreen : PrintDocument
    {
        #region Properties
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Bitmap ScreenImage { get; set; }
        #endregion

        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public PrintScreen()
        {
        }

        /// <summary>
        /// Override PrintDocument PrintPage method to allow for custom printing
        /// of captured screen image.
        /// </summary>
        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            Rectangle rectImage = new Rectangle();
            if (ScreenImage != null)
            {
                rectImage = new Rectangle(e.MarginBounds.X, e.MarginBounds.Y, Math.Min(ScreenImage.Width, e.MarginBounds.Width),
                    Math.Min(ScreenImage.Height, e.MarginBounds.Height));
                e.Graphics.DrawImage(ScreenImage, rectImage);
            }
            base.OnPrintPage(e);
        }
    }
}
