using LibraryMgm.BLL;
using LibraryMgm.BLL.Services;
using LibraryMgm.Model.BookModel;
using LibraryMgm.Model.Entities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryMgm
{
    public partial class FrmBook : Form
    {
        int? id = null;

        public FrmBook()
        {
            InitializeComponent();

            dgv.AutoGenerateColumns = false;
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

            if (cmbTranslator.Items.Count > 0)
                btnAdd.Enabled = true;
            else
                btnAdd.Enabled = false;
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == colRowNum.Index)
                e.Value = e.RowIndex + 1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int year = txtYear.Text.TryToInt32();
            BookService bookServ = new BookService();

            OperationResult result;
            if (id.HasValue)
            {
                Book book = new Book()
                {
                    Id = id.Value,
                    Name = txtName.Text.Trim(),
                    Publisher = txtPublisher.Text.Trim(),
                    Year = txtYear.Text.TryToInt32(),
                    TranslatorId = cmbTranslator.SelectedValue.ToInt32()
                };
                result = bookServ.Update(book);
            }
            else
            {
                InsertBookModel model = new InsertBookModel()
                {
                    Name = txtName.Text.Trim(),
                    Publisher = txtPublisher.Text.Trim(),
                    Year = txtYear.Text.TryToInt32(),
                    TranslatorId = cmbTranslator.SelectedValue.ToInt32()
                };
                result = bookServ.Insert(model);


            }
            ShowToastMsg(result);
            if (result.ExcSucc && result.IsValid)
            {
                ClearInputs();
                FillDgv();
            }
        }

        private void ClearInputs()
        {
            txtName.Text = string.Empty;
            txtPublisher.Text = string.Empty;
            txtYear.Text = string.Empty;
            id = null;
            //cmbTranslator.SelectedIndex = -1;

            btnCancelUpdate.Visible = false;
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

        private void timerToast_Tick(object sender, EventArgs e)
        {
            timerToast.Stop();
            lblToast.Text = string.Empty;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var current = dgv.Rows[e.RowIndex];
                if (current != null)
                {
                    txtName.Text = current.Cells[colName.Index].Value.ToString();
                    txtYear.Text = current.Cells[colYear.Index].Value.ToString();
                    txtPublisher.Text = current.Cells[colPublisher.Index].Value.ToString();
                    cmbTranslator.Text = current.Cells[colTranslator.Index].Value.ToString();
                    id = current.Cells[colId.Index].Value.ToInt32();

                    btnCancelUpdate.Visible = true;
                }
            }
        }

        private void btnCancelUpdate_Click(object sender, EventArgs e) => ClearInputs();

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            var current = dgv.CurrentRow;

            if (current != null)
            {
                var msg = $"آیا از حذف {current.Cells[colName.Index].Value} مطمئن هستید؟";
                var result = MessageBox.Show(msg, "Delete from book", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2,
                    MessageBoxOptions.RtlReading);
                if (result == DialogResult.Yes)
                {
                    BookService bookServ = new BookService();
                    var opResult = bookServ.Delete(current.Cells[colId.Index].Value.ToInt32());
                    ShowToastMsg(opResult);
                    if (opResult.ExcSucc)
                        FillDgv();
                }
            }
        }
    }
}
