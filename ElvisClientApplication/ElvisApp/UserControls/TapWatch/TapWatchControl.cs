using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using TapWatchPlayback;

namespace Elvis.UserControls.TapWatch
{
    public partial class TapWatchControl : UserControl
    {
        public string[] twDirs;

        /*====================================================================================================
         * 
         * Configuration.
         */
        private int heatNumber;
        private Layout layout;
        private Color red = Color.Red;
        private Color grey = Color.FromArgb(50, 50, 50);
        private bool autoThreshold;

        Dictionary<string, string> colourSchemes = new Dictionary<string, string>();

        /*====================================================================================================
         * 
         * Contructor and Form_Load.
         * 
         * Define the layout, spin off a worker thread to get the directory list.
         */

        public TapWatchControl()
        {
            InitializeComponent();
        }

        internal void SetupUserControl(int heatNumber, int heatNumberSet)
        {
            this.heatNumber = heatNumber;
            TapWatchPlayback.Forms.form1 = this;
            TapWatchPlayback.Forms.colorMap = new ColourMap();
            TapWatchPlayback.Forms.colorMap.ForceHandleCreation();
            

            ddLayout.SelectedIndex = 0;
            autoThreshold = cbAutoThreshold.Checked;

            string fnam = "\\\\BOSTHERMCAMNAS.porttalbot.pcswales.corusgroup.com\\Tap Watch Data\\" + heatNumber + "\\" + heatNumber + ".twv";
            this.Text = fnam;
            lblFileName.Text = fnam;
            btnPlay.PerformClick();

            /*
             * Populate colours dropdown and menu item.
             */
            ddColours.Items.Clear();
            colourSchemes["Shades of Cyan"] = "#000000, #2B2B2B,43, #002C2C, #009B9B,150, #C80000, #FF0000";
            colourSchemes["Contrast"] = "#000000, #313155,43, #313155, #6700B6,150, #FFFF00, #FF0000";
            colourSchemes["Hot Metal"] = "#FF6700, #FFFF00,43, #FFF300, #E10018,150, #000000, #A400B0";
            colourSchemes["Nowt Landish"] = "#000000, #2B2B3B,43, #2B2B2B, #9B9B9B,150, #FF0000, #FD0000";
            foreach (string key in colourSchemes.Keys)
            {
                ddColours.Items.Add(key);
                ToolStripMenuItem menuItem = new ToolStripMenuItem();
                menuItem.Text = key;
                menuItem.Click += new EventHandler(changeColoursToolStripMenuItem_Clicked);
                changeColoursToolStripMenuItem.DropDownItems.Add(menuItem);
            }
            ddColours.SelectedIndex = 0;

            /*
             * Populate layout menu item from dropdown.
             */

            foreach (string str in ddLayout.Items)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem();
                menuItem.Text = str;
                menuItem.Click += new EventHandler(changeLayoutToolStripMenuItem_Clicked);
                changeLayoutToolStripMenuItem.DropDownItems.Add(menuItem);
            }

            /*
             * Bring the menu bar in line with button and dropdown lists.
             */

            UpdateMenuBar();
            TapWatchPlayback.Forms.colorMap.Hide();
        }

        private void UpdateMenuBar()
        {
            pauseResumeToolStripMenuItem.Enabled = btnPauseResume.Enabled;
            goToStartTapToolStripMenuItem.Enabled = btnRestart.Enabled;
            goToEndTapToolStripMenuItem.Enabled = btnEndTap.Enabled;
            slowNormalSpeedToolStripMenuItem.Enabled = btnSlow.Enabled;

            string col = (string)ddColours.SelectedItem;
            foreach (ToolStripMenuItem item in changeColoursToolStripMenuItem.DropDownItems)
            {
                item.Checked = item.Text == col;
            }

            string lay = (string)ddLayout.SelectedItem;
            foreach (ToolStripMenuItem item in changeLayoutToolStripMenuItem.DropDownItems)
            {
                item.Checked = item.Text == lay;
            }
        }

        /*====================================================================================================
         * 
         * SplashImage()
         * 
         * Create a blank image with a blue header.
         */

