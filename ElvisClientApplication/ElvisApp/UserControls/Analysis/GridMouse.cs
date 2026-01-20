//using System;
//using System.Drawing;
//using System.Windows.Forms;

//namespace Elvis.Forms
//{
//    public class GridMouse
//    {
//        DataGridView grid;
//        bool flash;

//        public GridMouse(DataGridView Grid, bool Flash=false)
//        {
//            grid = Grid;
//            flash = Flash;
//            grid.MouseWheel += new MouseEventHandler(MouseWheel);
//            grid.CellMouseEnter += new DataGridViewCellEventHandler(CellMouseEnter);
//            grid.CellMouseLeave += new DataGridViewCellEventHandler(CellMouseLeave);
//            grid.EnableHeadersVisualStyles = false;
//            foreach (DataGridViewColumn tc in grid.Columns) tc.SortMode = DataGridViewColumnSortMode.NotSortable;
//        }

//        void MouseWheel(object sender, MouseEventArgs e)
//        {
//            if (e.Delta < 0)
//            {
//                if (grid.FirstDisplayedScrollingRowIndex < grid.Rows.Count)
//                    grid.FirstDisplayedScrollingRowIndex++;
//            }
//            else
//            {
//                if (grid.FirstDisplayedScrollingRowIndex > 0)
//                    grid.FirstDisplayedScrollingRowIndex--;
//            }
//        }

//        Color prevColor;

//        void CellMouseEnter(object sender, DataGridViewCellEventArgs e)
//        {
//            try
//            {
//                if (e.RowIndex == -1) return;

//                grid.Focus();
//                if (!flash) return;

//                if (e.RowIndex < grid.Rows.Count)
//                {
//                    grid.ClearSelection();
//                    DataGridViewRow tr = grid.Rows[e.RowIndex];
//                    if (tr.Cells[0].Value.ToString() != "")
//                    {
//                        prevColor = tr.Cells[0].Style.ForeColor;
//                        for (int i = 0; i < tr.Cells.Count; i++)
//                        {
//                            tr.Cells[i].Style.BackColor = Color.DeepSkyBlue;
//                            tr.Cells[i].Style.ForeColor = Color.White;
//                        }
//                    }
//                }
//            }
//            catch { }
//        }

//        void CellMouseLeave(object sender, DataGridViewCellEventArgs e)
//        {
//            if (e.RowIndex == -1) return;

//            Form1 frm = (Form1)grid.FindForm();
//            frm.btnTata.Focus();
//            if (!flash) return;

//            if (e.RowIndex < grid.Rows.Count)
//            {
//                DataGridViewRow tr = grid.Rows[e.RowIndex];
//                for (int i = 0; i < tr.Cells.Count; i++)
//                {
//                    tr.Cells[i].Style.BackColor = grid.BackgroundColor;
//                    tr.Cells[i].Style.ForeColor = prevColor;
//                }
//            }
//        }
//    }
//}
