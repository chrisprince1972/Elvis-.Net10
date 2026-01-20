using Elvis.UserControls.HeatDetails.HotMetalUCs;
//using Microsoft.VisualBasic.PowerPacks;

namespace Elvis.UserControls.CasterMachineCondition
{
    partial class SingleStrandDetail
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SingleStrandDetail));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlTopHalf = new System.Windows.Forms.Panel();
            this.Options = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtTestDate = new System.Windows.Forms.DateTimePicker();
            this.cmboStrand = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmboCaster = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            //this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            //this.rectangleShape11 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            //this.rectangleShape12 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            //this.rectangleShape13 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            //this.rectangleShape14 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            //this.rectangleShape19 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            //this.rectangleShape20 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            //this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            //this.rectangleShape10 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            //this.rectangleShape9 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            //this.rectangleShape8 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            //this.rectangleShape7 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            //this.rectangleShape6 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            //this.rectangleShape5 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            //this.rectangleShape4 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            //this.rectangleShape3 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            //this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            //this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlBottomLeft = new System.Windows.Forms.Panel();
            this.pnlTopRight = new System.Windows.Forms.Panel();
            this.pnlTopLeft = new System.Windows.Forms.Panel();
            this.ucStrandAssessment = new Elvis.UserControls.CasterMachineCondition.StrandAssessmentSingle();
            this.ucSulphurPrint = new Elvis.UserControls.CasterMachineCondition.SulphurPrintSingle();
            this.ucUnitChangePriority = new Elvis.UserControls.CasterMachineCondition.UnitChangePrioritySingle();
            this.ucSprayWater = new Elvis.UserControls.CasterMachineCondition.SprayWaterSingle();
            this.ucSarclad = new Elvis.UserControls.CasterMachineCondition.SarcladSingle();
            this.pnlMain.SuspendLayout();
            this.pnlTopHalf.SuspendLayout();
            this.Options.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlBottomLeft.SuspendLayout();
            this.pnlTopRight.SuspendLayout();
            this.pnlTopLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMain.Controls.Add(this.pnlTopHalf);
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(6);
            this.pnlMain.Size = new System.Drawing.Size(1190, 903);
            this.pnlMain.TabIndex = 3;
            this.pnlMain.Enter += new System.EventHandler(this.pnlMain_Enter);
            // 
            // pnlTopHalf
            // 
            this.pnlTopHalf.Controls.Add(this.Options);
            this.pnlTopHalf.Controls.Add(this.ucStrandAssessment);
            this.pnlTopHalf.Controls.Add(this.panel3);
            this.pnlTopHalf.Controls.Add(this.panel2);
            this.pnlTopHalf.Controls.Add(this.panel1);
            this.pnlTopHalf.Controls.Add(this.pnlBottomLeft);
            this.pnlTopHalf.Controls.Add(this.pnlTopRight);
            this.pnlTopHalf.Controls.Add(this.pnlTopLeft);
            this.pnlTopHalf.Location = new System.Drawing.Point(6, 6);
            this.pnlTopHalf.Name = "pnlTopHalf";
            this.pnlTopHalf.Size = new System.Drawing.Size(1180, 890);
            this.pnlTopHalf.TabIndex = 5;
            // 
            // Options
            // 
            this.Options.Controls.Add(this.label4);
            this.Options.Controls.Add(this.btnPrevious);
            this.Options.Controls.Add(this.label21);
            this.Options.Controls.Add(this.btnNext);
            this.Options.Controls.Add(this.btnSearch);
            this.Options.Controls.Add(this.dtTestDate);
            this.Options.Controls.Add(this.cmboStrand);
            this.Options.Controls.Add(this.label1);
            this.Options.Controls.Add(this.cmboCaster);
            this.Options.Controls.Add(this.label2);
            this.Options.Controls.Add(this.label3);
            this.Options.Location = new System.Drawing.Point(34, 6);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(1112, 56);
            this.Options.TabIndex = 12;
            this.Options.TabStop = false;
            this.Options.Text = "Options";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(789, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Previous Date";
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.White;
            this.btnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevious.Image")));
            this.btnPrevious.Location = new System.Drawing.Point(864, 19);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(34, 25);
            this.btnPrevious.TabIndex = 29;
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(944, 27);
            this.label21.Margin = new System.Windows.Forms.Padding(3, 0, 3, 14);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 13);
            this.label21.TabIndex = 28;
            this.label21.Text = "Next Date";
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.White;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(904, 19);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(34, 25);
            this.btnNext.TabIndex = 27;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(614, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtTestDate
            // 
            this.dtTestDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTestDate.Location = new System.Drawing.Point(146, 21);
            this.dtTestDate.Name = "dtTestDate";
            this.dtTestDate.Size = new System.Drawing.Size(120, 20);
            this.dtTestDate.TabIndex = 17;
            // 
            // cmboStrand
            // 
            this.cmboStrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboStrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboStrand.FormattingEnabled = true;
            this.cmboStrand.Location = new System.Drawing.Point(506, 21);
            this.cmboStrand.Name = "cmboStrand";
            this.cmboStrand.Size = new System.Drawing.Size(54, 21);
            this.cmboStrand.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(451, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Strand";
            // 
            // cmboCaster
            // 
            this.cmboCaster.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboCaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboCaster.FormattingEnabled = true;
            this.cmboCaster.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmboCaster.Location = new System.Drawing.Point(344, 20);
            this.cmboCaster.Name = "cmboCaster";
            this.cmboCaster.Size = new System.Drawing.Size(54, 21);
            this.cmboCaster.TabIndex = 14;
            this.cmboCaster.SelectedValueChanged += new System.EventHandler(this.cmboCaster_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(299, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Caster";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(92, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Date";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.label25);
            this.panel3.Controls.Add(this.label26);
          //  this.panel3.Controls.Add(this.shapeContainer2);
            this.panel3.Location = new System.Drawing.Point(426, 230);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(160, 106);
            this.panel3.TabIndex = 14;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(39, 11);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 13);
            this.label16.TabIndex = 11;
            this.label16.Text = "Back Face";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(61, 86);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 10;
            this.label17.Text = "> ± 1.50mm";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Red;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label18.Location = new System.Drawing.Point(23, 86);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(14, 13);
            this.label18.TabIndex = 9;
            this.label18.Text = "0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(59, 63);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(98, 13);
            this.label19.TabIndex = 8;
            this.label19.Text = "± 1.00 to ± 1.50mm";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Orange;
            this.label20.Location = new System.Drawing.Point(21, 63);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(19, 13);
            this.label20.TabIndex = 7;
            this.label20.Text = "50";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(57, 41);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(62, 13);
            this.label25.TabIndex = 2;
            this.label25.Text = "< ± 1.00mm";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.LimeGreen;
            this.label26.Location = new System.Drawing.Point(15, 41);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(25, 13);
            this.label26.TabIndex = 1;
            this.label26.Text = "100";
            // 
            // shapeContainer2
            // 
            //this.shapeContainer2.Location = new System.Drawing.Point(0, 0);
            //this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            //this.shapeContainer2.Name = "shapeContainer2";
            //this.shapeContainer2.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            //this.rectangleShape11,
            //this.rectangleShape12,
            //this.rectangleShape13,
            //this.rectangleShape14,
            //this.rectangleShape19,
            //this.rectangleShape20});
            //this.shapeContainer2.Size = new System.Drawing.Size(160, 106);
            //this.shapeContainer2.TabIndex = 0;
            //this.shapeContainer2.TabStop = false;
            // 
            // rectangleShape11
            // 
            //this.rectangleShape11.Location = new System.Drawing.Point(56, 82);
            //this.rectangleShape11.Name = "rectangleShape10";
            //this.rectangleShape11.Size = new System.Drawing.Size(103, 23);
            // 
            // rectangleShape12
            // 
            //this.rectangleShape12.BackColor = System.Drawing.Color.Red;
            //this.rectangleShape12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            //this.rectangleShape12.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            //this.rectangleShape12.Location = new System.Drawing.Point(1, 82);
            //this.rectangleShape12.Name = "rectangleShape9";
            //this.rectangleShape12.Size = new System.Drawing.Size(55, 23);
            // 
            // rectangleShape13
            // 
            //this.rectangleShape13.BackColor = System.Drawing.Color.Orange;
            //this.rectangleShape13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            //this.rectangleShape13.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            //this.rectangleShape13.Location = new System.Drawing.Point(1, 59);
            //this.rectangleShape13.Name = "rectangleShape8";
            //this.rectangleShape13.Size = new System.Drawing.Size(55, 23);
            // 
            // rectangleShape14
            // 
            //this.rectangleShape14.Location = new System.Drawing.Point(56, 59);
            //this.rectangleShape14.Name = "rectangleShape7";
            //this.rectangleShape14.Size = new System.Drawing.Size(103, 23);
            // 
            // rectangleShape19
            // 
            //this.rectangleShape19.Location = new System.Drawing.Point(56, 36);
            //this.rectangleShape19.Name = "rectangleShape2";
            //this.rectangleShape19.Size = new System.Drawing.Size(103, 23);
            // 
            // rectangleShape20
            // 
            //this.rectangleShape20.BackColor = System.Drawing.Color.LimeGreen;
            //this.rectangleShape20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            //this.rectangleShape20.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            //this.rectangleShape20.Location = new System.Drawing.Point(1, 36);
            //this.rectangleShape20.Name = "rectangleShape1";
            //this.rectangleShape20.Size = new System.Drawing.Size(55, 23);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            //this.panel2.Controls.Add(this.shapeContainer1);
            this.panel2.Location = new System.Drawing.Point(426, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(160, 153);
            this.panel2.TabIndex = 13;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(39, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 13);
            this.label15.TabIndex = 11;
            this.label15.Text = "Roll Gaps";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(65, 133);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "> 2.00mm";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Red;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label14.Location = new System.Drawing.Point(23, 133);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(65, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "1.70 to 2.00mm";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Orange;
            this.label12.Location = new System.Drawing.Point(21, 110);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(19, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "25";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(64, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "1.30 to 1.70mm";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Yellow;
            this.label10.Location = new System.Drawing.Point(21, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "50";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(65, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "1.00 to 1.30mm";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Khaki;
            this.label7.Location = new System.Drawing.Point(22, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "75";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(65, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "< 1.00 mm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LimeGreen;
            this.label5.Location = new System.Drawing.Point(15, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "100";
            // 
            // shapeContainer1
            // 
            //this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            //this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            //this.shapeContainer1.Name = "shapeContainer1";
            //this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            //this.rectangleShape10,
            //this.rectangleShape9,
            //this.rectangleShape8,
            //this.rectangleShape7,
            //this.rectangleShape6,
            //this.rectangleShape5,
            //this.rectangleShape4,
            //this.rectangleShape3,
            //this.rectangleShape2,
            //this.rectangleShape1});
            //this.shapeContainer1.Size = new System.Drawing.Size(160, 153);
            //this.shapeContainer1.TabIndex = 0;
            //this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape10
            // 
            //this.rectangleShape10.Location = new System.Drawing.Point(56, 128);
            //this.rectangleShape10.Name = "rectangleShape10";
            //this.rectangleShape10.Size = new System.Drawing.Size(103, 23);
            // 
            // rectangleShape9
            // 
            //this.rectangleShape9.BackColor = System.Drawing.Color.Red;
            //this.rectangleShape9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            //this.rectangleShape9.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            //this.rectangleShape9.Location = new System.Drawing.Point(1, 128);
            //this.rectangleShape9.Name = "rectangleShape9";
            //this.rectangleShape9.Size = new System.Drawing.Size(55, 23);
            // 
            // rectangleShape8
            // 
            //this.rectangleShape8.BackColor = System.Drawing.Color.Orange;
            //this.rectangleShape8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            //this.rectangleShape8.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            //this.rectangleShape8.Location = new System.Drawing.Point(1, 105);
            //this.rectangleShape8.Name = "rectangleShape8";
            //this.rectangleShape8.Size = new System.Drawing.Size(55, 23);
            // 
            // rectangleShape7
            // 
            //this.rectangleShape7.Location = new System.Drawing.Point(56, 105);
            //this.rectangleShape7.Name = "rectangleShape7";
            //this.rectangleShape7.Size = new System.Drawing.Size(103, 23);
            // 
            // rectangleShape6
            // 
            //this.rectangleShape6.Location = new System.Drawing.Point(56, 82);
            //this.rectangleShape6.Name = "rectangleShape6";
            //this.rectangleShape6.Size = new System.Drawing.Size(103, 23);
            // 
            // rectangleShape5
            // 
            //this.rectangleShape5.BackColor = System.Drawing.Color.Yellow;
            //this.rectangleShape5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            //this.rectangleShape5.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            //this.rectangleShape5.Location = new System.Drawing.Point(1, 82);
            //this.rectangleShape5.Name = "rectangleShape5";
            //this.rectangleShape5.Size = new System.Drawing.Size(55, 23);
            // 
            // rectangleShape4
            // 
            //this.rectangleShape4.BackColor = System.Drawing.Color.Khaki;
            //this.rectangleShape4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            //this.rectangleShape4.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            //this.rectangleShape4.Location = new System.Drawing.Point(1, 59);
            //this.rectangleShape4.Name = "rectangleShape4";
            //this.rectangleShape4.Size = new System.Drawing.Size(55, 23);
            // 
            // rectangleShape3
            // 
            //this.rectangleShape3.Location = new System.Drawing.Point(56, 59);
            //this.rectangleShape3.Name = "rectangleShape3";
            //this.rectangleShape3.Size = new System.Drawing.Size(103, 23);
            // 
            // rectangleShape2
            // 
            //this.rectangleShape2.Location = new System.Drawing.Point(56, 36);
            //this.rectangleShape2.Name = "rectangleShape2";
            //this.rectangleShape2.Size = new System.Drawing.Size(103, 23);
            // 
            // rectangleShape1
            // 
            //this.rectangleShape1.BackColor = System.Drawing.Color.LimeGreen;
            //this.rectangleShape1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            //this.rectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            //this.rectangleShape1.Location = new System.Drawing.Point(1, 36);
            //this.rectangleShape1.Name = "rectangleShape1";
            //this.rectangleShape1.Size = new System.Drawing.Size(55, 23);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucSulphurPrint);
            this.panel1.Location = new System.Drawing.Point(84, 489);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 402);
            this.panel1.TabIndex = 12;
            // 
            // pnlBottomLeft
            // 
            this.pnlBottomLeft.Controls.Add(this.ucUnitChangePriority);
            this.pnlBottomLeft.Location = new System.Drawing.Point(702, 489);
            this.pnlBottomLeft.Name = "pnlBottomLeft";
            this.pnlBottomLeft.Size = new System.Drawing.Size(452, 402);
            this.pnlBottomLeft.TabIndex = 11;
            // 
            // pnlTopRight
            // 
            this.pnlTopRight.Controls.Add(this.ucSprayWater);
            this.pnlTopRight.Location = new System.Drawing.Point(702, 65);
            this.pnlTopRight.Name = "pnlTopRight";
            this.pnlTopRight.Size = new System.Drawing.Size(402, 403);
            this.pnlTopRight.TabIndex = 10;
            // 
            // pnlTopLeft
            // 
            this.pnlTopLeft.Controls.Add(this.ucSarclad);
            this.pnlTopLeft.Location = new System.Drawing.Point(84, 65);
            this.pnlTopLeft.Name = "pnlTopLeft";
            this.pnlTopLeft.Size = new System.Drawing.Size(331, 403);
            this.pnlTopLeft.TabIndex = 5;
            // 
            // ucStrandAssessment
            // 
            this.ucStrandAssessment.AutoSize = true;
            this.ucStrandAssessment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucStrandAssessment.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucStrandAssessment.Caster = 0;
            this.ucStrandAssessment.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucStrandAssessment.Location = new System.Drawing.Point(426, 342);
            this.ucStrandAssessment.Name = "ucStrandAssessment";
            this.ucStrandAssessment.Size = new System.Drawing.Size(215, 124);
            this.ucStrandAssessment.Strand = 0;
            this.ucStrandAssessment.TabIndex = 15;
            // 
            // ucSulphurPrint
            // 
            this.ucSulphurPrint.AutoSize = true;
            this.ucSulphurPrint.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucSulphurPrint.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucSulphurPrint.Caster = 0;
            this.ucSulphurPrint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucSulphurPrint.Location = new System.Drawing.Point(7, 6);
            this.ucSulphurPrint.Name = "ucSulphurPrint";
            this.ucSulphurPrint.Size = new System.Drawing.Size(479, 377);
            this.ucSulphurPrint.Strand = 0;
            this.ucSulphurPrint.TabIndex = 0;
            // 
            // ucUnitChangePriority
            // 
            this.ucUnitChangePriority.AutoSize = true;
            this.ucUnitChangePriority.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucUnitChangePriority.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucUnitChangePriority.Caster = 0;
            this.ucUnitChangePriority.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucUnitChangePriority.Location = new System.Drawing.Point(5, 6);
            this.ucUnitChangePriority.Name = "ucUnitChangePriority";
            this.ucUnitChangePriority.Size = new System.Drawing.Size(438, 393);
            this.ucUnitChangePriority.Strand = 0;
            this.ucUnitChangePriority.TabIndex = 0;
            // 
            // ucSprayWater
            // 
            this.ucSprayWater.AutoSize = true;
            this.ucSprayWater.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucSprayWater.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucSprayWater.Caster = 0;
            this.ucSprayWater.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucSprayWater.Location = new System.Drawing.Point(5, 6);
            this.ucSprayWater.Name = "ucSprayWater";
            this.ucSprayWater.Size = new System.Drawing.Size(389, 390);
            this.ucSprayWater.Strand = 0;
            this.ucSprayWater.TabIndex = 0;
            // 
            // ucSarclad
            // 
            this.ucSarclad.AutoSize = true;
            this.ucSarclad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucSarclad.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucSarclad.Caster = 0;
            this.ucSarclad.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucSarclad.Location = new System.Drawing.Point(3, 6);
            this.ucSarclad.Name = "ucSarclad";
            this.ucSarclad.Size = new System.Drawing.Size(321, 390);
            this.ucSarclad.Strand = 0;
            this.ucSarclad.TabIndex = 0;
            // 
            // SingleStrandDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "SingleStrandDetail";
            this.Size = new System.Drawing.Size(1200, 910);
            this.pnlMain.ResumeLayout(false);
            this.pnlTopHalf.ResumeLayout(false);
            this.pnlTopHalf.PerformLayout();
            this.Options.ResumeLayout(false);
            this.Options.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlBottomLeft.ResumeLayout(false);
            this.pnlBottomLeft.PerformLayout();
            this.pnlTopRight.ResumeLayout(false);
            this.pnlTopRight.PerformLayout();
            this.pnlTopLeft.ResumeLayout(false);
            this.pnlTopLeft.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox Options;
        private System.Windows.Forms.Panel pnlTopHalf;
        private System.Windows.Forms.Panel pnlTopLeft;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmboStrand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmboCaster;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtTestDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlTopRight;
        private SprayWaterSingle sprayWater1;
        private System.Windows.Forms.Panel pnlBottomLeft;
        private System.Windows.Forms.Panel panel1;
        private SarcladSingle sarclad1;
        private UnitChangePrioritySingle ucUnitChangePriority;
        private SprayWaterSingle ucSprayWater;
        private SarcladSingle ucSarclad;
        private SulphurPrintSingle ucSulphurPrint;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
       // private ShapeContainer shapeContainer1;
       // private RectangleShape rectangleShape2;
       // private RectangleShape rectangleShape1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
       // private RectangleShape rectangleShape4;
      //  private RectangleShape rectangleShape3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        //private RectangleShape rectangleShape6;
        //private RectangleShape rectangleShape5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        //private RectangleShape rectangleShape8;
        //private RectangleShape rectangleShape7;
        //private RectangleShape rectangleShape10;
        //private RectangleShape rectangleShape9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        //private ShapeContainer shapeContainer2;
        //private RectangleShape rectangleShape11;
        //private RectangleShape rectangleShape12;
        //private RectangleShape rectangleShape13;
        //private RectangleShape rectangleShape14;
        //private RectangleShape rectangleShape19;
        //private RectangleShape rectangleShape20;
        private StrandAssessmentSingle ucStrandAssessment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnNext;
    }
}
