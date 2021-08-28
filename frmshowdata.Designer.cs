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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmshowdata));
            this.dgvList = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnexit = new DevComponents.DotNetBar.ButtonX();
            this.btnedit = new DevComponents.DotNetBar.ButtonX();
            this.btndelete = new DevComponents.DotNetBar.ButtonX();
            this.txtFirstnamesearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtlastnamesearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtnationalcodesearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnExcel = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToOrderColumns = true;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvList.DefaultCellStyle = dataGridViewCellStyle1;
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
            this.btnexit.TabIndex = 31;
            this.btnexit.Text = "خروج";
            this.btnexit.Click += new System.EventHandler(this.Btnexit_Click);
            // 
            // btnedit
            // 
            this.btnedit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnedit.BackColor = System.Drawing.Color.Transparent;
            this.btnedit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnedit.Image = ((System.Drawing.Image)(resources.GetObject("btnedit.Image")));
            this.btnedit.Location = new System.Drawing.Point(871, 454);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(105, 32);
            this.btnedit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnedit.TabIndex = 30;
            this.btnedit.Text = "ویرایش";
            this.btnedit.Click += new System.EventHandler(this.Btnedit_Click);
            // 
            // btndelete
            // 
            this.btndelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btndelete.BackColor = System.Drawing.Color.Transparent;
            this.btndelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btndelete.Image = ((System.Drawing.Image)(resources.GetObject("btndelete.Image")));
            this.btndelete.Location = new System.Drawing.Point(760, 454);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(105, 32);
            this.btndelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btndelete.TabIndex = 30;
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
            this.txtFirstnamesearch.TabIndex = 32;
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
            this.txtlastnamesearch.TabIndex = 32;
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
            this.txtnationalcodesearch.TabIndex = 32;
            this.txtnationalcodesearch.WatermarkText = "کد ملی";
            this.txtnationalcodesearch.TextChanged += new System.EventHandler(this.Txtnationalcodesearch_TextChanged);
            // 
            // btnExcel
            // 
            this.btnExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExcel.BackColor = System.Drawing.Color.Transparent;
            this.btnExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExcel.Enabled = false;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.Location = new System.Drawing.Point(123, 454);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(105, 32);
            this.btnExcel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExcel.TabIndex = 30;
            this.btnExcel.Text = "خروجی اکسل";
            this.btnExcel.Visible = false;
            // 
            // frmshowdata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 498);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtnationalcodesearch);
            this.Controls.Add(this.txtlastnamesearch);
            this.Controls.Add(this.txtFirstnamesearch);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.dgvList);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmshowdata";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لیست بیماران";
            this.Load += new System.EventHandler(this.Frmshowdata_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

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
        private DevComponents.DotNetBar.ButtonX btnExcel;
    }
}