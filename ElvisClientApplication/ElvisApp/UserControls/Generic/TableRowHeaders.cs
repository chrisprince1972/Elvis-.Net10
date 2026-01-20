using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Elvis.UserControls.Generic
{

    class TableRowHeaders : TableLayoutPanel
    {
        private Headers Headers { get; set; }

        public TableRowHeaders()
        {
            Headers = null;
            RowCount = 0;
            RowStyles.Clear();
        }
        public TableRowHeaders(Headers defaultHeaders)
        {
            Headers = defaultHeaders;
            RowCount = 0;
            RowStyles.Clear();
        }


        public void AddRow(Headers headers, List<CellContents> cells)
        {
            int heightCount = 0;
            foreach (Header head in headers.Info)
            {
                int columnLength = 0;
                int height = 0;
                int count = 0;
                foreach (ColumnHeaderInfo colHead in head.ColumnHeaders)
                {
                    Panel p = new Panel() { Dock = DockStyle.Fill };

                    Label header = new Label() { Text = colHead.Name, Height = colHead.Height, Dock = DockStyle.Fill, Font = colHead.Font };
                    p.Controls.Add(header);

                    if (head.ColumnHeaders.Count == 2)
                    {
                        CellContents cc = cells[count];
                        Button btn = GetEditButton(cc);
                        p.Controls.Add(btn);
                        count++;
                    }

                    Controls.Add(p, columnLength, RowCount);
                    SetColumnSpan(header, colHead.Span);
                    columnLength += colHead.Span;
                    height = colHead.Height;
                }

                RowCount++;
                heightCount += height;
                RowStyles.Add(new RowStyle() { SizeType = System.Windows.Forms.SizeType.Absolute, Height = height });
            }

            Height += heightCount;

            AddTextBoxes(cells);

        }

        public void SetFocusOnFirstButton()
        {
            foreach (Control c in Controls)
            {
                if (c is Button)
                {
                    Button b = (Button)c;
                    b.Select();
                    break;
                }
            }
        }

        private int GetNumberOfBlankLinesInString(string s)
        {
            string[] lines = s.Split('\n');
            int returnValue = 0;
            foreach (string l in lines)
            {
                if (string.IsNullOrWhiteSpace(l))
                {
                    returnValue++;
                }
            }

            return returnValue;
        }



        private int GetTextBoxHeight(List<CellContents> cells, Font f)
        {
            //min height
            int returnValue = 50;

            foreach (CellContents cellContents in cells)
            {
                TextBox tb = GetTextCell(cellContents);
                //measure text does not account for blank lines so we have to improvise.
                Size s = TextRenderer.MeasureText(cellContents.TextBoxText, f, new Size(tb.Width, 0), TextFormatFlags.NoPadding);
                int height = s.Height;

                if (height > returnValue)
                {
                    int lengthOfNewLines = 0;
                    Size sSingleChar = TextRenderer.MeasureText("*", f, new Size(tb.Width, 0));
                    lengthOfNewLines = sSingleChar.Height * GetNumberOfBlankLinesInString(cellContents.TextBoxText);

                    returnValue = height + lengthOfNewLines;
                        
                }
            }

            //sorry for the magic number (1.07) I did just pluck it out of thin air.  The function seemed to be under estimating the size of the text.
            double newHeight = returnValue * 1.07;
            return Convert.ToInt32(newHeight);
        }


        private void AddTextBoxes(List<CellContents> cells)
        {
            int cellCount = 0;
            TextBox t = new TextBox();
            int highestTextBoxHeight = GetTextBoxHeight(cells, t.Font);
            for(int i =0; i < cells.Count; i++ )
            {
                //CellContents cellContents in cells
                TextBox text = GetTextCell(cells[i]);
                Controls.Add(text, cellCount++, RowCount);
                text.Height = highestTextBoxHeight;
            }

            RowStyles.Add(new RowStyle() { SizeType = System.Windows.Forms.SizeType.Absolute, Height = highestTextBoxHeight });
            RowCount++;


            Height += highestTextBoxHeight;
        }

        private Button GetEditButton(CellContents cellContents)
        {

            Button returnValue = new Button()
            {
                Text = "Edit",
                AutoSize = true,
                Dock = DockStyle.Right,
                BackColor = System.Drawing.SystemColors.Control,
                Tag = cellContents.Object,
                Width = 27,
                Padding = new Padding(0,0,0,0),
                Margin = new Padding(0, 0, 0, 0),
                
            };


            if (cellContents.OnClickEdit != null)
            {
                returnValue.Click += (sender, e) =>
                {
                    object obj = ((Button)sender).Tag;
                    cellContents.OnClickEdit(obj);
                };
            }

            return returnValue;
        }
        private TextBox GetTextCell(CellContents cellContents)
        {

            TextBox returnValue = new TextBox()
            {
                Text = cellContents.TextBoxText,
                Multiline = true,
                AutoSize = true,
                Dock = DockStyle.Fill,
                BackColor = System.Drawing.SystemColors.Control,
                ReadOnly = true,
                Cursor = Cursors.Default
            };
            
            return returnValue;
        }

        public List<CellContents> GetAllData()
        {
            List<CellContents> returnValue = new List<CellContents>();
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    TextBox tb = (TextBox)c;
                    returnValue.Add(new CellContents(tb.Text, tb.Tag));
                }
            }
            return returnValue;
        }
    }
    public class ColumnHeaderInfo
    {
        public string Name { get; private set; }
        public int Span { get; set; }
        public int Height { get; set; }
        public Font Font { get; set; }

        public ColumnHeaderInfo(string name, int span, int height, Font font)
        {
            Name = name;
            Span = span;
            Height = height;
            Font = font;
        }

    }

    public class Header
    {
        public List<ColumnHeaderInfo> ColumnHeaders { get; private set; }
        public Header(List<ColumnHeaderInfo> colNames)
        {
            ColumnHeaders = colNames;
        }
    }

    public class Headers
    {
        public List<Header> Info { get; private set; }
        public Headers(List<Header> headers)
        {
            Info = headers;
        }
    }

    public class CellContents
    {
        public string TextBoxText { get; set; }
        public object Object { get; set; }
        public Func<object, bool> OnClickEdit { get; set; }

        public CellContents(string textBoxText, object obj, Func<object, bool> onEdit)
        {
            TextBoxText = textBoxText;
            Object = obj;
            OnClickEdit = onEdit;
        }
        public CellContents(string textBoxText, object obj)
        {
            TextBoxText = textBoxText;
            Object = obj;
            OnClickEdit = null;
        }
    }


}
