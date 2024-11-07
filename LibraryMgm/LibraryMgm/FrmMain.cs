using System.Windows.Forms;

namespace LibraryMgm
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnAddTranslator_Click(object sender, System.EventArgs e)
        {
            new FrmTranslator().ShowDialog();
        }

        private void btnAddBook_Click(object sender, System.EventArgs e)
        {
            new FrmBook().ShowDialog();
        }
    }
}
