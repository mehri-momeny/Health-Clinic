namespace Patient_clinic.New_staff
{
    partial class frmReportNSTests
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportNSTests));
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cmbTest = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtNational_Code = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.radGvReport = new Telerik.WinControls.UI.RadGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPoint = new System.Windows.Forms.TextBox();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnexit = new DevComponents.DotNetBar.ButtonX();
            this.btnShow_Data = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.lbltotalPoint = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGvReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGvReport.MasterTemplate)).BeginInit();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.cmbTest);
            this.groupPanel1.Controls.Add(this.txtNational_Code);
            this.groupPanel1.Controls.Add(this.radGvReport);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.lbltotalPoint);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.txtPoint);
            this.groupPanel1.Controls.Add(this.groupPanel2);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(931, 494);
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
            this.groupPanel1.TabIndex = 40;
            // 
            // cmbTest
            // 
            this.cmbTest.DisplayMember = "Text";
            this.cmbTest.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTest.FormattingEnabled = true;
            this.cmbTest.ItemHeight = 17;
            this.cmbTest.Location = new System.Drawing.Point(107, 24);
            this.cmbTest.Name = "cmbTest";
            this.cmbTest.Size = new System.Drawing.Size(399, 23);
            this.cmbTest.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbTest.TabIndex = 46;
            this.cmbTest.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbTest_KeyDown);
            // 
            // txtNational_Code
            // 
            // 
            // 
            // 
            this.txtNational_Code.Border.Class = "TextBoxBorder";
            this.txtNational_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNational_Code.Location = new System.Drawing.Point(671, 24);
            this.txtNational_Code.Name = "txtNational_Code";
            this.txtNational_Code.PreventEnterBeep = true;
            this.txtNational_Code.Size = new System.Drawing.Size(147, 22);
            this.txtNational_Code.TabIndex = 45;
            this.txtNational_Code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNational_Code_KeyDown);
            this.txtNational_Code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNational_Code_KeyPress);
            // 
            // radGvReport
            // 
            this.radGvReport.Location = new System.Drawing.Point(10, 127);
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
            this.radGvReport.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.radGvReport.Name = "radGvReport";
            this.radGvReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radGvReport.Size = new System.Drawing.Size(906, 305);
            this.radGvReport.TabIndex = 40;
            this.radGvReport.ThemeName = "ControlDefault";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(511, 27);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 38;
            this.label3.Text = "آزمون :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(841, 66);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 38;
            this.label5.Text = "نمره : ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(826, 27);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 38;
            this.label1.Text = "کد ملی :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPoint
            // 
            this.txtPoint.Enabled = false;
            this.txtPoint.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.txtPoint.Location = new System.Drawing.Point(773, 63);
            this.txtPoint.Name = "txtPoint";
            this.txtPoint.Size = new System.Drawing.Size(45, 23);
            this.txtPoint.TabIndex = 42;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.btnexit);
            this.groupPanel2.Controls.Add(this.btnShow_Data);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(10, 438);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(912, 45);
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
            this.btnexit.Size = new System.Drawing.Size(103, 34);
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
            this.btnShow_Data.Location = new System.Drawing.Point(796, 2);
            this.btnShow_Data.Name = "btnShow_Data";
            this.btnShow_Data.Size = new System.Drawing.Size(103, 34);
            this.btnShow_Data.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnShow_Data.TabIndex = 35;
            this.btnShow_Data.Text = "نمایش ";
            this.btnShow_Data.Click += new System.EventHandler(this.BtnShow_Data_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(751, 66);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 38;
            this.label2.Text = "از";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbltotalPoint
            // 
            this.lbltotalPoint.AutoSize = true;
            this.lbltotalPoint.BackColor = System.Drawing.Color.Transparent;
            this.lbltotalPoint.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbltotalPoint.Location = new System.Drawing.Point(719, 66);
            this.lbltotalPoint.Name = "lbltotalPoint";
            this.lbltotalPoint.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbltotalPoint.Size = new System.Drawing.Size(20, 16);
            this.lbltotalPoint.TabIndex = 38;
            this.lbltotalPoint.Text = "...";
            this.lbltotalPoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(774, 105);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(120, 16);
            this.label4.TabIndex = 38;
            this.label4.Text = "پاسخ‌های اشتباه :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmReportNSTests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 494);
            this.Controls.Add(this.groupPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReportNSTests";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گزارش آزمون";
            this.Load += new System.EventHandler(this.FrmReportNSTests_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGvReport.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGvReport)).EndInit();
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private Telerik.WinControls.UI.RadGridView radGvReport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPoint;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX btnexit;
        private DevComponents.DotNetBar.ButtonX btnShow_Data;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNational_Code;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbTest;
        private System.Windows.Forms.Label lbltotalPoint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}