using LibraryMgm.Model.BookModel;
using LibraryMgm.Model.Entities;

namespace LibraryMgm.BLL
{
    public class BookService
    {
        public OperationResult Insert(InsertBookModel book)
        {
            return new OperationResult();
        }

        public OperationResult Update(Book book)
        {
            return new OperationResult();
        }

        public OperationResult Delete(int id)
        {
            return new OperationResult();
        }

        public OperationResult<BookVM> Select()
        {
            return new OperationResult<BookVM>();
        }
    }
}
