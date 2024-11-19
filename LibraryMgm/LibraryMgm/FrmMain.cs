using LibraryMgm.Model;
using System.Windows.Forms;

namespace LibraryMgm
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            cmbORM.SelectedIndex = 0;
        }

        private void btnAddTranslator_Click(object sender, System.EventArgs e)
        {
            new FrmTranslator().ShowDialog();
        }

        private void btnAddBook_Click(object sender, System.EventArgs e)
        {
            new FrmBook().ShowDialog();
        }

        private void cmbORM_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cmbORM.SelectedIndex == 0)
                DbConfiguration.ConnectionMethod = ConnectionMethods.ADO;
            else if (cmbORM.SelectedIndex == 1)
                DbConfiguration.ConnectionMethod = ConnectionMethods.EF;
        }
    }
}
