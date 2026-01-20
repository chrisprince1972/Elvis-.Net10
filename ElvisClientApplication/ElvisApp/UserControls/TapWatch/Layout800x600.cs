using System;
using System.Drawing;
using System.ComponentModel;

namespace TapWatchPlayback
{
    class Layout800x600 : Layout
    {
        public Layout800x600(BackgroundWorker bgw)
        {
            playThread = bgw;

            StringAlignment left = StringAlignment.Near;
            StringAlignment right = StringAlignment.Far;
            StringAlignment top = StringAlignment.Near;
            StringAlignment bottom = StringAlignment.Far;
            StringAlignment center = StringAlignment.Center;
            float largeFont = 11f;
            float smallFont = 7f;
            float legendFont = 5.5f;
            Width = 791;
            Height = 466;
            Color = Color.FromArgb(0x22, 0x22, 0x22);
            Video = new Layout.Image(10, 39, 454, 310);
            float rhSpace = Width - Video.Width - 28;
            float graphHeight = 80;
            SteelSlagBar = new Layout.Image(Video.X + 2, Video.Y + 2, 80, Video.Height - 5);
            Dart = new Layout.Text(SteelSlagBar.X + SteelSlagBar.Width / 2, SteelSlagBar.Y + SteelSlagBar.Height - 16, 10, Color.Yellow, center, bottom, "Dart In");
            Chrono = new Layout.Text(SteelSlagBar.X + SteelSlagBar.Width + 8, SteelSlagBar.Y + SteelSlagBar.Height, legendFont, Color.White, left, bottom);
            VesselAngle = new Layout.Image(Video.X + Video.Width - 80, Video.Y - 4, 81, 81);
            TilterSpeed = new Layout.Image(VesselAngle.X + 10, VesselAngle.Y + VesselAngle.Height + 6, 64, 64);
            SlagPie = new Layout.Image(TilterSpeed.X, TilterSpeed.Y + TilterSpeed.Height + 14, 64, 64);
            StreamBar = new Layout.Image(SlagPie.X + 12, SlagPie.Y + SlagPie.Height + 16, 40, 64);
            SteelSlagGraph = new Layout.Image(Width - rhSpace - 10, Video.Y, rhSpace, graphHeight);
            StreamGraph = new Layout.Image(SteelSlagGraph.X, SteelSlagGraph.Y + SteelSlagGraph.Height + 10, rhSpace, graphHeight);
            Heat = new Layout.Text(10, 14, 12, white, left, center);
            Time = new Layout.Text(Width - 55, 14, 8, white, right, center);
            Vessel = new Layout.Text(Time.X - 180, 14, 8, white, right, center);
            Steel = new Layout.Text(SteelSlagBar.X + SteelSlagBar.Width / 2, SteelSlagBar.Y + 6, 6, white, center, center);
            Slag = new Layout.Text(SteelSlagBar.X + SteelSlagBar.Width / 2, SteelSlagBar.Y + SteelSlagBar.Height - 6, 6, white, center, center);
            Stream = new Layout.Text(StreamBar.X + StreamBar.Width / 2, StreamBar.Y + 6, 6, Color.White, center, center);
            SlagPct = new Layout.Text(SlagPie.X + SlagPie.Width / 2, SlagPie.Y + SlagPie.Height / 2, largeFont, Color.White, center, center);
            Angle = new Layout.Text(VesselAngle.X + VesselAngle.Width - 5, VesselAngle.Y + VesselAngle.Height, legendFont, Color.White, right, bottom);
            Speed = new Layout.Text(TilterSpeed.X + TilterSpeed.Width, TilterSpeed.Y + TilterSpeed.Height + 5, legendFont, Color.White, right, bottom);
            Histo = new Layout.Image(Video.X + Video.Width - 326, Video.Y + Video.Height - 65, 256, 60);
            SteelSlagLegend = new Layout.Text(SteelSlagGraph.X, SteelSlagGraph.Y + SteelSlagGraph.Height + 2, legendFont, Color.White, left, top, "Steel, slag, flight path");
            StreamLegend = new Layout.Text(StreamGraph.X, StreamGraph.Y + StreamGraph.Height + 2, legendFont, Color.White, left, top, "Stream volume");
            Cursor = new Layout.Image(SteelSlagGraph.X, SteelSlagGraph.Y, rhSpace, StreamLegend.Y - SteelSlagGraph.Y + 10);
            Analyses = new Layout.Image(Video.X, Video.Y + Video.Height + 8, Width - 20, Height - (Video.Y + Video.Height) - 18);
            Additions = new Layout.Image(StreamLegend.X, StreamLegend.Y + 20, StreamGraph.Width / 2, (Video.Y + Video.Height) - (StreamLegend.Y + 20));
            Temps = new Layout.Image(Additions.X + Additions.Width + 6, Additions.Y, (SteelSlagGraph.X + SteelSlagGraph.Width) - (Additions.X + Additions.Width + 6), Additions.Height);
            CBM = new Layout.Image(Additions.X, Analyses.Y-33, Additions.Width, 33);
            StopWatch = new Layout.Text(Video.X + Video.Width - 100, Video.Y + 10, 20, white, right, top);
            TableFontSize = smallFont;
        }
    }
}
