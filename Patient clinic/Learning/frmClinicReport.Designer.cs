namespace Patient_clinic
{
    partial class frmClinicReport
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClinicReport));
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
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.radGvReport = new Telerik.WinControls.UI.RadGridView();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtTotalNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnexit = new DevComponents.DotNetBar.ButtonX();
            this.btnShow_Data = new DevComponents.DotNetBar.ButtonX();
            this.btnReport = new DevComponents.DotNetBar.ButtonX();
            this.btnExcel = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGvReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGvReport.MasterTemplate)).BeginInit();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbmonth
            // 
            this.cmbmonth.DisplayMember = "Text";
            this.cmbmonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbmonth.FormattingEnabled = true;
            this.cmbmonth.ItemHeight = 15;
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
            this.cmbmonth.Location = new System.Drawing.Point(214, 18);
            this.cmbmonth.Name = "cmbmonth";
            this.cmbmonth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbmonth.Size = new System.Drawing.Size(136, 21);
            this.cmbmonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbmonth.TabIndex = 37;
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
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.radGvReport);
            this.groupPanel1.Controls.Add(this.txtYear);
            this.groupPanel1.Controls.Add(this.txtTotalNum);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.cmbmonth);
            this.groupPanel1.Controls.Add(this.groupPanel2);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(535, 263);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 38;
            // 
            // radGvReport
            // 
            this.radGvReport.Location = new System.Drawing.Point(9, 90);
            // 
            // 
            // 
            this.radGvReport.MasterTemplate.AllowAddNewRow = false;
            this.radGvReport.MasterTemplate.AllowCellContextMenu = false;
            this.radGvReport.MasterTemplate.AllowColumnChooser = false;
            this.radGvReport.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.radGvReport.MasterTemplate.AllowDeleteRow = false;
            this.radGvReport.MasterTemplate.AllowDragToGroup = false;
            this.radGvReport.MasterTemplate.AllowEditRow = false;
            this.radGvReport.MasterTemplate.AllowRowHeaderContextMenu = false;
            this.radGvReport.MasterTemplate.AllowRowReorder = true;
            this.radGvReport.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGvReport.Name = "radGvReport";
            this.radGvReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radGvReport.Size = new System.Drawing.Size(511, 113);
            this.radGvReport.TabIndex = 40;
            this.radGvReport.ThemeName = "ControlDefault";
            // 
            // txtYear
            // 
            this.txtYear.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.txtYear.Location = new System.Drawing.Point(435, 18);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(39, 23);
            this.txtYear.TabIndex = 39;
            // 
            // txtTotalNum
            // 
            this.txtTotalNum.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.txtTotalNum.Location = new System.Drawing.Point(337, 55);
            this.txtTotalNum.Name = "txtTotalNum";
            this.txtTotalNum.Size = new System.Drawing.Size(67, 23);
            this.txtTotalNum.TabIndex = 39;
            this.txtTotalNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtTotalNum_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(410, 58);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(107, 16);
            this.label2.TabIndex = 38;
            this.label2.Text = "تعداد کل مراجعین:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(358, 21);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 38;
            this.label3.Text = "ماه :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(475, 21);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 38;
            this.label1.Text = "سال :";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.btnexit);
            this.groupPanel2.Controls.Add(this.btnShow_Data);
            this.groupPanel2.Controls.Add(this.btnReport);
            this.groupPanel2.Controls.Add(this.btnExcel);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(9, 209);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(511, 42);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 36;
            // 
            // btnexit
            // 
            this.btnexit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnexit.BackColor = System.Drawing.Color.Transparent;
            this.btnexit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnexit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnexit.Image = ((System.Drawing.Image)(resources.GetObject("btnexit.Image")));
            this.btnexit.Location = new System.Drawing.Point(3, 2);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(88, 32);
            this.btnexit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnexit.TabIndex = 37;
            this.btnexit.Text = "بازگشت";
            this.btnexit.Click += new System.EventHandler(this.Btnexit_Click);
            // 
            // btnShow_Data
            // 
            this.btnShow_Data.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnShow_Data.BackColor = System.Drawing.Color.Transparent;
            this.btnShow_Data.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnShow_Data.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnShow_Data.Image = global::Patient_clinic.Properties.Resources.thin_0244_text_bullets_list;
            this.btnShow_Data.Location = new System.Drawing.Point(414, 2);
            this.btnShow_Data.Name = "btnShow_Data";
            this.btnShow_Data.Size = new System.Drawing.Size(88, 32);
            this.btnShow_Data.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnShow_Data.TabIndex = 35;
            this.btnShow_Data.Text = "نمایش";
            this.btnShow_Data.Click += new System.EventHandler(this.BtnShow_Data_Click);
            // 
            // btnReport
            // 
            this.btnReport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReport.BackColor = System.Drawing.Color.Transparent;
            this.btnReport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReport.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.Location = new System.Drawing.Point(228, 2);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(88, 32);
            this.btnReport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnReport.TabIndex = 35;
            this.btnReport.Text = "گزارش";
            this.btnReport.Visible = false;
            this.btnReport.Click += new System.EventHandler(this.BtnReport_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExcel.BackColor = System.Drawing.Color.Transparent;
            this.btnExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExcel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.Location = new System.Drawing.Point(320, 2);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(88, 32);
            this.btnExcel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExcel.TabIndex = 36;
            this.btnExcel.Text = "خروجی اکسل";
            this.btnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // frmClinicReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 263);
            this.Controls.Add(this.groupPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClinicReport";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گزارش کلینیک سلامت";
            this.Load += new System.EventHandler(this.FrmReport_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGvReport.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGvReport)).EndInit();
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

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
        private DevComponents.DotNetBar.ButtonX btnReport;
        private DevComponents.DotNetBar.ButtonX btnExcel;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btnexit;
        private System.Windows.Forms.TextBox txtTotalNum;
        private Telerik.WinControls.UI.RadGridView radGvReport;
        private DevComponents.DotNetBar.ButtonX btnShow_Data;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label label3;
    }
}