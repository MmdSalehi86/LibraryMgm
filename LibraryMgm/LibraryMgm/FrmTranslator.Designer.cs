namespace LibraryMgm
{
    partial class FrmTranslator
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
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.labe3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblToast = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.ColRowNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.Location = new System.Drawing.Point(153, 24);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFirstName.Size = new System.Drawing.Size(153, 30);
            this.txtFirstName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(320, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "نام";
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.Location = new System.Drawing.Point(153, 58);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLastName.Size = new System.Drawing.Size(153, 30);
            this.txtLastName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "نام خانوادگی";
            // 
            // txtLocation
            // 
            this.txtLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocation.Location = new System.Drawing.Point(153, 92);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLocation.Size = new System.Drawing.Size(153, 30);
            this.txtLocation.TabIndex = 1;
            // 
            // labe3
            // 
            this.labe3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labe3.AutoSize = true;
            this.labe3.Location = new System.Drawing.Point(320, 99);
            this.labe3.Name = "labe3";
            this.labe3.Size = new System.Drawing.Size(88, 25);
            this.labe3.TabIndex = 2;
            this.labe3.Text = "محل زندگی";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(180, 147);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(157, 47);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "ثبت";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // lblToast
            // 
            this.lblToast.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToast.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToast.Location = new System.Drawing.Point(12, 213);
            this.lblToast.Name = "lblToast";
            this.lblToast.Size = new System.Drawing.Size(477, 32);
            this.lblToast.TabIndex = 2;
            this.lblToast.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColRowNum,
            this.colFullName,
            this.colLocation,
            this.ColId});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv.Location = new System.Drawing.Point(0, 263);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(501, 241);
            this.dgv.TabIndex = 5;
            this.dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_CellFormatting);
            // 
            // ColRowNum
            // 
            this.ColRowNum.HeaderText = "ردیف";
            this.ColRowNum.MinimumWidth = 100;
            this.ColRowNum.Name = "ColRowNum";
            this.ColRowNum.ReadOnly = true;
            this.ColRowNum.Width = 125;
            // 
            // colFullName
            // 
            this.colFullName.DataPropertyName = "FullName";
            this.colFullName.HeaderText = "نام کامل";
            this.colFullName.MinimumWidth = 6;
            this.colFullName.Name = "colFullName";
            this.colFullName.ReadOnly = true;
            this.colFullName.Width = 145;
            // 
            // colLocation
            // 
            this.colLocation.DataPropertyName = "Location";
            this.colLocation.HeaderText = "محل زندگی";
            this.colLocation.MinimumWidth = 6;
            this.colLocation.Name = "colLocation";
            this.colLocation.ReadOnly = true;
            this.colLocation.Width = 150;
            // 
            // ColId
            // 
            this.ColId.DataPropertyName = "Id";
            this.ColId.HeaderText = "Id";
            this.ColId.MinimumWidth = 6;
            this.ColId.Name = "ColId";
            this.ColId.ReadOnly = true;
            this.ColId.Visible = false;
            this.ColId.Width = 125;
            // 
            // FrmTranslator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(501, 504);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblToast);
            this.Controls.Add(this.labe3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmTranslator";
            this.Text = "FrmTranslator";
            this.Load += new System.EventHandler(this.FrmTranslator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label labe3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblToast;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRowNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
    }
}