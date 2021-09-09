namespace Patient_clinic
{
    partial class frmReportRange
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportRange));
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnPath = new DevComponents.DotNetBar.ButtonX();
            this.btnConfirm = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.bpcalTo = new BPersianCalender.BPersianCalenderTextBox();
            this.bPCalFrom = new BPersianCalender.BPersianCalenderTextBox();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnPath);
            this.groupPanel1.Controls.Add(this.btnConfirm);
            this.groupPanel1.Controls.Add(this.btnCancel);
            this.groupPanel1.Controls.Add(this.txtPath);
            this.groupPanel1.Controls.Add(this.lblPath);
            this.groupPanel1.Controls.Add(this.lblTo);
            this.groupPanel1.Controls.Add(this.lblFrom);
            this.groupPanel1.Controls.Add(this.bpcalTo);
            this.groupPanel1.Controls.Add(this.bPCalFrom);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(288, 222);
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
            // btnPath
            // 
            this.btnPath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPath.BackColor = System.Drawing.Color.Transparent;
            this.btnPath.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPath.Location = new System.Drawing.Point(33, 120);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(25, 22);
            this.btnPath.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPath.TabIndex = 41;
            this.btnPath.Text = "...";
            this.btnPath.Click += new System.EventHandler(this.BtnPath_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirm.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConfirm.Image = global::Patient_clinic.Properties.Resources.thin_0100_to_do_list_reminder_done;
            this.btnConfirm.Location = new System.Drawing.Point(148, 173);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(105, 32);
            this.btnConfirm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnConfirm.TabIndex = 41;
            this.btnConfirm.Text = "تایید";
            this.btnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(29, 173);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 32);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 41;
            this.btnCancel.Text = "بازگشت";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(64, 117);
            this.txtPath.Multiline = true;
            this.txtPath.Name = "txtPath";
            this.txtPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPath.Size = new System.Drawing.Size(189, 27);
            this.txtPath.TabIndex = 14;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.BackColor = System.Drawing.Color.Transparent;
            this.lblPath.Location = new System.Drawing.Point(125, 96);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(131, 14);
            this.lblPath.TabIndex = 13;
            this.lblPath.Text = "مسیر ذخیره ‌سازی فایل‌:\r\n";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.BackColor = System.Drawing.Color.Transparent;
            this.lblTo.Location = new System.Drawing.Point(208, 62);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(48, 14);
            this.lblTo.TabIndex = 13;
            this.lblTo.Text = "تا تاریخ :";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.BackColor = System.Drawing.Color.Transparent;
            this.lblFrom.Location = new System.Drawing.Point(204, 23);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(52, 14);
            this.lblFrom.TabIndex = 12;
            this.lblFrom.Text = "از تاریخ : ";
            // 
            // bpcalTo
            // 
            this.bpcalTo.Location = new System.Drawing.Point(76, 58);
            this.bpcalTo.Miladi = new System.DateTime(((long)(0)));
            this.bpcalTo.Name = "bpcalTo";
            this.bpcalTo.NowDateSelected = false;
            this.bpcalTo.SelectedDate = null;
            this.bpcalTo.Shamsi = null;
            this.bpcalTo.Size = new System.Drawing.Size(98, 22);
            this.bpcalTo.TabIndex = 11;
            this.bpcalTo.Text = "  /  /";
            // 
            // bPCalFrom
            // 
            this.bPCalFrom.Location = new System.Drawing.Point(76, 19);
            this.bPCalFrom.Miladi = new System.DateTime(((long)(0)));
            this.bPCalFrom.Name = "bPCalFrom";
            this.bPCalFrom.NowDateSelected = false;
            this.bPCalFrom.SelectedDate = null;
            this.bPCalFrom.Shamsi = null;
            this.bPCalFrom.Size = new System.Drawing.Size(98, 22);
            this.bPCalFrom.TabIndex = 11;
            this.bPCalFrom.Text = "  /  /";
            // 
            // frmReportRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 222);
            this.Controls.Add(this.groupPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReportRange";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بازه گزارش‌گیری";
            this.Load += new System.EventHandler(this.FrmReportRange_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private BPersianCalender.BPersianCalenderTextBox bpcalTo;
        private BPersianCalender.BPersianCalenderTextBox bPCalFrom;
        private DevComponents.DotNetBar.ButtonX btnPath;
        private DevComponents.DotNetBar.ButtonX btnConfirm;
        private DevComponents.DotNetBar.ButtonX btnCancel;
    }
}