using LibraryMgm.BLL;
using LibraryMgm.Model.Entities;
using System;
using System.Windows.Forms;

namespace LibraryMgm
{
    public partial class FrmBook : Form
    {
        public FrmBook()
        {
            InitializeComponent();
        }

        private void FrmBook_Load(object sender, EventArgs e)
        {
            FillDgv();
            FillCmbTranslators();
        }


        private void FillDgv()
        {
            BookService bookServ = new BookService();
            var result = bookServ.Select();
            ShowToastMsg(result);

            if (result.ExcSucc)
                dgv.DataSource = result.Data;
        }

        private void ShowToastMsg(OperationResult op)
        {
            if (!op.ExcSucc)
                lblToast.Text = op.Message;
            else if (!op.IsValid)
                MessageBox.Show(op.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FillCmbTranslators()
        {
            TranslatorService trnServ = new TranslatorService();
            var result = trnServ.Select();

            ShowToastMsg(result);

            if (result.ExcSucc)
            {
                cmbTranslator.DataSource = result.Data;
                cmbTranslator.DisplayMember = "FullName";
                cmbTranslator.ValueMember = "Id";
            }
        }
    }
}