        private Bitmap SplashImage(int heatNumber)
        {
            Bitmap largeBitmap = new Bitmap(layout.Width, layout.Height);
            Graphics gc = Graphics.FromImage(largeBitmap);
            gc.SmoothingMode = SmoothingMode.AntiAlias;
            gc.InterpolationMode = InterpolationMode.HighQualityBicubic;

            StringFormat sf = (StringFormat)StringFormat.GenericTypographic.Clone();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            /*
             * Grey background.
             */

            gc.Clear(Color.FromArgb(0x22, 0x22, 0x22));

            /*
             * Blue header.
             */

            gc.DrawImage(layout.BannerImage(null), 0, 0);

            /*
             * Title.
             */

            sf.Alignment = layout.Heat.Alignment;
            sf.LineAlignment = layout.Heat.VerticalAlignment;
            gc.DrawString(heatNumber.ToString(), layout.Heat.Font, Brushes.White, layout.Heat.X, layout.Heat.Y, sf);

            /*
             * Done.
             */

            return largeBitmap;
        }

        /*====================================================================================================
         * 
         * playThread_DoWork()
         * 
         * The playback thread runs in the background after the user has clicked the "Play" button. It reads
         * the video file a frame at a time, and sleeps between frames. There is a bit of interaction with
         * user events through the playFrameNo global and the ffrwResume event.
         */

        private bool playing = false;
        private int playFrames, playFrameNo, playFrameCurrent;

