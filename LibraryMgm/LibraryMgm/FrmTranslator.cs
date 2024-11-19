using LibraryMgm.BLL;
using System.Windows.Forms;

namespace LibraryMgm
{
    public partial class FrmTranslator : Form
    {
        public FrmTranslator()
        {
            InitializeComponent();

            dgv.AutoGenerateColumns = false;
        }

        private void FillDgv()
        {
            TranslatorService service = new TranslatorService();
            var result = service.Select();

            dgv.DataSource = result.Data;

            ShowToastMsg(result);
        }

        private void ShowToastMsg(OperationResult op)
        {
            if (!op.ExcSucc)
                lblToast.Text = op.Message;
            else if (!op.IsValid)
                MessageBox.Show(op.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FrmTranslator_Load(object sender, System.EventArgs e)
        {
            FillDgv();
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == ColRowNum.Index)
                e.Value = e.RowIndex + 1;
        }
    }
}
