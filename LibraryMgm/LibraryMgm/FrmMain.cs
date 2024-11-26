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

        private void cmbORM_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cmbORM.SelectedIndex == 0)
                DbConfiguration.ConnectionMethod = ConnectionMethods.ADO;
            else if (cmbORM.SelectedIndex == 1)
                DbConfiguration.ConnectionMethod = ConnectionMethods.EF;
            else if (cmbORM.SelectedIndex == 2)
                DbConfiguration.ConnectionMethod = ConnectionMethods.MemoryDb;
        }

        private void btns_Click(dynamic sender, System.EventArgs e)
        {
            BLL.DbConfiguration.InitialMemoryDb();
            if (sender.Tag.ToString() == "book")
                new FrmBook().ShowDialog();
            else if (sender.Tag.ToString() == "trn")
                new FrmTranslator().ShowDialog();
        }
    }
}
