using LibraryMgm.Model.BookModel;
using LibraryMgm.Model.Entities;
using System.Collections.Generic;

namespace LibraryMgm.DataAccess
{
    public interface IBookCrud
    {
        void Insert(InsertBookModel model);
        List<BookVM> Select();
        void Update(Book model);
        void Delete(int id);
        bool CheckExists(string name, int? id);
    }
}
