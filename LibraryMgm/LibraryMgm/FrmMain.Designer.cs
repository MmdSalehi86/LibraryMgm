namespace LibraryMgm
{
    partial class FrmMain
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
            this.btnAddBook = new System.Windows.Forms.Button();
            this.btnAddTranslator = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbORM = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnAddBook
            // 
            this.btnAddBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBook.Location = new System.Drawing.Point(271, 157);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(132, 69);
            this.btnAddBook.TabIndex = 1;
            this.btnAddBook.Tag = "book";
            this.btnAddBook.Text = "کتاب ها";
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Click += new System.EventHandler(this.btns_Click);
            // 
            // btnAddTranslator
            // 
            this.btnAddTranslator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTranslator.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTranslator.Location = new System.Drawing.Point(111, 157);
            this.btnAddTranslator.Name = "btnAddTranslator";
            this.btnAddTranslator.Size = new System.Drawing.Size(132, 69);
            this.btnAddTranslator.TabIndex = 1;
            this.btnAddTranslator.Tag = "trn";
            this.btnAddTranslator.Text = "مترجمان";
            this.btnAddTranslator.UseVisualStyleBackColor = true;
            this.btnAddTranslator.Click += new System.EventHandler(this.btns_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "روش اتصال را انتخاب کنید";
            // 
            // cmbORM
            // 
            this.cmbORM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbORM.FormattingEnabled = true;
            this.cmbORM.Items.AddRange(new object[] {
            "ADO",
            "EF",
            "Memory Db"});
            this.cmbORM.Location = new System.Drawing.Point(146, 81);
            this.cmbORM.Name = "cmbORM";
            this.cmbORM.Size = new System.Drawing.Size(229, 30);
            this.cmbORM.TabIndex = 3;
            this.cmbORM.SelectedIndexChanged += new System.EventHandler(this.cmbORM_SelectedIndexChanged);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(514, 285);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbORM);
            this.Controls.Add(this.btnAddTranslator);
            this.Controls.Add(this.btnAddBook);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Button btnAddTranslator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbORM;
    }
}