        private void playThread_DoWork(object sender, DoWorkEventArgs e)
        {
            TWVReader twv = null;

            try
            {
                /*
                 * Open the video file. If this throws an error, there's no point continuing.                 * 
                 */

                twv = new TWVReader(lblFileName.Text);
                twv.ReadHeader();
                TapWatchPlayback.Forms.colorMap.L1 = twv.Header.L1;
                TapWatchPlayback.Forms.colorMap.L2 = twv.Header.L2;

                /*
                 * At this point, we can assume the file is ok to use.
                 */

                Invoke(new MethodInvoker(delegate
                {
                    TapWatchPlayback.Forms.colorMap.Update();
                    this.Text = "Tap Watch Video Player - " + twv.FileName;
                    this.Update();
                }));

                /*
                 * Produce (static) tables of Rdb data from the header.
                 */

                Bitmap analsTable = layout.FormatAnalyses(twv);
                Bitmap addsTable = layout.FormatAdditions(twv);
                Bitmap tempsTable = layout.FormatTempsMisc(twv);
                Bitmap cbmTable = layout.FormatCBM(twv);

                /*
                 * Fill in popups.
                 */

                BeginInvoke(new MethodInvoker(delegate
                {
                    lblCBMCalcHMC.Text = twv.Header.Cbm.CalculatedHmLadleCarbon >= 0 ? twv.Header.Cbm.CalculatedHmLadleCarbon.ToString("#0.0000") : "-";
                    lblCBMCalcHMSi.Text = twv.Header.Cbm.CalculatedHmLadleSilicon >= 0 ? twv.Header.Cbm.CalculatedHmLadleSilicon.ToString("#0.000") : "-";
                    lblCBMCalcHMMn.Text = twv.Header.Cbm.CalculatedHmLadleManganese >= 0 ? twv.Header.Cbm.CalculatedHmLadleManganese.ToString("#0.000") : "-";
                    lblCBMCalcHMP.Text = twv.Header.Cbm.CalculatedHmLadlePhosphorus >= 0 ? twv.Header.Cbm.CalculatedHmLadlePhosphorus.ToString("#0.000") : "-";
                    lblCBMCalcHMS.Text = twv.Header.Cbm.CalculatedHmLadleSulphur >= 0 ? twv.Header.Cbm.CalculatedHmLadleSulphur.ToString("#0.000") : "-";
                    lblCBMPredTapC.Text = twv.Header.Cbm.PredictedTapCarbon >= 0 ? twv.Header.Cbm.PredictedTapCarbon.ToString("#0.0000") : "-";
                    lblCBMPredTapMn.Text = twv.Header.Cbm.PredictedTapManganese >= 0 ? twv.Header.Cbm.PredictedTapManganese.ToString("#0.000") : "-";
                    lblCBMPredTapP.Text = twv.Header.Cbm.PredictedTapPhosphorus >= 0 ? twv.Header.Cbm.PredictedTapPhosphorus.ToString("#0.000") : "-";
                    lblCBMPredTapS.Text = twv.Header.Cbm.PredictedTapSulphur >= 0 ? twv.Header.Cbm.PredictedTapSulphur.ToString("#0.000") : "-";
                    lblCBMPredSlagCaO.Text = twv.Header.Cbm.PredictedSlagCaO >= 0 ? twv.Header.Cbm.PredictedSlagCaO.ToString("#0.000") : "-";
                    lblCBMPredSlagFe.Text = twv.Header.Cbm.PredictedSlagFe >= 0 ? twv.Header.Cbm.PredictedSlagFe.ToString("#0.000") : "-";
                    lblCBMPredSlagFeO.Text = twv.Header.Cbm.PredictedSlagFeO >= 0 ? twv.Header.Cbm.PredictedSlagFeO.ToString("#0.000") : "-";
                    lblCBMPredSlagMgO.Text = twv.Header.Cbm.PredictedSlagMgO >= 0 ? twv.Header.Cbm.PredictedSlagMgO.ToString("#0.000") : "-";
                    lblCBMPredSlagMnO.Text = twv.Header.Cbm.PredictedSlagMnO >= 0 ? twv.Header.Cbm.PredictedSlagMnO.ToString("#0.000") : "-";
                    lblCBMPredSlagP2O5.Text = twv.Header.Cbm.PredictedSlagP2O5 >= 0 ? twv.Header.Cbm.PredictedSlagP2O5.ToString("#0.000") : "-";
                    lblCBMPredSlagSiO2.Text = twv.Header.Cbm.PredictedSlagSiO2 >= 0 ? twv.Header.Cbm.PredictedSlagSiO2.ToString("#0.000") : "-";
                    lblCBMPredTapWt.Text = twv.Header.Cbm.CbmPredictedTapWeight >= 0 ? twv.Header.Cbm.CbmPredictedTapWeight.ToString("#0.0") : "-";
                    lblCBMPredSlagWt.Text = twv.Header.Cbm.CbmPredictedSlagWeight >= 0 ? twv.Header.Cbm.CbmPredictedSlagWeight.ToString("#0.0") : "-";
                    lblCBMRunTime.Text = twv.Header.Cbm.CbmRunTimeStamp.ToString("dd-MMM-yyyy HH:mm:ss");
                }));

                /*
                 * Create the steel/slag and stream width graphs. This can take a wee while so we'll
                 * just get empty graphs for now, they will be drawn by a background worker.
                 * The gradient is static as long as the colour schema stays the same.
                 */

                bool doneAutoThreshold = !autoThreshold;
                bool underExposed = false;
                string prevSchema = "";
                Layout prevLayout = layout;
                Bitmap steelSlagGraph, streamGraph, histoGraph;
                float[] slagCarries;
                int[] tmax;
                float[] exposure;

                layout.GraphSteelSlagStream(twv,
                                            out steelSlagGraph,
                                            out streamGraph,
                                            out histoGraph,
                                            out slagCarries,
                                            out tmax,
                                            out exposure,
                                            underExposed);

                Bitmap gradientBitmap = TapWatchPlayback.Forms.colorMap.GradientBitmap((int)layout.Histo.Width,
                                                                      (int)(layout.Histo.Height * 0.03f));

                int[] idummy;
                float[] fdummy;

                /*
                 * Now turn the buttons on.
                 */

                BeginInvoke(new MethodInvoker(delegate
                {
                    btnRestart.Enabled = btnEndTap.Enabled = true;
                    btnRewind.Enabled = btnFastForward.Enabled = true;
                    btnPauseResume.Enabled = btnSlow.Enabled = true;
                    btnStopWatch.Enabled = true;
                    btnAgain.Enabled = stopWatchOn = false;
                    cbAutoThreshold.Enabled = false;
                    UpdateMenuBar();
                }));

                /*
                 * Rewind the file so we're at the first frame.
                 */

                twv.ReadHeader();
                playFrames = twv.Header.FrameCount;
                playFrameNo = -999;
                playing = true;
                DateTime prevStamp = twv.Header.StartTap;
                StringFormat sf = (StringFormat)StringFormat.GenericTypographic.Clone();
                sf.Alignment = layout.Angle.Alignment;
                sf.LineAlignment = layout.Angle.VerticalAlignment;

                /*
                 * Foreach frame.
                 */

                int frame = playFrameCurrent = 0;
                while (frame < twv.Header.FrameCount)
                {
                    /*
                     * Layout and colour schema can change by using dropdown list. If so, we can easily 
                     * redo the Rdb data and the gradient from the header. Redrawing the graphs might be 
                     * too slow for some machines, so we'll only redo them when changing layouts.
                     */

                    string schema = TapWatchPlayback.Forms.colorMap.Schema;

                    if (layout != prevLayout || schema != prevSchema)
                    {
                        if (layout != prevLayout)
                        {
                            analsTable = layout.FormatAnalyses(twv);
                            addsTable = layout.FormatAdditions(twv);
                            tempsTable = layout.FormatTempsMisc(twv);
                            cbmTable = layout.FormatCBM(twv);
                            layout.GraphSteelSlagStream(twv,
                                                        out steelSlagGraph,
                                                        out streamGraph,
                                                        out histoGraph,
                                                        out slagCarries,
                                                        out tmax,
                                                        out exposure,
                                                        underExposed);
                            prevLayout = layout;
                        }
                        gradientBitmap = TapWatchPlayback.Forms.colorMap.GradientBitmap((int)layout.Histo.Width,
                                                                       (int)(layout.Histo.Height * 0.03f));
                        prevSchema = schema;
                    }

                    /*
                     * If we've done the background scan and found an underexposed video,
                     * adjust the thresholds. The thresholds can also be moved around manually
                     * using the colour mappings dialog.
                     */

                    if (!doneAutoThreshold && !layout.graphThread.IsBusy)
                    {
                        if (exposure[0] < Config.ExposureThreshold)
                        {
                            underExposed = true;
                            TapWatchPlayback.Forms.colorMap.L2 = (byte)(twv.Header.L2 * exposure[0]);
                            TapWatchPlayback.Forms.colorMap.L1 = (byte)(twv.Header.L1 * exposure[0]);
                            layout.GraphSteelSlagStream(twv, out steelSlagGraph, out streamGraph, out histoGraph, out slagCarries, out idummy, out fdummy, underExposed);
                        }
                        doneAutoThreshold = true;
                    }

                    /*
                     * If we're fast forwarding, or dragging the cursor along the graphs, move to the
                     * required frame. This involves recalculating the running slag pie. Also, if we're
                     * running in slow motion, we'll want to reset the stopwatch every time the user
                     * moves the cursor.
                     */

                    if (stopWatchOn == true && stopWatchOnTime == DateTime.MinValue)
                    {
                        stopWatchOnTime = twv.Frame.Timestamp;
                        stopWatchFrame = frame;
                    }

                    if (playFrameNo >= 0)
                    {
                        frame = playFrameNo;
                        if (frame == 0) twv.ReadFrame(0);
                        else twv.ReadFrame(frame - 1);
                        prevStamp = twv.Frame.Timestamp;
                        twv.ReadFrame(frame);
                        stopWatchOnTime = twv.Frame.Timestamp;
                        stopWatchFrame = frame;
                        twv.GotoFrame(frame);
                        playFrameNo = -999;
                    }

                    /*
                     * Read the frame, sleep between frames. If the ffrwResume event has been cleared, we'll
                     * suspend ourselves until the user clicks the "Resume" button.
                     */

                    if (playThread.CancellationPending) goto getout;
                    twv.ReadFrame();
                    if (twv.Frame.Timestamp == DateTime.MinValue) goto getout;
                    ffrwResume.WaitOne();
                    if (ffrwInc == 0)
                    {
                        for (int i = 0; i < ffrwSlowDownFactor; i++)
                        {
                            if (playThread.CancellationPending) goto getout;
                            if (twv.Frame.Timestamp > prevStamp)
                            {
                                Thread.Sleep(twv.Frame.Timestamp - prevStamp);
                            }
                            else
                            {
                                // Negative sleep time calculated. 
                                // This seems to be a result of a problem
                                // With the Land System connection dropping out
                                // Resulting in effectively a corrupt video. 

                            }
                            if (playThread.CancellationPending) goto getout;
                        }
                    }

                    /*
                     * Draw the frame-dependent stuff: video, speed, angle, steel-slag, histogram.
                     */
                    analsTable = null; // Turn this off - delete this line to turn back on. 

                    float comp = (autoThreshold == true && exposure[0] < Config.ExposureThreshold) ? exposure[0] : 1.0f;
                    Bitmap bmp = layout.PixelsToImage(twv, slagCarries[frame], tmax[0], comp, layout.BannerImage(twv), steelSlagGraph, streamGraph, histoGraph, gradientBitmap, analsTable, addsTable, tempsTable, cbmTable);
                    Graphics gc = Graphics.FromImage(bmp);
                    gc.SmoothingMode = SmoothingMode.AntiAlias;

                    /*
                     * Stopwatch.
                     */

                    if (stopWatchOn)
                    {
                        TimeSpan elapsed = twv.Frame.Timestamp - stopWatchOnTime;
                        sf.Alignment = layout.StopWatch.Alignment;
                        sf.LineAlignment = layout.StopWatch.VerticalAlignment;
                        string cron = elapsed.ToString();
                        if (cron.Length >= 11) cron = cron.Substring(3, 8);
                        gc.DrawString(cron,
                                      layout.StopWatch.Font,
                                      new SolidBrush(layout.StopWatch.Color),
                                      layout.StopWatch.X,
                                      layout.StopWatch.Y,
                                      sf);
                    }

                    /*
                     * Done. Slap the bitmap onto the picture box.
                     */

                    try
                    {
                        BeginInvoke(new MethodInvoker(delegate { pictureBox1.Image = bmp; }));
                    }
                    catch
                    {
                        goto getout;
                    }
                    prevStamp = twv.Frame.Timestamp;
                    playFrameCurrent = frame++;
                }
            }
            catch (EndOfStreamException) { }
            catch (FileNotFoundException) { }
            catch (DirectoryNotFoundException) { }
            catch (TWVVersionException ex)
            {
                string mess = "Unsupported TWV format: V" + ex.Version + " (check for upgrade)";
                if (ex.Version < 0.01f || ex.Version > 10f) mess = "Unsupported TWV format (possibly corrupted)";
                BeginInvoke(new MethodInvoker(delegate
                {
                    MessageBox.Show(this, mess, "Tap Watch Video Player", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }

        getout:
            if (twv != null) twv.Close();
            playing = false;

            /*
             * Now turn the buttons on.
             */

            try
            {
                BeginInvoke(new MethodInvoker(delegate
                {
                    btnRestart.Enabled = btnEndTap.Enabled = false;
                    btnRewind.Enabled = btnFastForward.Enabled = false;
                    btnPauseResume.Enabled = btnSlow.Enabled = false;
                    btnStopWatch.Enabled = false;
                    btnAgain.Enabled = stopWatchOn = false;
                    cbAutoThreshold.Enabled = true;
                    btnPlay.PerformClick();
                }));
            }
            catch { }
        }


        /*====================================================================================================
         * 
         * Mouse dragging code. Depending on where we click, we can slide the frame cursor. One or two other
         * items are also clickable.
         */

        int click = 0;

        public void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            click = 0;
            if (!playing) return;
            if (e.Button == MouseButtons.Left)
            {
                if (e.X >= layout.SteelSlagGraph.X && e.X <= layout.SteelSlagGraph.X + layout.SteelSlagGraph.Width &&
                    e.Y >= layout.SteelSlagGraph.Y && e.Y <= layout.StreamLegend.Y + 10)
                {
                    click = 1;
                    pictureBox1_MouseMove(sender, e);
                }
                else if (e.X >= layout.Histo.X && e.X <= layout.Histo.X + layout.Histo.Width &&
                         e.Y >= layout.Histo.Y && e.Y <= layout.Histo.Y + layout.Histo.Height)
                {
                    click = 2;
                    pictureBox1_MouseMove(sender, e);
                }
                else if (e.X >= layout.CBM.X && e.X <= layout.CBM.X + layout.CBM.Width &&
                         e.Y >= layout.CBM.Y && e.Y <= layout.CBM.Y + layout.CBM.Height)
                {
                    click = 3;
                }
            }
        }

        public void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!playing || e.Button != MouseButtons.Left) return;
            int frm;

            switch (click)
            {
                case 1: // Cursor
                    frm = (int)(playFrames * (e.X - layout.SteelSlagGraph.X) / layout.SteelSlagGraph.Width);
                    if (frm >= 0 && frm < playFrames) playFrameNo = frm;
                    break;
                case 2: // Histogram
                    frm = (int)(playFrames * (e.X - layout.Histo.X) / layout.Histo.Width);
                    if (frm >= 0 && frm < playFrames) playFrameNo = frm;
                    break;
                case 3: // CBM
                default:
                    break;
            }
        }

        public void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!playing) return;
            switch (click)
            {
                case 3: // CBM
                    pnlCBM.Visible = !pnlCBM.Visible;
                    break;
                case 1: // Cursor
                case 2: // Histogram
                default:
                    break;
            }
            click = 0;
        }

        /*====================================================================================================
         * 
         * Play, pause, slow motion and restart buttons. The pause button clears the ffrwResume event, so the
         * thread will get suspended until the (resume) button is pressed again. Slow motion just means we
         * repeat the between-frame wait a few times to slow things down.
         */

        int ffrwInc = 0;
        int ffrwSlowDownFactor = 1;
        ManualResetEvent ffrwResume = new ManualResetEvent(true);
        bool ffrwPaused = false;

        private void btnPlay_Click(object sender, EventArgs e)
        {
            ffrwResume.Set();
            ffrwPaused = false;
            ffrwSlowDownFactor = 1;
            ffrwInc = 0;
            btnSlow.Text = "Slow";
            slowNormalSpeedToolStripMenuItem.Text = "Slow Speed";
            if (!playThread.IsBusy)
            {
                btnPlay.Text = "Stop";
                playThread.RunWorkerAsync();
         
                stopToolStripMenuItem.ShortcutKeyDisplayString = "Esc";
            }
            else
            {
                btnPlay.Text = "Play";
                playThread.CancelAsync();
           
                stopToolStripMenuItem.ShortcutKeyDisplayString = "";
            }
            stopToolStripMenuItem.Text = btnPlay.Text;

            UpdateMenuBar();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            playFrameNo = 0;
            ffrwResume.Set();
            ffrwPaused = false;
            pauseResumeToolStripMenuItem.Text = btnPauseResume.Text = "Pause";
        }

        private void btnEndTap_Click(object sender, EventArgs e)
        {
            int frame = playFrames - 150;
            if (frame > 0) playFrameNo = frame;
            ffrwResume.Set();
            ffrwPaused = false;
            pauseResumeToolStripMenuItem.Text = btnPauseResume.Text = "Pause";
        }

        private void btnPauseResume_Click(object sender, EventArgs e)
        {
            if (ffrwPaused)
            {
                ffrwResume.Set();
                btnPauseResume.Text = "Pause";
            }
            else
            {
                ffrwResume.Reset();
                btnPauseResume.Text = "Resume";
            }
            pauseResumeToolStripMenuItem.Text = btnPauseResume.Text;
            btnFastForward.Enabled = btnRewind.Enabled = btnPlay.Enabled = ffrwPaused;
            UpdateMenuBar();
            ffrwPaused = !ffrwPaused;
        }

        private void btnSlow_Click(object sender, EventArgs e)
        {
            if (ffrwSlowDownFactor == 1)
            {
                ffrwSlowDownFactor = 5;
                btnSlow.Text = "Normal";
                slowNormalSpeedToolStripMenuItem.Text = "Normal Speed";
            }
            else
            {
                ffrwSlowDownFactor = 1;
                btnSlow.Text = "Slow";
                slowNormalSpeedToolStripMenuItem.Text = "Slow Speed";
            }
            ffrwResume.Set();
            ffrwPaused = false;
            pauseResumeToolStripMenuItem.Text = btnPauseResume.Text = "Pause";
        }

        /*====================================================================================================
         * 
         * Fast forward and rewind buttons. Simulate an auto repeat button by trapping mouse down events to
         * start/stop a timer. The timer increments or decrements the playFrameNo global by a large'ish number
         * to speed things up.
         */

        private void ffrwTimer_Tick(object sender, EventArgs e)
        {
            if (ffrwInc != 0)
            {
                int frame = playFrameCurrent + ffrwInc;
                if (frame >= 0 && frame < playFrames) playFrameNo = frame;
            }
        }

        private void btnFastForward_MouseDown(object sender, MouseEventArgs e)
        {
            if (!ffrwTimer.Enabled) ffrwTimer.Start();
            ffrwInc = 10;
        }

        private void btnRewind_MouseDown(object sender, MouseEventArgs e)
        {
            if (!ffrwTimer.Enabled) ffrwTimer.Start();
            ffrwInc = -10;
        }

        private void btnFastForwardRewind_MouseUp(object sender, MouseEventArgs e)
        {
            ffrwInc = 0;
            ffrwTimer.Stop();
        }

        private void btnFastForward_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space) btnFastForward_MouseDown(sender, null);
        }

        private void btnFastForward_KeyUp(object sender, KeyEventArgs e)
        {
            btnFastForwardRewind_MouseUp(sender, null);
        }

        private void btnRewind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space) btnRewind_MouseDown(sender, null);
        }

        private void btnRewind_KeyUp(object sender, KeyEventArgs e)
        {
            btnFastForwardRewind_MouseUp(sender, null);
        }

        /*====================================================================================================
         * 
         * Stopwatch code.
         */

        private DateTime stopWatchOnTime = DateTime.MinValue;
        private bool stopWatchOn = false;
        private int stopWatchFrame;

        private void btnStopWatch_Click(object sender, EventArgs e)
        {
            stopWatchOn = !stopWatchOn;
            stopWatchOnTime = DateTime.MinValue;
            btnAgain.Enabled = stopWatchOn;
        }

        private void btnAgain_Click(object sender, EventArgs e)
        {
            playFrameNo = stopWatchFrame;
            ffrwResume.Set();
            ffrwPaused = false;
            pauseResumeToolStripMenuItem.Text = btnPauseResume.Text = "Pause";
        }

        /*====================================================================================================
         * 
         * Hotkeys. Form1.KeyPreview must be true, otherwise the KeyDown event never arrives.
         */

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    if (pnlCBM.Visible) btnHideCBM.PerformClick();
                    else if (playThread.IsBusy) btnPlay.PerformClick();
                    break;
                default:
                    break;
            }
        }

        /*====================================================================================================
         * 
         * Menu items.
         */
        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPlay.PerformClick();
        }

        private void pauseResumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (btnPauseResume.Enabled) btnPauseResume.PerformClick();
        }

        private void slowNormalSpeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (btnSlow.Enabled) btnSlow.PerformClick();
        }

        private void goToStartTapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (btnRestart.Enabled) btnRestart.PerformClick();
        }

        private void goToEndTapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (btnEndTap.Enabled) btnEndTap.PerformClick();
        }

        private void colourMappingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TapWatchPlayback.Forms.colorMap.Show();
        }

        /*====================================================================================================
         * 
         * Menu items and dropdown list to change layout.
         */

        private void changeLayoutToolStripMenuItem_Clicked(object sender, EventArgs e)
        {
            ddLayout.SelectedItem = ((ToolStripMenuItem)sender).Text;
        }

        private void ddLayout_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddLayout.SelectedItem.ToString())
            {
                case "1024x768":
                    layout = new Layout1024x768(playThread);
                    break;
                case "800x600":
                default:
                    layout = new Layout800x600(playThread);
                    break;
            }
            pictureBox1.Width = layout.Width;
            pictureBox1.Height = layout.Height;
            pictureBox1.Image = SplashImage(this.heatNumber);
            this.Width = layout.Width + 7;
            this.Height = layout.Height + 89;
  
            UpdateMenuBar();
        }

        /*====================================================================================================
         * 
         * Menu items and dropdown list to change layout.
         */

        private void changeColoursToolStripMenuItem_Clicked(object sender, EventArgs e)
        {
            ddColours.SelectedItem = ((ToolStripMenuItem)sender).Text;
        }

        private void ddColours_SelectedIndexChanged(object sender, EventArgs e)
        {
            byte L1 = TapWatchPlayback.Forms.colorMap.L1;
            byte L2 = TapWatchPlayback.Forms.colorMap.L2;
            TapWatchPlayback.Forms.colorMap.Schema = colourSchemes[ddColours.SelectedItem.ToString()];
            TapWatchPlayback.Forms.colorMap.L1 = L1;
            TapWatchPlayback.Forms.colorMap.L2 = L2;
            UpdateMenuBar();
        }

        /*====================================================================================================
         * 
         * Toolbar events.
         */

        private void cbAutoThreshold_CheckedChanged(object sender, EventArgs e)
        {
            autoThreshold = cbAutoThreshold.Checked;
        }

        private void btnHideCBM_Click(object sender, EventArgs e)
        {
            pnlCBM.Visible = false;
        }
    }
}
