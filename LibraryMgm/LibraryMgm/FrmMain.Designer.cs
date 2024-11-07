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
            this.btnBookLoan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddBook
            // 
            this.btnAddBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBook.Location = new System.Drawing.Point(255, 48);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(132, 69);
            this.btnAddBook.TabIndex = 1;
            this.btnAddBook.Text = "ثبت کتاب";
            this.btnAddBook.UseVisualStyleBackColor = true;
            // 
            // btnAddTranslator
            // 
            this.btnAddTranslator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTranslator.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTranslator.Location = new System.Drawing.Point(95, 48);
            this.btnAddTranslator.Name = "btnAddTranslator";
            this.btnAddTranslator.Size = new System.Drawing.Size(132, 69);
            this.btnAddTranslator.TabIndex = 1;
            this.btnAddTranslator.Text = "ثبت مترجم";
            this.btnAddTranslator.UseVisualStyleBackColor = true;
            // 
            // btnBookLoan
            // 
            this.btnBookLoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBookLoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookLoan.Location = new System.Drawing.Point(414, 48);
            this.btnBookLoan.Name = "btnBookLoan";
            this.btnBookLoan.Size = new System.Drawing.Size(132, 69);
            this.btnBookLoan.TabIndex = 1;
            this.btnBookLoan.Text = "ثبت امانت";
            this.btnBookLoan.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(641, 176);
            this.Controls.Add(this.btnBookLoan);
            this.Controls.Add(this.btnAddTranslator);
            this.Controls.Add(this.btnAddBook);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form Main";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Button btnAddTranslator;
        private System.Windows.Forms.Button btnBookLoan;
    }
}