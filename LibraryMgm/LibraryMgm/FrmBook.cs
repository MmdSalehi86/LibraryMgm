using LibraryMgm.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void FillDgv()
        {
            BookService bookServ = new BookService();
            var result = bookServ.Select();
            ShowToastMsg(result);
            dgv.DataSource = result.Data;
        }


        private void ShowToastMsg(OperationResult op)
        {
            if (!op.ExcSucc)
                lblToast.Text = op.Message;
            else if (!op.IsValid)
                MessageBox.Show(op.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
