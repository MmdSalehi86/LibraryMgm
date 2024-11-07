using System;
using System.Windows.Forms;

namespace LibraryMgm
{
    public partial class FrmORM : Form
    {
        public FrmORM()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (cmbORM.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا یک روش اتصال به پایگاه داده را انتخاب کنید");
                return;
            }
            else
            {
                //if (cmbORM.SelectedIndex == 0)
                    //Session.IsADO = true;
                //else
                    //Session.IsADO = false;
                new FrmMain().ShowDialog();
            }
        }
    }
}
