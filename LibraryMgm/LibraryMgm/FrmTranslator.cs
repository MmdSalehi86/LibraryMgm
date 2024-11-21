using LibraryMgm.BLL;
using LibraryMgm.Model.BookModel;
using LibraryMgm.Model.Entities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryMgm
{
    public partial class FrmTranslator : Form
    {
        int? id = null;

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

        private void FrmTranslator_Load(object sender, System.EventArgs e)
        {
            FillDgv();
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == ColRowNum.Index)
                e.Value = e.RowIndex + 1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string location = txtLocation.Text.Trim();
            TranslatorService trnServ = new TranslatorService();
            OperationResult result;

            if (id.HasValue)
            {
                Translator trn = new Translator()
                {
                    Id = id.Value,
                    FirstName = firstName,
                    LastName = lastName,
                    Location = location,
                };
                result = trnServ.Update(trn);
            }
            else
            {
                InsertTranslatorModel model = new InsertTranslatorModel()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Location = location
                };
                result = trnServ.Insert(model);
            }
            ShowToastMsg(result);
            if (result.ExcSucc && result.IsValid)
            {
                ClearInputs();
                FillDgv();
            }
        }

        private void btnCancelUpdate_Click(object sender, EventArgs e) => ClearInputs();

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var current = dgv.Rows[e.RowIndex];
                if (current != null)
                {
                    txtFirstName.Text = current.Cells[colFirstName.Index].Value.ToString();
                    txtLastName.Text = current.Cells[colLastName.Index].Value.ToString();
                    txtLocation.Text = current.Cells[colLocation.Index].Value.ToString();
                    id = current.Cells[colId.Index].Value.ToInt32();

                    btnCancelUpdate.Visible = true;
                }
            }
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            var current = dgv.CurrentRow;

            if (current != null)
            {
                var msg = $"آیا از حذف {current.Cells[colFullName.Index].Value} مطمئن هستید؟";
                var result = MessageBox.Show(msg, "Delete from translator", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2,
                    MessageBoxOptions.RtlReading);
                if (result == DialogResult.Yes)
                {
                    TranslatorService bookServ = new TranslatorService();
                    var opResult = bookServ.Delete(current.Cells[colId.Index].Value.ToInt32());
                    ShowToastMsg(opResult);
                    if (opResult.ExcSucc)
                        FillDgv();
                }
            }
        }


        private void timerToast_Tick(object sender, EventArgs e)
        {
            timerToast.Stop();
            lblToast.Text = string.Empty;
        }

        private void ShowToastMsg(OperationResult op)
        {
            if (!op.ExcSucc)
            {
                timerToast.Start();
                lblToast.ForeColor = Color.Red;
                lblToast.Text = op.Message;
            }
            else if (!op.IsValid)
                MessageBox.Show(op.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (!op.Message.IsNull())
            {
                lblToast.ForeColor = Color.Green;
                lblToast.Text = op.Message;
                timerToast.Start();
            }
        }

        private void ClearInputs()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtLocation.Text = string.Empty;
            id = null;

            btnCancelUpdate.Visible = false;
        }
    }
}
