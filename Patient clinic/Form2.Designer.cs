namespace Patient_clinic
{
    partial class Form2
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
            this.dgvHistories = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Had = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtnationalcodesearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtlastnamesearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtFirstnamesearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistories)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHistories
            // 
            this.dgvHistories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Had});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistories.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHistories.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvHistories.Location = new System.Drawing.Point(200, 79);
            this.dgvHistories.Name = "dgvHistories";
            this.dgvHistories.Size = new System.Drawing.Size(296, 104);
            this.dgvHistories.TabIndex = 57;
            this.dgvHistories.Visible = false;
            // 
            // Had
            // 
            this.Had.HeaderText = "دارد";
            this.Had.Name = "Had";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelX1.Location = new System.Drawing.Point(556, 214);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(49, 23);
            this.labelX1.TabIndex = 61;
            this.labelX1.Text = "جستجو : ";
            // 
            // txtnationalcodesearch
            // 
            // 
            // 
            // 
            this.txtnationalcodesearch.Border.Class = "TextBoxBorder";
            this.txtnationalcodesearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtnationalcodesearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtnationalcodesearch.Location = new System.Drawing.Point(427, 216);
            this.txtnationalcodesearch.Name = "txtnationalcodesearch";
            this.txtnationalcodesearch.PreventEnterBeep = true;
            this.txtnationalcodesearch.Size = new System.Drawing.Size(123, 21);
            this.txtnationalcodesearch.TabIndex = 58;
            this.txtnationalcodesearch.WatermarkText = "کد ملی";
            // 
            // txtlastnamesearch
            // 
            // 
            // 
            // 
            this.txtlastnamesearch.Border.Class = "TextBoxBorder";
            this.txtlastnamesearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtlastnamesearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtlastnamesearch.Location = new System.Drawing.Point(195, 216);
            this.txtlastnamesearch.Name = "txtlastnamesearch";
            this.txtlastnamesearch.PreventEnterBeep = true;
            this.txtlastnamesearch.Size = new System.Drawing.Size(123, 21);
            this.txtlastnamesearch.TabIndex = 59;
            this.txtlastnamesearch.WatermarkText = "نام خانوادگی";
            // 
            // txtFirstnamesearch
            // 
            // 
            // 
            // 
            this.txtFirstnamesearch.Border.Class = "TextBoxBorder";
            this.txtFirstnamesearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFirstnamesearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtFirstnamesearch.Location = new System.Drawing.Point(324, 216);
            this.txtFirstnamesearch.Name = "txtFirstnamesearch";
            this.txtFirstnamesearch.PreventEnterBeep = true;
            this.txtFirstnamesearch.Size = new System.Drawing.Size(97, 21);
            this.txtFirstnamesearch.TabIndex = 60;
            this.txtFirstnamesearch.WatermarkText = "نام";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtnationalcodesearch);
            this.Controls.Add(this.txtlastnamesearch);
            this.Controls.Add(this.txtFirstnamesearch);
            this.Controls.Add(this.dgvHistories);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistories)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgvHistories;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Had;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtnationalcodesearch;
        private DevComponents.DotNetBar.Controls.TextBoxX txtlastnamesearch;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFirstnamesearch;
    }
}