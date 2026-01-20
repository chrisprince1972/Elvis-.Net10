using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TapWatchPlayback
{
    public partial class ColourMap : Form
    {
        private byte _BackR1, _BackR2;
        private byte _BackG1, _BackG2;
        private byte _BackB1, _BackB2;
        private byte _SteelR1, _SteelR2;
        private byte _SteelG1, _SteelG2;
        private byte _SteelB1, _SteelB2;
        private byte _SlagR1, _SlagR2;
        private byte _SlagG1, _SlagG2;
        private byte _SlagB1, _SlagB2;
        private string _BackRGB1, _BackRGB2;
        private string _SteelRGB1, _SteelRGB2;
        private string _SlagRGB1, _SlagRGB2;
        private byte _L1, _L2;
        private string _Schema;

        private Color[] _Colors = new Color[256];

        string originalSettings;

        public ColourMap()
        {
            InitializeComponent();
            tbSlider_Scroll(this, null);
        }

        public Color[] Colors
        {
            get
            {
                return _Colors;
            }
        }

        public void ForceHandleCreation()
        {
            if (!this.IsHandleCreated)
                this.CreateHandle();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public byte L1
        {
            get
            {
                return _L1;
            }
            set
            {
                BeginInvoke(new MethodInvoker(delegate {
                    tbL1.Value = value;
                    tbSlider_Scroll(this, null); 
                }));
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public byte L2
        {
            get
            {
                return _L2;
            }
            set
            {
                BeginInvoke(new MethodInvoker(delegate {
                    tbL2.Value = value;
                    tbSlider_Scroll(this, null); 
                }));
            }
        }

        private Regex reSchema = new Regex("^ *" +
                                           "#([0-9A-F][0-9A-F])([0-9A-F][0-9A-F])([0-9A-F][0-9A-F]), *" +
                                           "#([0-9A-F][0-9A-F])([0-9A-F][0-9A-F])([0-9A-F][0-9A-F]), *" +
                                           "([0-9]+), *" +
                                           "#([0-9A-F][0-9A-F])([0-9A-F][0-9A-F])([0-9A-F][0-9A-F]), *" +
                                           "#([0-9A-F][0-9A-F])([0-9A-F][0-9A-F])([0-9A-F][0-9A-F]), *" +
                                           "([0-9]+), *" +
                                           "#([0-9A-F][0-9A-F])([0-9A-F][0-9A-F])([0-9A-F][0-9A-F]), *" +
                                           "#([0-9A-F][0-9A-F])([0-9A-F][0-9A-F])([0-9A-F][0-9A-F]) *" +
                                           "$");

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Schema
        {
            get
            {
                return _Schema;
            }
            set
            {
                int BackR1, BackG1, BackB1, BackR2, BackG2, BackB2;
                int SteelR1, SteelG1, SteelB1, SteelR2, SteelG2, SteelB2;
                int SlagR1, SlagG1, SlagB1, SlagR2, SlagG2, SlagB2;
                int L1, L2;
                ParseSchema(value,
                            out BackR1,
                            out BackG1,
                            out BackB1,
                            out BackR2,
                            out BackG2,
                            out BackB2,
                            out L1,
                            out SteelR1,
                            out SteelG1,
                            out SteelB1,
                            out SteelR2,
                            out SteelG2,
                            out SteelB2,
                            out L2,
                            out SlagR1,
                            out SlagG1,
                            out SlagB1,
                            out SlagR2,
                            out SlagG2,
                            out SlagB2);
                if (this.IsHandleCreated)
                {
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        tbBackR1.Value = BackR1;
                        tbBackG1.Value = BackG1;
                        tbBackB1.Value = BackB1;
                        tbBackR2.Value = BackR2;
                        tbBackG2.Value = BackG2;
                        tbBackB2.Value = BackB2;
                        tbL1.Value = L1;
                        tbSteelR1.Value = SteelR1;
                        tbSteelG1.Value = SteelG1;
                        tbSteelB1.Value = SteelB1;
                        tbSteelR2.Value = SteelR2;
                        tbSteelG2.Value = SteelG2;
                        tbSteelB2.Value = SteelB2;
                        tbL2.Value = L2;
                        tbSlagR1.Value = SlagR1;
                        tbSlagG1.Value = SlagG1;
                        tbSlagB1.Value = SlagB1;
                        tbSlagR2.Value = SlagR2;
                        tbSlagG2.Value = SlagG2;
                        tbSlagB2.Value = SlagB2;
                        tbSlider_Scroll(this, null);
                    }));
                }
            }
        }

        private void ParseSchema(string schema,
                                 out int BackR1,
                                 out int BackG1,
                                 out int BackB1,
                                 out int BackR2,
                                 out int BackG2,
                                 out int BackB2,
                                 out int L1,
                                 out int SteelR1,
                                 out int SteelG1,
                                 out int SteelB1,
                                 out int SteelR2,
                                 out int SteelG2,
                                 out int SteelB2,
                                 out int L2,
                                 out int SlagR1,
                                 out int SlagG1,
                                 out int SlagB1,
                                 out int SlagR2,
                                 out int SlagG2,
                                 out int SlagB2)
        {
            MatchCollection mc = reSchema.Matches(schema);
            if (mc.Count != 1) throw new Exception("Bad colour Schema definition");

            Match m = mc[0];
            if (m.Groups.Count != 21) throw new Exception("Bad colour Schema definition");

            int i = 1;
            BackR1 = int.Parse(m.Groups[i++].Value, NumberStyles.HexNumber);
            BackG1 = int.Parse(m.Groups[i++].Value, NumberStyles.HexNumber);
            BackB1 = int.Parse(m.Groups[i++].Value, NumberStyles.HexNumber);
            BackR2 = int.Parse(m.Groups[i++].Value, NumberStyles.HexNumber);
            BackG2 = int.Parse(m.Groups[i++].Value, NumberStyles.HexNumber);
            BackB2 = int.Parse(m.Groups[i++].Value, NumberStyles.HexNumber);
            L1 = int.Parse(m.Groups[i++].Value);
            SteelR1 = int.Parse(m.Groups[i++].Value, NumberStyles.HexNumber);
            SteelG1 = int.Parse(m.Groups[i++].Value, NumberStyles.HexNumber);
            SteelB1 = int.Parse(m.Groups[i++].Value, NumberStyles.HexNumber);
            SteelR2 = int.Parse(m.Groups[i++].Value, NumberStyles.HexNumber);
            SteelG2 = int.Parse(m.Groups[i++].Value, NumberStyles.HexNumber);
            SteelB2 = int.Parse(m.Groups[i++].Value, NumberStyles.HexNumber);
            L2 = int.Parse(m.Groups[i++].Value);
            SlagR1 = int.Parse(m.Groups[i++].Value, NumberStyles.HexNumber);
            SlagG1 = int.Parse(m.Groups[i++].Value, NumberStyles.HexNumber);
            SlagB1 = int.Parse(m.Groups[i++].Value, NumberStyles.HexNumber);
            SlagR2 = int.Parse(m.Groups[i++].Value, NumberStyles.HexNumber);
            SlagG2 = int.Parse(m.Groups[i++].Value, NumberStyles.HexNumber);
            SlagB2 = int.Parse(m.Groups[i++].Value, NumberStyles.HexNumber);
        }

        private void tbSlider_Scroll(object sender, EventArgs e)
        {
            ApplyChanges();
            picFullGrad.Image = GradientBitmap(picFullGrad.Width, picFullGrad.Height, _Colors, 0, 255);
            picBackGrad.Image = GradientBitmap(picBackGrad.Width, picBackGrad.Height, _Colors, 0, tbL1.Value - 1);
            picSteelGrad.Image = GradientBitmap(picSteelGrad.Width, picSteelGrad.Height, _Colors, tbL1.Value, tbL2.Value - 1);
            picSlagGrad.Image = GradientBitmap(picSlagGrad.Width, picSlagGrad.Height, _Colors, tbL2.Value, 255);
        }

        private Bitmap GradientBitmap(int width, int height, Color[] colors, int min, int max)
        {
            Bitmap bmp = new Bitmap(width, height);
            Graphics gc = Graphics.FromImage(bmp);

            if (width > height)
            {
                float x = 0;
                float step = width/(max-min+1f);
                for (int pix = min; pix <= max; pix++)
                {
                    gc.FillRectangle(new SolidBrush(colors[pix]), x, 0, step, height);
                    x += step;
                }
            }
            else
            {
                float y = height;
                float step = height/(max-min+1f);
                for (int pix = min; pix <= max; pix++)
                {
                    y -= step;
                    gc.FillRectangle(new SolidBrush(colors[pix]), 0, y, width, step);
                }
            }

            gc.Dispose();

            return bmp;
        }

        public Bitmap GradientBitmap(int width, int height)
        {
            return GradientBitmap(width, height, _Colors, 0, 255);
        }

        private void ApplyChanges()
        {
            _L1 = (byte)tbL1.Value;
            _L2 = (byte)tbL2.Value;
            _BackR1 = (byte)tbBackR1.Value; _BackR2 = (byte)tbBackR2.Value;
            _BackG1 = (byte)tbBackG1.Value; _BackG2 = (byte)tbBackG2.Value;
            _BackB1 = (byte)tbBackB1.Value; _BackB2 = (byte)tbBackB2.Value;
            _SteelR1 = (byte)tbSteelR1.Value; _SteelR2 = (byte)tbSteelR2.Value;
            _SteelG1 = (byte)tbSteelG1.Value; _SteelG2 = (byte)tbSteelG2.Value;
            _SteelB1 = (byte)tbSteelB1.Value; _SteelB2 = (byte)tbSteelB2.Value;
            _SlagR1 = (byte)tbSlagR1.Value; _SlagR2 = (byte)tbSlagR2.Value;
            _SlagG1 = (byte)tbSlagG1.Value; _SlagG2 = (byte)tbSlagG2.Value;
            _SlagB1 = (byte)tbSlagB1.Value; _SlagB2 = (byte)tbSlagB2.Value;

            grpL1.Text = _L1.ToString();
            grpL2.Text = _L2.ToString();
            _BackRGB1 = grpBackRGB1.Text = " #" + _BackR1.ToString("X2") + _BackG1.ToString("X2") + _BackB1.ToString("X2");
            _SteelRGB1 = grpSteelRGB1.Text = " #" + _SteelR1.ToString("X2") + _SteelG1.ToString("X2") + _SteelB1.ToString("X2");
            _SlagRGB1 = grpSlagRGB1.Text = " #" + _SlagR1.ToString("X2") + _SlagG1.ToString("X2") + _SlagB1.ToString("X2");
            _BackRGB2 = grpBackRGB2.Text = " #" + _BackR2.ToString("X2") + _BackG2.ToString("X2") + _BackB2.ToString("X2");
            _SteelRGB2 = grpSteelRGB2.Text = " #" + _SteelR2.ToString("X2") + _SteelG2.ToString("X2") + _SteelB2.ToString("X2");
            _SlagRGB2 = grpSlagRGB2.Text = " #" + _SlagR2.ToString("X2") + _SlagG2.ToString("X2") + _SlagB2.ToString("X2");

            _Schema =             _BackRGB1 + "," + _BackRGB2 + "," +
                      _L1 + "," + _SteelRGB1 + "," + _SteelRGB2 + "," +
                      _L2 + "," + _SlagRGB1 + "," + _SlagRGB2;

            _Colors = new Color[256];
            CalculateColourRange(_Colors, 0, tbL1.Value, tbBackR1.Value, tbBackG1.Value, tbBackB1.Value, tbBackR2.Value, tbBackG2.Value, tbBackB2.Value);
            CalculateColourRange(_Colors, tbL1.Value, tbL2.Value, tbSteelR1.Value, tbSteelG1.Value, tbSteelB1.Value, tbSteelR2.Value, tbSteelG2.Value, tbSteelB2.Value);
            CalculateColourRange(_Colors, tbL2.Value, 256, tbSlagR1.Value, tbSlagG1.Value, tbSlagB1.Value, tbSlagR2.Value, tbSlagG2.Value, tbSlagB2.Value);
        }

        private void CalculateColourRange(Color[] colors, int min, int max, int R1, int G1, int B1, int R2, int G2, int B2)
        {
            for (int pix=min; pix<max; pix++)
            {
                float R = R1 + (R2-R1)*(pix-min)/(max-min) + 0.5f;
                float G = G1 + (G2-G1)*(pix-min)/(max-min) + 0.5f;
                float B = B1 + (B2-B1)*(pix-min)/(max-min) + 0.5f;
                colors[pix] = Color.FromArgb((int)R, (int)G, (int)B);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnReset.PerformClick();
            this.Hide();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Schema = originalSettings;
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        new public void Show()
        {
            originalSettings = Schema;
            base.Show();
            SetForegroundWindow(this.Handle);
        }

        private void ColourMap_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(Schema);
        }
    }
}
