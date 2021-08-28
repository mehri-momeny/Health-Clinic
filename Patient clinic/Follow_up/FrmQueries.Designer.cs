namespace Patient_clinic
{
    partial class FrmQueries
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQueries));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.radtxtTurn = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radTextBox2 = new Telerik.WinControls.UI.RadTextBox();
            this.radTxtPatient = new Telerik.WinControls.UI.RadTextBox();
            this.btnexit = new DevComponents.DotNetBar.ButtonX();
            this.radGVQuestions = new Telerik.WinControls.UI.RadGridView();
            this.health_clinicDataSet = new Patient_clinic.Health_clinicDataSet();
            this.mIFollowUpQuestionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mI_FollowUp_QuestionsTableAdapter = new Patient_clinic.Health_clinicDataSetTableAdapters.MI_FollowUp_QuestionsTableAdapter();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radtxtTurn)).BeginInit();
            this.radtxtTurn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTxtPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGVQuestions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGVQuestions.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.health_clinicDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mIFollowUpQuestionsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.radLabel2);
            this.groupPanel1.Controls.Add(this.radLabel1);
            this.groupPanel1.Controls.Add(this.btnSave);
            this.groupPanel1.Controls.Add(this.radtxtTurn);
            this.groupPanel1.Controls.Add(this.radTxtPatient);
            this.groupPanel1.Controls.Add(this.btnexit);
            this.groupPanel1.Controls.Add(this.radGVQuestions);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(719, 602);
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
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(432, 26);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(70, 18);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "پیگیری شماره ";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(667, 26);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(37, 18);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.Text = "بیمار : ";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(599, 561);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 32);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 38;
            this.btnSave.Text = "ثبت";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // radtxtTurn
            // 
            this.radtxtTurn.Controls.Add(this.radLabel3);
            this.radtxtTurn.Controls.Add(this.radTextBox2);
            this.radtxtTurn.Enabled = false;
            this.radtxtTurn.Location = new System.Drawing.Point(399, 23);
            this.radtxtTurn.Name = "radtxtTurn";
            this.radtxtTurn.Size = new System.Drawing.Size(33, 24);
            this.radtxtTurn.TabIndex = 1;
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(29, 3);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(70, 18);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "پیگیری شماره ";
            this.radLabel3.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radTextBox2
            // 
            this.radTextBox2.Enabled = false;
            this.radTextBox2.Location = new System.Drawing.Point(105, 0);
            this.radTextBox2.Name = "radTextBox2";
            this.radTextBox2.Size = new System.Drawing.Size(153, 24);
            this.radTextBox2.TabIndex = 1;
            // 
            // radTxtPatient
            // 
            this.radTxtPatient.Enabled = false;
            this.radTxtPatient.Location = new System.Drawing.Point(508, 23);
            this.radTxtPatient.Name = "radTxtPatient";
            this.radTxtPatient.Size = new System.Drawing.Size(153, 24);
            this.radTxtPatient.TabIndex = 1;
            // 
            // btnexit
            // 
            this.btnexit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnexit.BackColor = System.Drawing.Color.Transparent;
            this.btnexit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnexit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnexit.Image = ((System.Drawing.Image)(resources.GetObject("btnexit.Image")));
            this.btnexit.Location = new System.Drawing.Point(9, 561);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(105, 32);
            this.btnexit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnexit.TabIndex = 37;
            this.btnexit.Text = "خروج";
            this.btnexit.Click += new System.EventHandler(this.Btnexit_Click);
            // 
            // radGVQuestions
            // 
            this.radGVQuestions.Location = new System.Drawing.Point(13, 50);
            // 
            // 
            // 
            this.radGVQuestions.MasterTemplate.AllowAddNewRow = false;
            this.radGVQuestions.MasterTemplate.AllowCellContextMenu = false;
            this.radGVQuestions.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.radGVQuestions.MasterTemplate.AllowColumnReorder = false;
            this.radGVQuestions.MasterTemplate.AllowDeleteRow = false;
            this.radGVQuestions.MasterTemplate.AllowDragToGroup = false;
            this.radGVQuestions.MasterTemplate.AllowRowHeaderContextMenu = false;
            this.radGVQuestions.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGVQuestions.Name = "radGVQuestions";
            this.radGVQuestions.Size = new System.Drawing.Size(691, 505);
            this.radGVQuestions.TabIndex = 0;
            this.radGVQuestions.ThemeName = "ControlDefault";
            // 
            // health_clinicDataSet
            // 
            this.health_clinicDataSet.DataSetName = "Health_clinicDataSet";
            this.health_clinicDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mIFollowUpQuestionsBindingSource
            // 
            this.mIFollowUpQuestionsBindingSource.DataMember = "MI_FollowUp_Questions";
            this.mIFollowUpQuestionsBindingSource.DataSource = this.health_clinicDataSet;
            // 
            // mI_FollowUp_QuestionsTableAdapter
            // 
            this.mI_FollowUp_QuestionsTableAdapter.ClearBeforeFill = true;
            // 
            // FrmQueries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 602);
            this.Controls.Add(this.groupPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQueries";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "پرسشنامه";
            this.Load += new System.EventHandler(this.FrmQueries_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radtxtTurn)).EndInit();
            this.radtxtTurn.ResumeLayout(false);
            this.radtxtTurn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTxtPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGVQuestions.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGVQuestions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.health_clinicDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mIFollowUpQuestionsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnexit;
        private Telerik.WinControls.UI.RadGridView radGVQuestions;
        private Telerik.WinControls.UI.RadTextBox radTxtPatient;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Health_clinicDataSet health_clinicDataSet;
        private System.Windows.Forms.BindingSource mIFollowUpQuestionsBindingSource;
        private Health_clinicDataSetTableAdapters.MI_FollowUp_QuestionsTableAdapter mI_FollowUp_QuestionsTableAdapter;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox radtxtTurn;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox radTextBox2;
    }
}