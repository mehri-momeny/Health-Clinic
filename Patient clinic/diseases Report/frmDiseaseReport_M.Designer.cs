namespace Patient_clinic.diseases_Report
{
    partial class frmDiseaseReport_M
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiseaseReport_M));
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.RadGVDiseaseList = new Telerik.WinControls.UI.RadGridView();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnexit = new DevComponents.DotNetBar.ButtonX();
            this.btnShow_Data = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RadGVDiseaseList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadGVDiseaseList.MasterTemplate)).BeginInit();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.groupPanel2);
            this.groupPanel1.Controls.Add(this.txtYear);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.cmbmonth);
            this.groupPanel1.Controls.Add(this.RadGVDiseaseList);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(422, 454);
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
            this.groupPanel1.TabIndex = 0;
            // 
            // RadGVDiseaseList
            // 
            this.RadGVDiseaseList.Location = new System.Drawing.Point(28, 59);
            // 
            // 
            // 
            this.RadGVDiseaseList.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.RadGVDiseaseList.Name = "RadGVDiseaseList";
            this.RadGVDiseaseList.Size = new System.Drawing.Size(357, 338);
            this.RadGVDiseaseList.TabIndex = 0;
            // 
            // txtYear
            // 
            this.txtYear.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.txtYear.Location = new System.Drawing.Point(300, 30);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(39, 23);
            this.txtYear.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(223, 33);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 41;
            this.label3.Text = "ماه :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(340, 33);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 42;
            this.label1.Text = "سال :";
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
            this.cmbmonth.Location = new System.Drawing.Point(79, 30);
            this.cmbmonth.Name = "cmbmonth";
            this.cmbmonth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbmonth.Size = new System.Drawing.Size(136, 23);
            this.cmbmonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbmonth.TabIndex = 40;
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
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.btnexit);
            this.groupPanel2.Controls.Add(this.btnShow_Data);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(3, 403);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(410, 42);
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
            this.groupPanel2.TabIndex = 44;
            // 
            // btnexit
            // 
            this.btnexit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnexit.BackColor = System.Drawing.Color.Transparent;
            this.btnexit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnexit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnexit.Image = ((System.Drawing.Image)(resources.GetObject("btnexit.Image")));
            this.btnexit.Location = new System.Drawing.Point(3, 3);
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
            this.btnShow_Data.Location = new System.Drawing.Point(313, 3);
            this.btnShow_Data.Name = "btnShow_Data";
            this.btnShow_Data.Size = new System.Drawing.Size(88, 32);
            this.btnShow_Data.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnShow_Data.TabIndex = 35;
            this.btnShow_Data.Text = "نمایش";
            // 
            // frmDiseaseReport_M
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 454);
            this.Controls.Add(this.groupPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDiseaseReport_M";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "بیماری های شایع";
            this.Load += new System.EventHandler(this.FrmDiseaseReport_M_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RadGVDiseaseList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadGVDiseaseList)).EndInit();
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private Telerik.WinControls.UI.RadGridView RadGVDiseaseList;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
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
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX btnexit;
        private DevComponents.DotNetBar.ButtonX btnShow_Data;
    }
}