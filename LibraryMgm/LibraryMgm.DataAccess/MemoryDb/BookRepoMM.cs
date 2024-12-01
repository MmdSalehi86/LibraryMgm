using LibraryMgm.Model.BookModel;
using LibraryMgm.Model.Entities;
using System.Collections.Generic;
using System.Linq;
using MMDb = LibraryMgm.DataAccess.MemoryDb.LibMgmMMDb;

namespace LibraryMgm.DataAccess.MemoryDb
{
    public class BookRepoMM : IBookCRUD
    {
        public void Delete(int id)
        {
            MMDb.Books.Remove(MMDb.Books.Where(b => b.Id == id).Single());
            MMDb.HasChange = true;
        }

        public void Insert(InsertBookModel model)
        {
            int id = 1;
            var count = MMDb.Books.Count;
            if (count != 0)
                id = MMDb.Books[count - 1].Id + 1;

            Book book = new Book()
            {
                Id = id,
                Name = model.Name,
                Publisher = model.Publisher,
                Year = model.Year,
                TranslatorId = model.TranslatorId
            };
            MMDb.Books.Add(book);
            MMDb.HasChange = true;
        }

        public List<BookVM> Select()
        {
            return MMDb.Books.Select((book) =>
            {
                var trn = MMDb.Translators.Where(t => t.Id == book.TranslatorId).Single();
                return new BookVM
                {
                    Id = book.Id,
                    Name = book.Name,
                    Publisher = book.Publisher,
                    Year = book.Year,
                    TranslatorName = trn.FirstName + " " + trn.LastName
                };
            }).ToList();
        }

        public void Update(Book model)
        {
            var book = MMDb.Books.Where(b => b.Id == model.Id).Single();
            book.Name = model.Name;
            book.Publisher = model.Publisher;
            book.Year = model.Year;
            book.TranslatorId = model.TranslatorId;
            MMDb.HasChange = true;
        }

        public bool CheckExists(string name, int? id = null)
        {
            var result = MMDb.Books
                .Where(b => b.Name.Equals(name));
            if (id.HasValue)
                result.Where(b => b.Id != id.Value);
            return result.Any();
        }
    }
}
