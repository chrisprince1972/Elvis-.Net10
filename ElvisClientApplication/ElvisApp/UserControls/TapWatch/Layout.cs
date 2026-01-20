using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace TapWatchPlayback
{
    class Layout
    {
        internal BackgroundWorker playThread;
        internal BackgroundWorker graphThread;

        internal Color white = Color.White;

        Color boxColor = Color.DimGray;
        Color tata = Color.FromArgb(0x3D, 0x7E, 0xDB);

        const float minAngle = 240;
        const float maxAngle = 290;
        const float maxPix = 30000f;

        public Layout()
        {
            graphThread = new BackgroundWorker();
            graphThread.DoWork += new DoWorkEventHandler(graphThread_DoWork);
        }

        public class Text
        {
            public float X;
            public float Y;
            public float FontSize;
            public Color Color;
            public Font Font;
            public StringAlignment Alignment;
            public StringAlignment VerticalAlignment;
            public string String;

            public Text(float x, float y, float fontSize, Color color, StringAlignment align, StringAlignment valign)
            {
                this.X = x;
                this.Y = y;
                this.FontSize = fontSize;
                this.Color = color;
                this.Alignment = align;
                this.VerticalAlignment = valign;
                this.String = null;
                Font = new Font(FontFamily.GenericSansSerif, fontSize, FontStyle.Bold);
            }

            public Text(float x, float y, float fontSize, Color color, StringAlignment align, StringAlignment valign, string str)
            {
                this.X = x;
                this.Y = y;
                this.FontSize = fontSize;
                this.Color = color;
                this.Alignment = align;
                this.VerticalAlignment = valign;
                this.String = str;
                Font = new Font(FontFamily.GenericSansSerif, fontSize, FontStyle.Bold);
            }
        }

        public class Image
        {
            public float X;
            public float Y;
            public float Width;
            public float Height;
            public Image(float x, float y, float width, float height)
            {
                this.X = x;
                this.Y = y;
                this.Width = width;
                this.Height = height;
            }
        }

        public int Width;
        public int Height;
        public Color Color;
        public Image Video;
        public Text Heat;
        public Text Vessel;
        public Text Time;
        public Text Steel;
        public Text Slag;
        public Text Stream;
        public Text Dart;
        public Text Angle;
        public Text Speed;
        public Text SlagPct;
        public Text Chrono;
        public Image SteelSlagBar;
        public Image SteelSlagGraph;
        public Image StreamGraph;
        public Image Cursor;
        public Image StreamBar;
        public Image VesselAngle;
        public Image TilterSpeed;
        public Image SlagPie;
        public Image Histo;
        public Text SteelSlagLegend;
        public Text StreamLegend;
        public Image Analyses;
        public Image Additions;
        public Image Temps;
        public Image CBM;
        public Text StopWatch;
        public int NumAnalysisFields = 21;
        public float TableFontSize = 8;

        /*====================================================================================================
         * 
         * PixelsToImage()
         * 
         * Converts a two-dimensional pixel array into a bitmap, which is stretched onto part of a blank
         * canvas.
         */

        public Bitmap PixelsToImage(TWVReader twv, float slagCarry, int tmax, float exposure, Bitmap banner, Bitmap steelSlagGraph, Bitmap streamGraph, Bitmap histoGraph, Bitmap gradientBitmap, Bitmap analsTable, Bitmap addsTable, Bitmap tempsTable, Bitmap cbmTable)
        {
            bool underExposed = exposure < Config.ExposureThreshold;
            int steelpix = !underExposed ? twv.Frame.SteelPixels : 0;
            int slagpix = !underExposed ? twv.Frame.SlagPixels : 0;

            Color red = Color.Red;
            Color orange = Color.FromArgb(66, 40, 16);
            Color yellow = Color.Yellow;
            Color cumured = Color.DarkRed;

            Brush topend = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.Goldenrod);

            /*
             * Convert the pixel array to a 178x120 pixel bitmap, and tally up histogram data.
             */

            float histoMax = 0;
            int[] histoCount = new int[256];
            Bitmap sourceBitmap = new Bitmap(TWV.XPIX, TWV.YPIX);
            BitmapData bData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int p = 0;
            for (int y = 0; y < TWV.YPIX; y++)
            {
                for (int x = 0; x < TWV.XPIX; x++)
                {
                    int pix = twv.Frame.Pixels[p++];
                    SetPixel(bData, x, y, Forms.colorMap.Colors[pix]);
                    if (x >= twv.Header.Left && x <= twv.Header.Right && y >= twv.Header.Top && y <= twv.Header.Bottom)
                    {
                        histoCount[pix]++;
                        if (histoCount[pix] > histoMax) histoMax = histoCount[pix];
                        if (underExposed)
                        {
                            if (pix > Forms.colorMap.L2) slagpix++;
                            else if (pix > Forms.colorMap.L1) steelpix++;
                        }
                    }
                }
            }
            for (int x = twv.Header.Left; x <= twv.Header.Right; x++)
            {
                SetPixel(bData, x, twv.Header.Top, boxColor);
                SetPixel(bData, x, twv.Header.Bottom, boxColor);
            }
            for (int y = twv.Header.Top; y <= twv.Header.Bottom; y++)
            {
                SetPixel(bData, twv.Header.Left, y, boxColor);
                SetPixel(bData, twv.Header.Right, y, boxColor);
            }
            sourceBitmap.UnlockBits(bData);

            /*
             * Create a bigger canvas bitmap.
             */

            Bitmap largeBitmap = new Bitmap(this.Width, this.Height);

            {
                float len;
                float totpix = steelpix + slagpix;

                Graphics gc = Graphics.FromImage(largeBitmap);
                gc.SmoothingMode = SmoothingMode.AntiAlias;
                gc.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var sf = StringFormat.GenericTypographic.Clone() as StringFormat;

                /*
                 * Clear the background, or colour it red/orange.
                 */

                int yellowWarning = 5; // same as slagWarningThreshold
                if (twv.Frame.Alarm) gc.Clear(red);
                else if (twv.Header.CumulativeAlarm > 0 && twv.Frame.Timestamp >= twv.Header.StartTap.AddMinutes(twv.Header.CumulativeAlarm)) gc.Clear(cumured);
                else if (totpix > 0 && 100 * (slagpix / totpix) > twv.Header.Orange) gc.Clear(orange);
                else if (totpix > 0 && 100 * (slagpix / totpix) > yellowWarning) gc.Clear(yellow);
                else gc.Clear(this.Color);

                /*
                 * Paste the video onto the canvas.
                 */

                gc.DrawImage(sourceBitmap, Video.X, Video.Y, Video.Width, Video.Height);

                /*
                 * Add the steel/slag bar.
                 */

                if (SteelSlagBar != null)
                {
                    if (totpix > 0)
                    {
                        len = this.SteelSlagBar.Height * slagpix / totpix;
                        gc.FillRectangle(Brushes.DimGray, SteelSlagBar.X, SteelSlagBar.Y, SteelSlagBar.Width, SteelSlagBar.Height);
                        gc.FillRectangle(Brushes.Red, SteelSlagBar.X, SteelSlagBar.Y + SteelSlagBar.Height - len, SteelSlagBar.Width, len);
                    }
                }

                string steelpct = "0%";
                string slagpct = "0%";
                if (totpix > 0)
                {
                    steelpct = (100 * steelpix / totpix).ToString("#0.0") + "%";
                    slagpct = (100 * slagpix / totpix).ToString("#0.0") + "%";
                }

                if (Steel != null)
                {
                    sf.Alignment = Steel.Alignment;
                    sf.LineAlignment = Steel.VerticalAlignment;
                    gc.DrawString(steelpct,
                                  Steel.Font,
                                  new SolidBrush(Steel.Color),
                                  Steel.X,
                                  Steel.Y,
                                  sf);
                }

                if (Slag != null)
                {
                    sf.Alignment = Slag.Alignment;
                    sf.LineAlignment = Slag.VerticalAlignment;
                    gc.DrawString(slagpct,
                                  Slag.Font,
                                  new SolidBrush(Slag.Color),
                                  Slag.X,
                                  Slag.Y,
                                  sf);
                }

                /*
                 * A smaller bar for the stream width.
                 */

                if (StreamBar != null)
                {
                    len = StreamBar.Height * (twv.Frame.SteelPixels + twv.Frame.SlagPixels) / maxPix;
                    gc.FillRectangle(new SolidBrush(Color.FromArgb(0x22, 0x22, 0x22)), StreamBar.X, StreamBar.Y, StreamBar.Width, StreamBar.Height);
                    gc.FillRectangle(Brushes.DimGray, StreamBar.X, StreamBar.Y + StreamBar.Height - len, StreamBar.Width, len);
                    sf.Alignment = Stream.Alignment;
                    sf.LineAlignment = Stream.VerticalAlignment;
                }

                if (Stream != null)
                {
                    gc.DrawString((twv.Frame.SteelPixels + twv.Frame.SlagPixels).ToString(),
                                  Stream.Font,
                                  new SolidBrush(Stream.Color),
                                  Stream.X,
                                  Stream.Y,
                                  sf);
                }

                /*
                 * Slag pie.
                 */

                if (SlagPie != null)
                {
                    gc.FillEllipse(Brushes.Gray, SlagPie.X, SlagPie.Y, SlagPie.Width, SlagPie.Height);
                    gc.FillPie(Brushes.Red, SlagPie.X, SlagPie.Y, SlagPie.Width, SlagPie.Height, -90, (float)(slagCarry * 360));
                }

                if (SlagPct != null)
                {
                    sf.Alignment = SlagPct.Alignment;
                    sf.LineAlignment = SlagPct.VerticalAlignment;
                    gc.DrawString((slagCarry * 100).ToString("#0.0") + "%",
                                   SlagPct.Font,
                                   new SolidBrush(SlagPct.Color),
                                   SlagPct.X,
                                   SlagPct.Y,
                                   sf);
                }

                /*
                 * Dart in.
                 */

                if (Dart != null && twv.Header.DartRelease > 0)
                {
                    Brush brush;
                    if (twv.Frame.Timestamp > twv.Header.StartTap.AddMinutes(twv.Header.DartRelease)) brush = Brushes.Yellow;
                    else brush = Brushes.Gray;
                    sf.Alignment = Dart.Alignment;
                    sf.LineAlignment = Dart.VerticalAlignment;
                    gc.DrawString(Dart.String, Dart.Font, brush, Dart.X, Dart.Y, sf);
                }
                else
                {
                    Brush brush = Brushes.Gray;
                    sf.Alignment = Dart.Alignment;
                    sf.LineAlignment = Dart.VerticalAlignment;
                    gc.DrawString("No Dart", Dart.Font, brush, Dart.X, Dart.Y, sf);
                }
                /*
                 * Rotating vessel to show the tilter angle.
                 */

                if (VesselAngle != null)
                {
                    gc.DrawImage(RotateImage(global::Elvis.UserControls.TapWatch.Properties.TapWatchResources.vesselzero, twv.Frame.Angle), VesselAngle.X, VesselAngle.Y);
                }
                if (Angle != null)
                {
                    sf.Alignment = Angle.Alignment;
                    sf.LineAlignment = Angle.VerticalAlignment;
                    gc.DrawString(twv.Frame.Angle.ToString("#0") + "°", Angle.Font, new SolidBrush(Angle.Color), Angle.X, Angle.Y, sf);
                }

                /*
                 * Speed gauge.
                 */

                if (TilterSpeed != null)
                {
                    const float minSpeed = -900f;
                    const float maxSpeed = 900f;
                    const float sweep = 270f;
                    float speedAngle = sweep * (twv.Frame.Speed - minSpeed) / (maxSpeed - minSpeed);
                    gc.DrawImage(RotateImage(global::Elvis.UserControls.TapWatch.Properties.TapWatchResources.speed64_face, 0), TilterSpeed.X, TilterSpeed.Y);
                    gc.DrawImage(RotateImage(global::Elvis.UserControls.TapWatch.Properties.TapWatchResources.speed64_needle, speedAngle), TilterSpeed.X, TilterSpeed.Y);
                }

                if (Speed != null)
                {
                    sf.Alignment = Speed.Alignment;
                    sf.LineAlignment = Speed.VerticalAlignment;
                    gc.DrawString(twv.Frame.Speed.ToString("#0") + "rpm", Speed.Font, new SolidBrush(Speed.Color), Speed.X, Speed.Y, sf);
                }

                /*
                 * Histogram for pixel distribution.
                 */

                if (Histo != null)
                {
                    var colors = Forms.colorMap.Colors.Clone() as Color[];

                    // Background
                    gc.FillRectangle(new SolidBrush(Color), Histo.X - 1, Histo.Y, Histo.Width + 1, Histo.Height + 1);

                    // Max/mode graph
                    lock (histoGraph)
                    {
                        gc.DrawImage(histoGraph, Histo.X, Histo.Y);
                    }

                    // Histogram proper, gradient, hatch marks
                    gc.SmoothingMode = SmoothingMode.None;
                    float bot = Histo.Y + Histo.Height;
                    float step = Histo.Width / 256f;
                    float x = Histo.X;
                    for (int pix = 0; pix < colors.Length; pix++)
                    {
                        float h = Histo.Height * histoCount[pix] / (0.30f * histoMax);
                        if (h > Histo.Height) h = Histo.Height;
                        gc.FillRectangle(new SolidBrush(colors[pix]), x, bot - h, step, h);
                        x += step;
                    }
                    Pen pen = new Pen(Color.Maroon);
                    pen.DashStyle = DashStyle.Dash;
                    pen.Color = Forms.colorMap.Colors[((int)Forms.colorMap.L1 + Forms.colorMap.L2) / 2]; gc.DrawLine(pen, Histo.X + Histo.Width * Forms.colorMap.L1 / 256f, Histo.Y, Histo.X + Histo.Width * Forms.colorMap.L1 / 256f, Histo.Y + Histo.Height);
                    if (Forms.colorMap.L2 < 255) pen.Color = Forms.colorMap.Colors[Forms.colorMap.L2 + 1]; gc.DrawLine(pen, Histo.X + Histo.Width * Forms.colorMap.L2 / 256f, Histo.Y, Histo.X + Histo.Width * Forms.colorMap.L2 / 256f, Histo.Y + Histo.Height);
                    if (histoMax == 0) histoMax = 1;
                    gc.DrawImage(gradientBitmap, Histo.X, Histo.Y);
                    gc.FillRectangle(topend, Histo.X + Histo.Width * tmax / 256f, Histo.Y + Histo.Height * 0.95f, Histo.Width * (256 - tmax) / 256f, Histo.Height * 0.05f);
                    gc.SmoothingMode = SmoothingMode.AntiAlias;

                    // Secondary cursor
                    float xx = (float)(Histo.Width * (twv.Frame.Timestamp - twv.Header.StartTap).TotalSeconds / twv.TotalSeconds);
                    gc.DrawLine(Pens.White, Histo.X + xx, Histo.Y, Histo.X + xx, Histo.Y + Histo.Height);
                }

                /*
                 * Chrono: minutes, seconds from start tap.
                 */

                if (Chrono != null)
                {
                    sf.Alignment = Chrono.Alignment;
                    sf.LineAlignment = Chrono.VerticalAlignment;
                    if (twv.Frame.Timestamp > twv.Header.StartTap)
                    {
                        TimeSpan elapsed = twv.Frame.Timestamp - twv.Header.StartTap;
                        string cron = elapsed.ToString();
                        if (cron.Length >= 11) cron = cron.Substring(3, 8);
                        gc.DrawString(cron,
                                      Chrono.Font,
                                      new SolidBrush(Chrono.Color),
                                      Chrono.X,
                                      Chrono.Y,
                                      sf);
                    }
                }

                /*
                 * Add the static parts: banner.
                 */

                if (banner != null) gc.DrawImage(banner, 0, 0);

                /*
                 * Steel/slag graph.
                 */

                if (steelSlagGraph != null && SteelSlagGraph != null)
                {
                    lock (steelSlagGraph)
                    {
                        gc.DrawImage(steelSlagGraph, SteelSlagGraph.X, SteelSlagGraph.Y);
                    }
                    sf.Alignment = SteelSlagLegend.Alignment;
                    sf.LineAlignment = SteelSlagLegend.VerticalAlignment;
                    gc.DrawString(SteelSlagLegend.String, SteelSlagLegend.Font, new SolidBrush(SteelSlagLegend.Color), SteelSlagLegend.X, SteelSlagLegend.Y, sf);
                }

                /*
                 * Stream width graph.
                 */

                if (streamGraph != null && StreamGraph != null)
                {
                    lock (streamGraph)
                    {
                        gc.DrawImage(streamGraph, StreamGraph.X, StreamGraph.Y);
                    }
                    sf.Alignment = StreamLegend.Alignment;
                    sf.LineAlignment = StreamLegend.VerticalAlignment;
                    gc.DrawString(StreamLegend.String, StreamLegend.Font, new SolidBrush(StreamLegend.Color), StreamLegend.X, StreamLegend.Y, sf);
                }

                /*
                 * Cursor.
                 */

                if (Cursor != null)
                {
                    float xx = (float)(Cursor.Width * (twv.Frame.Timestamp - twv.Header.StartTap).TotalSeconds / twv.TotalSeconds);
                    gc.DrawLine(Pens.White, Cursor.X + xx, Cursor.Y, Cursor.X + xx, Cursor.Y + Cursor.Height);
                }

                /*
                 * Tables of Rdb data.
                 */

                if (analsTable != null && Analyses != null) gc.DrawImage(analsTable, Analyses.X, Analyses.Y);
                if (addsTable != null && Additions != null) gc.DrawImage(addsTable, Additions.X, Additions.Y);
                if (tempsTable != null && Temps != null) gc.DrawImage(tempsTable, Temps.X, Temps.Y);
                if (cbmTable != null && CBM != null) gc.DrawImage(cbmTable, CBM.X, CBM.Y);

                gc.Dispose();
            }

            return largeBitmap;
        }

        /*====================================================================================================
         * 
         * BannerImage()
         * 
         * Create a blue ribbon for the top of the window, with a Tata logo and heat information as a title.
         */

        public Bitmap BannerImage(TWVReader twv)
        {
            Bitmap bmp = new Bitmap(Width, 29);
            Graphics gc = Graphics.FromImage(bmp);
            var sf = StringFormat.GenericTypographic.Clone() as StringFormat;

            /*
             * Blue ribbon and logo.
             */

            gc.FillRectangle(new SolidBrush(tata), 0, 0, Width, bmp.Height);
            //gc.DrawImage(global::Elvis.UserControls.TapWatch.Properties.TapWatchResources.logo, Width - bmp.Height, 0, bmp.Height, bmp.Height);

            if (twv != null)
            {
                string bang = "";
                /*
                 * Heat number.
                 */

                string desc = Path.GetFileNameWithoutExtension(twv.FileName);
                if (desc == twv.Header.HeatNumber.ToString()) desc = "";

                sf.Alignment = Heat.Alignment;
                sf.LineAlignment = Heat.VerticalAlignment;
                bang = "Heat " + twv.Header.HeatNumber + "  " + desc + "  ";
                gc.DrawString(bang, Heat.Font, new SolidBrush(Heat.Color), Heat.X, Heat.Y, sf);

                /*
                 * Vessel number, start tap and runout time.
                 */

                sf.Alignment = Time.Alignment;
                sf.LineAlignment = Time.VerticalAlignment;
                TimeSpan duration = twv.Header.EndTap - twv.Header.StartTap;

                bang = "";
                bang += "Vessel " + twv.Header.VesselNumber + "   ";
                bang += twv.Header.StartTap.ToString("dd-MMM-yyyy HH:mm") + " +" + duration.ToString().Substring(3, 5);
                if (twv.Header.PredictedROT > 0)
                {
                    TimeSpan span = TimeSpan.FromMinutes(twv.Header.PredictedROT);
                    bang += "  (pred " + span.Minutes.ToString("#00") + ":" + span.Seconds.ToString("#00") + ")";
                }
                gc.DrawString(bang, Time.Font, new SolidBrush(Time.Color), Time.X, Time.Y, sf);
            }

            return bmp;
        }

        /*====================================================================================================
         * 
         * FormatAdditions()
         * 
         * Create a bitmap with the standard and model additions nicely laid out in a table.
         */

        public Bitmap FormatAdditions(TWVReader twv)
        {
            Bitmap bmp = new Bitmap((int)Additions.Width, (int)Additions.Height);
            Graphics gc = Graphics.FromImage(bmp);
            Font font = new Font(FontFamily.GenericSansSerif, TableFontSize, FontStyle.Bold);
            float labelWidth = 15 * TableFontSize;
            float columnWidth = 4.5f * TableFontSize;
            float lineSpacing = TableFontSize + (5f / 8f) * TableFontSize;
            Brush brush = Brushes.Yellow;

            var sf = StringFormat.GenericDefault.Clone() as StringFormat;
            sf.LineAlignment = StringAlignment.Near;
            sf.Alignment = StringAlignment.Far;

            float y = 2;
            gc.DrawString("Required additions:", font, brush, 0, y); y += lineSpacing;
            gc.DrawString("Standard", font, brush, labelWidth, y, sf); gc.DrawString("Model", font, brush, labelWidth + columnWidth, y, sf); y += lineSpacing;
            for (int i = 0; i < TWV.MAXADDS; i++)
            {
                string lbl = twv.Header.Adds[i].Material.Trim();
                if (lbl == "") continue;
                gc.DrawString(lbl, font, brush, 0, y);
                if (twv.Header.Adds[i].Standard > 0) gc.DrawString(twv.Header.Adds[i].Standard.ToString("#0"), font, brush, labelWidth, y, sf);
                if (twv.Header.Adds[i].Model > 0) gc.DrawString(twv.Header.Adds[i].Model.ToString("#0"), font, brush, labelWidth + columnWidth, y, sf);
                y += lineSpacing;
            }

            return bmp;
        }

        /*====================================================================================================
         * 
         * FormatTempsMisc()
         * 
         * Create a bitmap with the temperatures and miscellaneous data nicely laid out in a table.
         */

        public Bitmap FormatTempsMisc(TWVReader twv)
        {
            Bitmap bmp = new Bitmap((int)Temps.Width, (int)Temps.Height);
            Graphics gc = Graphics.FromImage(bmp);
            Font font = new Font(FontFamily.GenericSansSerif, TableFontSize, FontStyle.Bold);
            float labelWidth = 10 * TableFontSize;
            float columnWidth = 6 * TableFontSize;
            float lineSpacing = TableFontSize + (5f / 8f) * TableFontSize;
            Brush brush = Brushes.White;

            float y = 2;
            gc.DrawString("Temps/Misc:", font, brush, 0, y); y += lineSpacing;
            gc.DrawString("1", font, brush, labelWidth, y); gc.DrawString("2", font, brush, labelWidth + columnWidth, y); y += lineSpacing;

            if (twv.Header.Ebm.LadleAimTemperature > 0)
            {
                gc.DrawString("Ladle aim", font, brush, 0, y);
                gc.DrawString(twv.Header.Ebm.LadleAimTemperature.ToString(), font, brush, labelWidth, y);
                y += lineSpacing;
            }

            if (twv.Header.Ebm.InBlowTemperature > 0)
            {
                gc.DrawString("In blow", font, brush, 0, y);
                gc.DrawString(twv.Header.Ebm.InBlowTemperature.ToString(), font, brush, labelWidth, y);
                y += lineSpacing;
            }

            if (twv.Header.Ebm.Pb1Temperature > 0 || twv.Header.Ebm.Pb2Temperature > 0)
            {
                gc.DrawString("PB Temp", font, brush, 0, y);
                if (twv.Header.Ebm.Pb1Temperature > 0)
                    gc.DrawString(twv.Header.Ebm.Pb1Temperature + " " + twv.Header.Ebm.Pb1TemperatureQc, font, brush, labelWidth, y);
                if (twv.Header.Ebm.Pb2Temperature > 0)
                    gc.DrawString(twv.Header.Ebm.Pb2Temperature + " " + twv.Header.Ebm.Pb2TemperatureQc, font, brush, labelWidth + columnWidth, y);
                y += lineSpacing;
            }

            if (twv.Header.Ebm.Pb1CalculatedCarbon > 0 || twv.Header.Ebm.Pb2CalculatedCarbon > 0)
            {
                gc.DrawString("PB Calc C", font, brush, 0, y);
                if (twv.Header.Ebm.Pb1CalculatedCarbon > 0)
                    gc.DrawString(twv.Header.Ebm.Pb1CalculatedCarbon.ToString("#0.0000"), font, brush, labelWidth, y);
                if (twv.Header.Ebm.Pb2CalculatedCarbon > 0)
                    gc.DrawString(twv.Header.Ebm.Pb2CalculatedCarbon.ToString("#0.0000"), font, brush, labelWidth + columnWidth, y);
                y += lineSpacing;
            }

            if (twv.Header.Ebm.Pb1OxyActivity > 0 || twv.Header.Ebm.Pb2OxyActivity > 0)
            {
                gc.DrawString("PB Oxy Act", font, brush, 0, y);
                if (twv.Header.Ebm.Pb1OxyActivity > 0)
                    gc.DrawString(twv.Header.Ebm.Pb1OxyActivity + " " + twv.Header.Ebm.Pb1OxyActivityQc, font, brush, labelWidth, y);
                if (twv.Header.Ebm.Pb2OxyActivity > 0)
                    gc.DrawString(twv.Header.Ebm.Pb2OxyActivity + " " + twv.Header.Ebm.Pb2OxyActivityQc, font, brush, labelWidth + columnWidth, y);
                y += lineSpacing;
            }

            if (twv.Header.Ebm.EstPbCarbon > 0)
            {
                gc.DrawString("Est PB C", font, brush, 0, y);
                gc.DrawString(twv.Header.Ebm.EstPbCarbon.ToString("#0.0000"), font, brush, labelWidth, y);
                y += lineSpacing;
            }

            if (twv.Header.Ebm.EstOxyActivity > 0)
            {
                gc.DrawString("Est Oxy Act", font, brush, 0, y);
                gc.DrawString(twv.Header.Ebm.EstOxyActivity.ToString(), font, brush, labelWidth, y);
                y += lineSpacing;
            }

            if (twv.Header.Coord.Grade1 > 0 || twv.Header.Coord.Grade2 > 0)
            {
                gc.DrawString("Grade", font, brush, 0, y);
                if (twv.Header.Coord.Grade1 > 0)
                    gc.DrawString(twv.Header.Coord.Grade1.ToString(), font, brush, labelWidth, y);
                if (twv.Header.Coord.Grade2 > 0)
                    gc.DrawString(twv.Header.Coord.Grade2.ToString(), font, brush, labelWidth + columnWidth, y);
                y += lineSpacing;
            }

            return bmp;
        }

        /*====================================================================================================
         * 
         * FormatCBM()
         * 
         * Create a bitmap with the CBM data laid out in a table.
         */

        public Bitmap FormatCBM(TWVReader twv)
        {
            Bitmap bmp = new Bitmap((int)Analyses.Width, (int)Analyses.Height);

            if (twv.Header.Version >= TWV.VersionWithCBM)
            {
                Graphics gc = Graphics.FromImage(bmp);
                Font font = new Font(FontFamily.GenericSansSerif, TableFontSize, FontStyle.Bold);
                Brush brush = Brushes.MediumOrchid;
                float labelWidth = 7f * TableFontSize;
                float lineSpacing = TableFontSize + (5f / 8f) * TableFontSize;
                float x, y;

                x = 2;
                y = 2;
                gc.DrawString("Slag bulk", font, brush, x, y); x += labelWidth;
                gc.DrawString(twv.Header.Cbm.CbmPredictedSlagWeight.ToString("0.0"), font, brush, x, y);
                y += lineSpacing;

                x = 2;
                gc.DrawString("Tap Wt", font, brush, x, y); x += labelWidth;
                gc.DrawString(twv.Header.Cbm.CbmPredictedTapWeight.ToString("0.0"), font, brush, x, y);
                y += lineSpacing;
            }

            return bmp;
        }

        /*====================================================================================================
         * 
         * FormatAnalyses()
         * 
         * Create a bitmap with the analyses laid out in a table.
         */

        public Bitmap FormatAnalyses(TWVReader twv)
        {
            Bitmap bmp = new Bitmap((int)Analyses.Width, (int)Analyses.Height);
            Graphics gc = Graphics.FromImage(bmp);
            Font font = new Font(FontFamily.GenericSansSerif, TableFontSize, FontStyle.Bold);
            float labelWidth = 10 * TableFontSize;
            float columnWidth = 4.5f * TableFontSize;
            float lineSpacing = TableFontSize + (5f / 8f) * TableFontSize;
            float x, y;

            /*
             * Draw header.
             */

            string[] heads = { "C", 
                               "Si", 
                               "S", 
                               "P", 
                               "Mn", 
                               "Ni", 
                               "Cu", 
                               "Sn", 
                               "Cr", 
                               "As", 
                               "Mo", 
                               "N2", 
                               "Al-T", 
                               "Al-S", 
                               "Ti", 
                               "B", 
                               "Ca", 
                               "Ce", 
                               "Co", 
                               "Nb", 
                               "V" };

            {
                x = 2;
                y = 2;
                gc.DrawString("Heat " + twv.Header.HeatNumber, font, Brushes.Red, x, y); x += labelWidth;
                for (int v = 0; v < NumAnalysisFields; v++)
                {
                    string head = heads[v];
                    gc.DrawString(head, font, Brushes.White, x, y); x += columnWidth;
                    if (head == "C" || head == "N2" || head == "B" || head == "Ca") x += 0.75f * TableFontSize;
                }
            }

            /*
             * Record zero contains the max aims. We'll be using these to show high values with a red
             * background.
             */

            float[] max = { twv.Header.Anals[0].C,
                            twv.Header.Anals[0].Si,
                            twv.Header.Anals[0].S,
                            twv.Header.Anals[0].P,
                            twv.Header.Anals[0].Mn,
                            twv.Header.Anals[0].Ni,
                            twv.Header.Anals[0].Cu,
                            twv.Header.Anals[0].Sn,
                            twv.Header.Anals[0].Cr,
                            twv.Header.Anals[0].Ars,
                            twv.Header.Anals[0].Mo,
                            twv.Header.Anals[0].N2,
                            twv.Header.Anals[0].AlT,
                            twv.Header.Anals[0].AlS,
                            twv.Header.Anals[0].Ti,
                            twv.Header.Anals[0].B,
                            twv.Header.Anals[0].Ca,
                            twv.Header.Anals[0].Ce,
                            twv.Header.Anals[0].Co,
                            twv.Header.Anals[0].Nb,
                            twv.Header.Anals[0].V};

            /*
             * Foreach analysis.
             */

            for (int i = 0; i < TWV.MAXANAL; i++)
            {
                string lbl = twv.Header.Anals[i].Lbl.Trim();
                if (lbl == "") continue;
                x = 2;
                y += lineSpacing;
                gc.DrawString(lbl, font, Brushes.White, x, y); x += labelWidth;

                /*
                 * This analysis.
                 */

                float[] vals = { twv.Header.Anals[i].C,
                                 twv.Header.Anals[i].Si,
                                 twv.Header.Anals[i].S,
                                 twv.Header.Anals[i].P,
                                 twv.Header.Anals[i].Mn,
                                 twv.Header.Anals[i].Ni,
                                 twv.Header.Anals[i].Cu,
                                 twv.Header.Anals[i].Sn,
                                 twv.Header.Anals[i].Cr,
                                 twv.Header.Anals[i].Ars,
                                 twv.Header.Anals[i].Mo,
                                 twv.Header.Anals[i].N2,
                                 twv.Header.Anals[i].AlT,
                                 twv.Header.Anals[i].AlS,
                                 twv.Header.Anals[i].Ti,
                                 twv.Header.Anals[i].B,
                                 twv.Header.Anals[i].Ca,
                                 twv.Header.Anals[i].Ce,
                                 twv.Header.Anals[i].Co,
                                 twv.Header.Anals[i].Nb,
                                 twv.Header.Anals[i].V};

                /*
                 * Show values in appropriate colour. Min/max in yellow, aim in white, the rest in green/red.
                 */

                for (int v = 0; v < NumAnalysisFields; v++)
                {
                    int dp = heads[v] == "C" || heads[v] == "N2" || heads[v] == "B" || heads[v] == "Ca" ? 4 : 3;
                    if (vals[v] > 0)
                    {
                        Brush brush = Brushes.Lime;
                        if (lbl == "Min" || lbl == "Max") brush = Brushes.Yellow;
                        else if (lbl == "Aim") brush = Brushes.White;
                        else if (max[v] > 0 && vals[v] > max[v])
                        {
                            gc.FillRectangle(Brushes.Red, x, y, dp == 3 ? columnWidth : columnWidth + 0.75f * TableFontSize, lineSpacing);
                            brush = Brushes.White;
                        }
                        gc.DrawString(vals[v].ToString(dp == 3 ? "#0.000" : "#0.0000"), font, brush, x, y);
                    }
                    x += columnWidth;
                    if (dp == 4) x += 0.75f * TableFontSize;
                }
            }

            return bmp;
        }

        /*====================================================================================================
         * 
         * GraphSteelSlagStream()
         * 
         * Create new steel/slag and stream graphs and slag carryovers. The graphs and the array will have nothing
         * drawn on them yet, but they are ready to be used by the player. Meanwhile, the graphThread background
         * worker will do a full pass of the TWV file, drawing the graph while the player is mostly sleeping.
         * 
         * That means we can start playing straight away, not having to wait for the graphs to be produced first.
         */

        public void GraphSteelSlagStream(TWVReader twv, out Bitmap bmpSteelSlag, out Bitmap bmpStream, out Bitmap bmpHisto, out float[] slagCarries, out int[] tmax, out float[] exposure, bool underExposed)
        {
            float y;

            /*
             * Create array and graphs.
             */

            tmax = new int[1];
            exposure = new float[1]; exposure[0] = 1.0f;
            slagCarries = new float[twv.Header.FrameCount];

            bmpSteelSlag = new Bitmap((int)SteelSlagGraph.Width, (int)SteelSlagGraph.Height);
            Graphics gcSteelSlag = Graphics.FromImage(bmpSteelSlag);
            gcSteelSlag.SmoothingMode = SmoothingMode.AntiAlias;

            bmpStream = new Bitmap((int)StreamGraph.Width, (int)StreamGraph.Height);
            Graphics gcStream = Graphics.FromImage(bmpStream);
            gcStream.SmoothingMode = SmoothingMode.AntiAlias;
            bmpHisto = new Bitmap((int)Histo.Width, (int)Histo.Height);

            /*
             * Draw flight path.
             */

            UseSavedFlightPath(twv.Header.FlightPath);
            DrawBarnes(gcSteelSlag, bmpSteelSlag.Width, bmpSteelSlag.Height, twv.Header.VesselNumber);
            DrawBezier(gcSteelSlag, Xu, Yu, System.Drawing.Color.FromArgb(0x77, 0x9b, 0x63), bmpSteelSlag.Width, bmpSteelSlag.Height);
            DrawBezier(gcSteelSlag, Xl, Yl, System.Drawing.Color.FromArgb(0x9b, 0x48, 0x56), bmpSteelSlag.Width, bmpSteelSlag.Height);

            /*
             * Thresholds.
             */

            var dotorangepen = Pens.Orange.Clone() as Pen;
            var dotredpen = Pens.Red.Clone() as Pen;
            var dotcumupen = Pens.Tomato.Clone() as Pen;

            dotorangepen.DashStyle = dotredpen.DashStyle = dotcumupen.DashStyle = DashStyle.Dash;
            y = SteelSlagGraph.Height * (100f - twv.Header.Orange) / 100;
            gcSteelSlag.DrawLine(dotorangepen, 0, y, SteelSlagGraph.Width, y);
            y = SteelSlagGraph.Height * (100f - twv.Header.Red) / 100;
            gcSteelSlag.DrawLine(dotredpen, 0, y, SteelSlagGraph.Width, y);

            /*
             * Dart release and cumulative alarm.
             */

            float totMin = (float)(twv.Header.EndTap - twv.Header.StartTap).TotalMinutes;
            if (totMin > 0)
            {
                if (twv.Header.DartRelease > 0 && totMin > 0)
                {
                    float x = SteelSlagGraph.Width * twv.Header.DartRelease / totMin;
                    gcSteelSlag.DrawLine(dotorangepen, x, 0, x, SteelSlagGraph.Height);
                    gcStream.DrawLine(dotorangepen, x, 0, x, StreamGraph.Height);
                }
                if (twv.Header.CumulativeAlarm > 0 && totMin > 0)
                {
                    float x = SteelSlagGraph.Width * twv.Header.CumulativeAlarm / totMin;
                    gcSteelSlag.DrawLine(dotcumupen, x, 0, x, SteelSlagGraph.Height);
                    gcStream.DrawLine(dotcumupen, x, 0, x, StreamGraph.Height);
                }
            }

            /*
             * Dispose of graphics context.
             */

            gcSteelSlag.Dispose();
            gcStream.Dispose();

            /*
             * Start background worker to do the rest in parallel.
             */

            graphThread.RunWorkerAsync(new object[] { twv.FileName, bmpSteelSlag, bmpStream, bmpHisto, slagCarries, tmax, exposure, underExposed });
        }

        /*====================================================================================================
         * 
         * graphThread_DoWork()
         * 
         * The graph thread runs in parallel with the play thread. It does a full scan of the TWV file, reading
         * slag percentages, tilter angles, etc. and draws the graphs while the play thread is sleeping between
         * frames.
         */

        private void graphThread_DoWork(object sender, DoWorkEventArgs e)
        {
            var args = (object[])e.Argument;
            var fileName = (string)args[0];
            var bmpSteelSlag = (Bitmap)args[1];
            var bmpStream = (Bitmap)args[2];
            var bmpHisto = (Bitmap)args[3];
            var slagCarries = (float[])args[4];
            var tmax = (int[])args[5];
            var exposure = (float[])args[6];
            var underExposed = (bool)args[7];

            var colors = Forms.colorMap.Colors.Clone() as Color[];

            TWVReader twv = new TWVReader(fileName);
            twv.ReadHeader();

            float x, y;

            var modepen = new Pen(Color.FromArgb(0x40,0x40,0x40));
            var tanpen = Pens.Tan;
            var greypen = Pens.DimGray;
            var redpen = Pens.Red.Clone() as Pen; redpen.Width = 2;
            var greenpen = Pens.LimeGreen.Clone() as Pen; greenpen.Width = 2;

            try
            {
                float prevX = 0, prevHistoX = 0;
                float prevSteelY = 0;
                float prevSlagY = SteelSlagGraph.Height;
                float prevAngleY = SteelSlagGraph.Height;
                float prevStreamY = StreamGraph.Height;
                float prevHistoY1 = Histo.Height;
                float prevHistoY2 = Histo.Height;

                Brush greyBrush = Brushes.DarkGray;
                Brush tataBrush = new SolidBrush(tata);

                double slagSum = 0, totSum = 0;
                int prevPixMax = 0;

                /*
                 * Foreach frame.
                 */

                for (int frame = 0; frame < twv.Header.FrameCount; frame++)
                {
                    /*
                     * This can take a while, so we'll include a cancellation point.
                     */

                    if (playThread.CancellationPending) goto getout;
                    twv.ReadFrame();

                    /*
                     * Look for the overall highest value tmax (which has to be above the 
                     * slag threshold), and count pixel intensities. Having done that,
                     * look for the maximum and mode in this frame. If the video is under
                     * exposed, count steel/slag pixels in the image.
                     */

                    int steelpix = !underExposed ? twv.Frame.SteelPixels : 0;
                    int slagpix = !underExposed ? twv.Frame.SlagPixels : 0;

                    int p = 0;
                    int[] histoCount = new int[256];
                    int pixMax = 0, pixMode = 0, pixModeCount = 0;
                    for (int yy = 0; yy < TWV.YPIX; yy++)
                    {
                        for (int xx = 0; xx < TWV.XPIX; xx++)
                        {
                            int pix = twv.Frame.Pixels[p++];
                            if (xx >= twv.Header.Left && xx <= twv.Header.Right && yy >= twv.Header.Top && yy <= twv.Header.Bottom)
                            {
                                if (pix > tmax[0]) tmax[0] = pix;
                                histoCount[pix]++;
                                if (underExposed)
                                {
                                    if (pix > Forms.colorMap.L2) slagpix++;
                                    else if (pix > Forms.colorMap.L1) steelpix++;
                                }
                            }
                        }
                    }
                    for (int pix = 0; pix < histoCount.Length; pix++)
                    {
                        if (histoCount[pix] > 0)
                        {
                            if (pix > pixMax) pixMax = pix;
                            if (pix > Forms.colorMap.L1 && histoCount[pix] >= pixModeCount)
                            {
                                pixModeCount = histoCount[pix];
                                pixMode = pix;
                            }
                        }
                    }

                    float totpix = steelpix + slagpix;
                    x = (float)(SteelSlagGraph.Width * (twv.Frame.Timestamp - twv.Header.StartTap).TotalSeconds / twv.TotalSeconds);

                    /*
                     * Work out the current slag carryover.
                     */

                    slagSum += slagpix;
                    totSum += steelpix + slagpix;
                    if (totSum > 0) slagCarries[frame] = (float)(slagSum / totSum);
                    else slagCarries[frame] = 0;

                    /*
                     * Draw percent steel in grey, slag red, tilter angle green.
                     */

                    lock (bmpSteelSlag)
                    {
                        Graphics gcSteelSlag = Graphics.FromImage(bmpSteelSlag);
                        gcSteelSlag.SmoothingMode = SmoothingMode.AntiAlias;

                        y = SteelSlagGraph.Height;
                        if (totpix != 0) y = SteelSlagGraph.Height - SteelSlagGraph.Height * steelpix / totpix;
                        if (y > SteelSlagGraph.Height) y = SteelSlagGraph.Height;
                        else if (y < 0) y = 0;
                        gcSteelSlag.DrawLine(greypen, prevX, prevSteelY, x, y);
                        prevSteelY = y;

                        y = SteelSlagGraph.Height;
                        if (totpix != 0) y = SteelSlagGraph.Height - SteelSlagGraph.Height * slagpix / totpix - 1;
                        if (y > SteelSlagGraph.Height) y = SteelSlagGraph.Height;
                        else if (y < 0) y = 0;
                        gcSteelSlag.DrawLine(redpen, prevX, prevSlagY, x, y);
                        prevSlagY = y;

                        y = SteelSlagGraph.Height - SteelSlagGraph.Height * (twv.Frame.Angle - minAngle) / (maxAngle - minAngle) - 1;
                        if (y > SteelSlagGraph.Height) y = SteelSlagGraph.Height;
                        else if (y < 0) y = 0;
                        gcSteelSlag.DrawLine(greenpen, prevX, prevAngleY, x, y);
                        prevAngleY = y;

                        gcSteelSlag.Dispose();
                    }

                    /*
                     * Draw stream width in tan.
                     */

                    lock (bmpStream)
                    {
                        Graphics gcStream = Graphics.FromImage(bmpStream);
                        gcStream.SmoothingMode = SmoothingMode.AntiAlias;

                        y = StreamGraph.Height - StreamGraph.Height * (twv.Frame.SteelPixels + twv.Frame.SlagPixels) / maxPix;
                        if (y > StreamGraph.Height) y = StreamGraph.Height;
                        else if (y < 0) y = 0;
                        gcStream.DrawLine(tanpen, prevX, prevStreamY, x, y);
                        prevStreamY = y;

                        gcStream.Dispose();
                    }

                    prevX = x;

                    /*
                     * Draw pixel max and mode.
                     */

                    lock (bmpHisto)
                    {
                        Graphics gcHisto = Graphics.FromImage(bmpHisto);
                        gcHisto.SmoothingMode = SmoothingMode.AntiAlias;

                        x = (float)(Histo.Width * (twv.Frame.Timestamp - twv.Header.StartTap).TotalSeconds / twv.TotalSeconds);

                        y = Histo.Height - Histo.Height * pixMode / 255;
                        if (y > Histo.Height) y = Histo.Height;
                        else if (y < 0) y = 0;
                        gcHisto.DrawLine(modepen, prevHistoX, prevHistoY2, x, y);
                        prevHistoY2 = y;

                        y = Histo.Height - Histo.Height * pixMax / 255;
                        if (y > Histo.Height) y = Histo.Height;
                        else if (y < 0) y = 0;
                        gcHisto.DrawLine(new Pen(colors[Math.Max(pixMax, prevPixMax)]), prevHistoX, prevHistoY1, x, y);
                        prevPixMax = pixMax;
                        prevHistoY1 = y;

                        prevHistoX = x;
                    }
                }
            }
            catch (EndOfStreamException) { }

        getout:
            exposure[0] = tmax[0] / 180f;
            twv.Close();
        }

        /*====================================================================================================
         * 
         * Flight path code.
         */

        float[] Xu = new float[7];
        float[] Yu = new float[7];
        float[] Xl = new float[7];
        float[] Yl = new float[7];

        private void UseSavedFlightPath(string text)
        {
            // Get clipboard text, verify that it starts with header
            text = text.Trim();
            if (!text.StartsWith("Vessel 1 flight path:") &&
                !text.StartsWith("Vessel 2 flight path:")) return;

            // Break it into exactly five lines
            string[] lines = text.Split('\n');
            if (lines.Length != 5) return;

            // Break each data line into exactly seven numbers
            string[] a1 = lines[1].Split(',');
            string[] a2 = lines[2].Split(',');
            string[] a3 = lines[3].Split(',');
            string[] a4 = lines[4].Split(',');
            if (a1.Length != 7 || a2.Length != 7 || a3.Length != 7 || a4.Length != 7) return;

            // Parse the numbers into temporary arrays
            float[] xu = new float[7];
            float[] yu = new float[7];
            float[] xl = new float[7];
            float[] yl = new float[7];
            try
            {
                for (int i = 0; i < 7; i++)
                {
                    xu[i] = float.Parse(a1[i]);
                    yu[i] = float.Parse(a2[i]);
                    xl[i] = float.Parse(a3[i]);
                    yl[i] = float.Parse(a4[i]);
                }
            }
            catch
            {
                return;
            }

            // If we got this far, we're reasonably safe to use the data
            for (int i = 0; i < 7; i++)
            {
                Xu[i] = xu[i];
                Yu[i] = yu[i];
                Xl[i] = xl[i];
                Yl[i] = yl[i];
            }
        }

        //
        // Those 'orrible looking calculations are Bernstein polynomials:
        //
        //     http://www.math.ucla.edu/~baker/java/hoefer/Bezier.htm
        //
        // Most examples of Bezier curves limit themselves to four points for simplicity. The method can
        // be extended to any number of points, but that doesn't necessarily make them any easier to use.
        // A better way of having more points is to joining two or more curves end to end. As long as the
        // three points around a join are in a straight line, you will get a nice smooth join.
        //
        //     http://www.doc.ic.ac.uk/~dfg/AndysSplineTutorial/Beziers.html
        //

        private void DrawBezier(Graphics gc, float[] X, float[] Y, System.Drawing.Color colour, int width, int height)
        {
            float t, k = .0002f;
            float x1, y1;

            Pen pen = new Pen(colour);
            pen.Width = 2;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            // Curve one
            x1 = X[0] * (width - 1);
            y1 = height - Y[0] * height - 1;
            for (t = 0; t <= 1; t += k)
            {
                float x2 = (X[0] + t * (-X[0] * 3 + t * (3 * X[0] - X[0] * t)))
                         + t * (3 * X[1] + t * (-6 * X[1] + X[1] * 3 * t))
                         + t * t * (X[2] * 3 - X[2] * 3 * t)
                         + X[3] * t * t * t;
                float y2 = (Y[0] + t * (-Y[0] * 3 + t * (3 * Y[0] - Y[0] * t)))
                         + t * (3 * Y[1] + t * (-6 * Y[1] + Y[1] * 3 * t))
                         + t * t * (Y[2] * 3 - Y[2] * 3 * t)
                         + Y[3] * t * t * t;
                x2 = x2 * (width - 1);
                y2 = height - y2 * height - 1;
                gc.DrawLine(pen, (int)x1, (int)y1, (int)x2, (int)y2);
                x1 = x2;
                y1 = y2;
            }

            // Curve two
            x1 = X[3] * (width - 1);
            y1 = height - Y[3] * height - 1;
            for (t = 0; t <= 1; t += k)
            {
                float x2 = (X[3] + t * (-X[3] * 3 + t * (3 * X[3] - X[3] * t)))
                         + t * (3 * X[4] + t * (-6 * X[4] + X[4] * 3 * t))
                         + t * t * (X[5] * 3 - X[5] * 3 * t)
                         + X[6] * t * t * t;
                float y2 = (Y[3] + t * (-Y[3] * 3 + t * (3 * Y[3] - Y[3] * t)))
                         + t * (3 * Y[4] + t * (-6 * Y[4] + Y[4] * 3 * t))
                         + t * t * (Y[5] * 3 - Y[5] * 3 * t)
                         + Y[6] * t * t * t;
                x2 = x2 * (width - 1);
                y2 = height - y2 * height - 1;
                gc.DrawLine(pen, (int)x1, (int)y1, (int)x2, (int)y2);
                x1 = x2;
                y1 = y2;
            }

            pen.Dispose();
        }

        // Chris Barnes' vessel angles
        float[] fpUpperV1 = { 249, 254, 255, 256, 257, 258, 259, 260, 261, 261, 262, 263, 263, 264, 264, 265, 265, 265, 266, 266, 267, 267, 267, 268, 268, 268, 269, 269, 269, 270, 270, 270, 271, 271, 272, 272, 273, 273, 273, 273, 274, 274, 274, 274, 274, 275, 275, 275, 275, 275, 275, 275, 275, 275, 275, 276, 276, 276, 276, 276, 276, 276, 276, 276, 276, 277, 277, 277, 278, 278, 278, 278, 278, 279, 279, 279, 279, 279, 279, 279, 279, 279, 279, 279, 279, 279, 279, 279, 279, 279, 279, 279, 279, 279, 279, 279, 279, 279, 279, 259, 0 };
        float[] fpLowerV1 = { 245, 246, 248, 248, 249, 249, 250, 250, 250, 251, 251, 252, 252, 252, 253, 253, 254, 254, 255, 255, 256, 256, 257, 257, 257, 258, 258, 259, 259, 259, 260, 260, 260, 261, 261, 261, 262, 262, 262, 263, 264, 264, 265, 265, 265, 266, 266, 266, 267, 267, 267, 267, 268, 268, 268, 269, 269, 269, 269, 269, 269, 270, 270, 270, 270, 270, 270, 271, 271, 271, 271, 271, 271, 271, 272, 272, 272, 272, 273, 273, 273, 273, 273, 273, 273, 274, 274, 274, 274, 274, 274, 274, 274, 274, 274, 274, 274, 274, 267, 244, 0 };
        float[] fpUpperV2 = { 248, 253, 253, 254, 255, 255, 256, 257, 258, 258, 259, 260, 261, 262, 262, 263, 263, 264, 264, 265, 265, 266, 266, 266, 267, 268, 268, 268, 268, 268, 269, 269, 270, 270, 270, 271, 271, 271, 271, 271, 272, 272, 272, 272, 272, 272, 272, 272, 272, 272, 272, 272, 272, 272, 272, 272, 272, 272, 272, 272, 272, 273, 273, 273, 273, 273, 273, 274, 274, 275, 275, 276, 276, 277, 277, 278, 278, 278, 279, 279, 279, 279, 279, 279, 279, 279, 279, 279, 279, 279, 279, 279, 279, 278, 278, 278, 278, 279, 269, 250, 0 };
        float[] fpLowerV2 = { 244, 245, 246, 246, 247, 247, 248, 248, 248, 248, 249, 249, 249, 249, 250, 250, 250, 251, 251, 252, 252, 252, 253, 253, 253, 254, 254, 255, 255, 256, 257, 257, 258, 258, 258, 259, 259, 260, 260, 260, 260, 261, 262, 262, 263, 263, 264, 264, 264, 265, 265, 265, 265, 266, 266, 266, 266, 266, 266, 266, 267, 267, 267, 267, 267, 267, 267, 267, 267, 267, 267, 268, 268, 268, 269, 269, 269, 269, 270, 270, 270, 271, 272, 272, 273, 273, 273, 274, 274, 274, 274, 274, 275, 275, 275, 275, 275, 269, 254, 241, 0 };

        public void DrawBarnes(Graphics gc, int width, int height, int vesselNo)
        {
            Brush greenbrush = new SolidBrush(System.Drawing.Color.FromArgb(0x35, 0x37, 0x33));
            float min = 240;
            float max = 290;
            List<PointF> poly = new List<PointF>();
            float[] upper = vesselNo == 1 ? fpUpperV1 : fpUpperV2;
            float[] lower = vesselNo == 1 ? fpLowerV1 : fpLowerV2;
            for (int pct = 0; pct <= 100; pct++)
            {
                float x = width * pct / 100f;
                float y = height - height * (upper[pct] - min) / (max - min) - 1;
                if (y < 0) y = 0;
                poly.Add(new PointF(x, y));
            }
            for (int pct = 100; pct >= 0; pct--)
            {
                float x = width * pct / 100f;
                float y = height - height * (lower[pct] - min) / (max - min) - 1;
                if (y < 0) y = 0;
                poly.Add(new PointF(x, y));
            }
            gc.FillPolygon(greenbrush, poly.ToArray());
            greenbrush.Dispose();
        }

        /*====================================================================================================
         * 
         * SetPixel()
         * 
         * A faster version of Bitmap.SetPixel that pokes RGB values into memory without repeated locking and
         * unlocking. The BitmapData must have been locked with PixelFormat.Format32bppArgb beforehand.
         */

        private unsafe void SetPixel(BitmapData bData, int x, int y, Color col)
        {
            const byte bpp = 4; // bytes per pixel (32bbp ARGB)
            byte* scan0 = (byte*)bData.Scan0.ToPointer();
            byte* p = scan0 + y * bData.Stride + x * bpp;
            *p++ = col.B;
            *p++ = col.G;
            *p++ = col.R;
            *p++ = col.A;
        }

        /*====================================================================================================
         * 
         * RotateImage()
         * 
         * Convenience routine to rotate an image by a specified angle in degrees.
         */

        private Bitmap RotateImage(Bitmap b, float angle)
        {
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
            Graphics g = Graphics.FromImage(returnBitmap);
            g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
            g.RotateTransform(angle);
            g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
            g.DrawImage(b, new Point(0, 0));
            return returnBitmap;
        }
    }
}
