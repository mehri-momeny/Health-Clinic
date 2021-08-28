namespace Patient_clinic
{
    partial class frmshowdata
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmshowdata));
            this.dgvList = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnexit = new DevComponents.DotNetBar.ButtonX();
            this.btnedit = new DevComponents.DotNetBar.ButtonX();
            this.btndelete = new DevComponents.DotNetBar.ButtonX();
            this.txtFirstnamesearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtlastnamesearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtnationalcodesearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtfathername = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnNwRef = new DevComponents.DotNetBar.ButtonX();
            this.btnReport = new DevComponents.DotNetBar.ButtonX();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbmonth = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.Farvardin = new DevComponents.Editors.ComboItem();
            this.Ordibeheasht = new DevComponents.Editors.ComboItem();
            this.khordad = new DevComponents.Editors.ComboItem();
            this.Tir = new DevComponents.Editors.ComboItem();
            this.Mordad = new DevComponents.Editors.ComboItem();
            this.shahrivar = new DevComponents.Editors.ComboItem();
            this.Mehr = new DevComponents.Editors.ComboItem();
            this.Aban = new DevComponents.Editors.ComboItem();
            this.Azar = new DevComponents.Editors.ComboItem();
            this.Dey = new DevComponents.Editors.ComboItem();
            this.bahman = new DevComponents.Editors.ComboItem();
            this.Esfand = new DevComponents.Editors.ComboItem();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_filter = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToOrderColumns = true;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvList.Location = new System.Drawing.Point(12, 40);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(969, 401);
            this.dgvList.TabIndex = 0;
            this.dgvList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvList_CellMouseClick);
            // 
            // btnexit
            // 
            this.btnexit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnexit.BackColor = System.Drawing.Color.Transparent;
            this.btnexit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnexit.Image = ((System.Drawing.Image)(resources.GetObject("btnexit.Image")));
            this.btnexit.Location = new System.Drawing.Point(12, 454);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(105, 32);
            this.btnexit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnexit.TabIndex = 40;
            this.btnexit.Text = "بازگشت";
            this.btnexit.Click += new System.EventHandler(this.Btnexit_Click);
            // 
            // btnedit
            // 
            this.btnedit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnedit.BackColor = System.Drawing.Color.Transparent;
            this.btnedit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnedit.Image = ((System.Drawing.Image)(resources.GetObject("btnedit.Image")));
            this.btnedit.Location = new System.Drawing.Point(765, 454);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(105, 32);
            this.btnedit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnedit.TabIndex = 32;
            this.btnedit.Text = "ویرایش";
            this.btnedit.Click += new System.EventHandler(this.Btnedit_Click);
            // 
            // btndelete
            // 
            this.btndelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btndelete.BackColor = System.Drawing.Color.Transparent;
            this.btndelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btndelete.Image = ((System.Drawing.Image)(resources.GetObject("btndelete.Image")));
            this.btndelete.Location = new System.Drawing.Point(654, 454);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(105, 32);
            this.btndelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btndelete.TabIndex = 34;
            this.btndelete.Text = "حذف";
            this.btndelete.Click += new System.EventHandler(this.Btndelete_Click);
            // 
            // txtFirstnamesearch
            // 
            // 
            // 
            // 
            this.txtFirstnamesearch.Border.Class = "TextBoxBorder";
            this.txtFirstnamesearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFirstnamesearch.Location = new System.Drawing.Point(796, 12);
            this.txtFirstnamesearch.Name = "txtFirstnamesearch";
            this.txtFirstnamesearch.PreventEnterBeep = true;
            this.txtFirstnamesearch.Size = new System.Drawing.Size(123, 22);
            this.txtFirstnamesearch.TabIndex = 5;
            this.txtFirstnamesearch.WatermarkText = "نام";
            this.txtFirstnamesearch.TextChanged += new System.EventHandler(this.TxtFirstnamesearch_TextChanged);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(925, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(49, 23);
            this.labelX1.TabIndex = 33;
            this.labelX1.Text = "جستجو : ";
            // 
            // txtlastnamesearch
            // 
            // 
            // 
            // 
            this.txtlastnamesearch.Border.Class = "TextBoxBorder";
            this.txtlastnamesearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtlastnamesearch.Location = new System.Drawing.Point(667, 12);
            this.txtlastnamesearch.Name = "txtlastnamesearch";
            this.txtlastnamesearch.PreventEnterBeep = true;
            this.txtlastnamesearch.Size = new System.Drawing.Size(123, 22);
            this.txtlastnamesearch.TabIndex = 10;
            this.txtlastnamesearch.WatermarkText = "نام خانوادگی";
            this.txtlastnamesearch.TextChanged += new System.EventHandler(this.Txtlastnamesearch_TextChanged);
            // 
            // txtnationalcodesearch
            // 
            // 
            // 
            // 
            this.txtnationalcodesearch.Border.Class = "TextBoxBorder";
            this.txtnationalcodesearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtnationalcodesearch.Location = new System.Drawing.Point(538, 12);
            this.txtnationalcodesearch.Name = "txtnationalcodesearch";
            this.txtnationalcodesearch.PreventEnterBeep = true;
            this.txtnationalcodesearch.Size = new System.Drawing.Size(123, 22);
            this.txtnationalcodesearch.TabIndex = 15;
            this.txtnationalcodesearch.WatermarkText = "کد ملی";
            this.txtnationalcodesearch.TextChanged += new System.EventHandler(this.Txtnationalcodesearch_TextChanged);
            // 
            // txtfathername
            // 
            // 
            // 
            // 
            this.txtfathername.Border.Class = "TextBoxBorder";
            this.txtfathername.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtfathername.Location = new System.Drawing.Point(409, 12);
            this.txtfathername.Name = "txtfathername";
            this.txtfathername.PreventEnterBeep = true;
            this.txtfathername.Size = new System.Drawing.Size(123, 22);
            this.txtfathername.TabIndex = 20;
            this.txtfathername.WatermarkText = "نام پدر";
            this.txtfathername.TextChanged += new System.EventHandler(this.Txtfathername_TextChanged);
            // 
            // btnNwRef
            // 
            this.btnNwRef.AccessibleDescription = "";
            this.btnNwRef.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNwRef.BackColor = System.Drawing.Color.Transparent;
            this.btnNwRef.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNwRef.Image = ((System.Drawing.Image)(resources.GetObject("btnNwRef.Image")));
            this.btnNwRef.Location = new System.Drawing.Point(876, 454);
            this.btnNwRef.Name = "btnNwRef";
            this.btnNwRef.Size = new System.Drawing.Size(105, 32);
            this.btnNwRef.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNwRef.TabIndex = 30;
            this.btnNwRef.Text = "مراجعه جدید";
            this.btnNwRef.Click += new System.EventHandler(this.BtnNwRef_Click);
            // 
            // btnReport
            // 
            this.btnReport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReport.BackColor = System.Drawing.Color.Transparent;
            this.btnReport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.Location = new System.Drawing.Point(123, 454);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(105, 32);
            this.btnReport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnReport.TabIndex = 38;
            this.btnReport.Text = "گزارش";
            this.btnReport.Click += new System.EventHandler(this.BtnReport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(212, 15);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 40;
            this.label3.Text = "ماه :";
            // 
            // cmbmonth
            // 
            this.cmbmonth.DisplayMember = "Text";
            this.cmbmonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbmonth.FormattingEnabled = true;
            this.cmbmonth.ItemHeight = 17;
            this.cmbmonth.Items.AddRange(new object[] {
            this.Farvardin,
            this.Ordibeheasht,
            this.khordad,
            this.Tir,
            this.Mordad,
            this.shahrivar,
            this.Mehr,
            this.Aban,
            this.Azar,
            this.Dey,
            this.bahman,
            this.Esfand});
            this.cmbmonth.Location = new System.Drawing.Point(68, 12);
            this.cmbmonth.Name = "cmbmonth";
            this.cmbmonth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbmonth.Size = new System.Drawing.Size(136, 23);
            this.cmbmonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbmonth.TabIndex = 25;
            this.cmbmonth.SelectedValueChanged += new System.EventHandler(this.Cmbmonth_SelectedValueChanged);
            // 
            // Farvardin
            // 
            this.Farvardin.Text = "01 فروردین";
            this.Farvardin.Value = "1";
            // 
            // Ordibeheasht
            // 
            this.Ordibeheasht.Text = "02 اردیبهشت";
            this.Ordibeheasht.Value = "2";
            // 
            // khordad
            // 
            this.khordad.Text = "03 خرداد";
            this.khordad.Value = "3";
            // 
            // Tir
            // 
            this.Tir.Text = "04 تیر";
            this.Tir.Value = "4";
            // 
            // Mordad
            // 
            this.Mordad.Text = "05 مرداد";
            this.Mordad.Value = "5";
            // 
            // shahrivar
            // 
            this.shahrivar.Text = "06 شهریور";
            this.shahrivar.Value = "6";
            // 
            // Mehr
            // 
            this.Mehr.Text = "07 مهر";
            this.Mehr.Value = "7";
            // 
            // Aban
            // 
            this.Aban.Text = "08 آبان";
            this.Aban.Value = "8";
            // 
            // Azar
            // 
            this.Azar.Text = "09 آذر";
            this.Azar.Value = "9";
            // 
            // Dey
            // 
            this.Dey.Text = "10 دی";
            this.Dey.Value = "10";
            // 
            // bahman
            // 
            this.bahman.Text = "11 بهمن";
            this.bahman.Value = "11";
            // 
            // Esfand
            // 
            this.Esfand.Text = "12 اسفند";
            this.Esfand.Value = "12";
            // 
            // txtYear
            // 
            this.txtYear.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.txtYear.Location = new System.Drawing.Point(254, 12);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(39, 23);
            this.txtYear.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(286, 462);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 41;
            this.label1.Text = "تعداد :";
            // 
            // btn_filter
            // 
            this.btn_filter.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_filter.Location = new System.Drawing.Point(13, 12);
            this.btn_filter.Name = "btn_filter";
            this.btn_filter.Size = new System.Drawing.Size(49, 23);
            this.btn_filter.TabIndex = 27;
            this.btn_filter.Text = "فیلتر";
            this.btn_filter.UseVisualStyleBackColor = false;
            this.btn_filter.Click += new System.EventHandler(this.Btn_filter_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.BackColor = System.Drawing.Color.Transparent;
            this.lblCount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCount.Location = new System.Drawing.Point(245, 462);
            this.lblCount.Name = "lblCount";
            this.lblCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCount.Size = new System.Drawing.Size(43, 16);
            this.lblCount.TabIndex = 41;
            this.lblCount.Text = "تعداد :";
            // 
            // frmshowdata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 498);
            this.ControlBox = false;
            this.Controls.Add(this.btn_filter);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbmonth);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtfathername);
            this.Controls.Add(this.txtnationalcodesearch);
            this.Controls.Add(this.txtlastnamesearch);
            this.Controls.Add(this.txtFirstnamesearch);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnNwRef);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.dgvList);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmshowdata";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لیست بیماران";
            this.Load += new System.EventHandler(this.Frmshowdata_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgvList;
        private DevComponents.DotNetBar.ButtonX btnexit;
        private DevComponents.DotNetBar.ButtonX btnedit;
        private DevComponents.DotNetBar.ButtonX btndelete;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFirstnamesearch;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtlastnamesearch;
        private DevComponents.DotNetBar.Controls.TextBoxX txtnationalcodesearch;
        private DevComponents.DotNetBar.Controls.TextBoxX txtfathername;
        private DevComponents.DotNetBar.ButtonX btnNwRef;
        private DevComponents.DotNetBar.ButtonX btnReport;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbmonth;
        private DevComponents.Editors.ComboItem Farvardin;
        private DevComponents.Editors.ComboItem Ordibeheasht;
        private DevComponents.Editors.ComboItem khordad;
        private DevComponents.Editors.ComboItem Tir;
        private DevComponents.Editors.ComboItem Mordad;
        private DevComponents.Editors.ComboItem shahrivar;
        private DevComponents.Editors.ComboItem Mehr;
        private DevComponents.Editors.ComboItem Aban;
        private DevComponents.Editors.ComboItem Azar;
        private DevComponents.Editors.ComboItem Dey;
        private DevComponents.Editors.ComboItem bahman;
        private DevComponents.Editors.ComboItem Esfand;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_filter;
        private System.Windows.Forms.Label lblCount;
    }
}