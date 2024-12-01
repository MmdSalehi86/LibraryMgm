using LibraryMgm.Model.BookModel;
using LibraryMgm.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LibraryMgm.DataAccess.EF
{
    public class BookRepoEF : IBookCRUD
    {
        LibMgmDataContext dbContext = null;
        public BookRepoEF()
        {
            dbContext = new LibMgmDataContext();
        }

        public bool CheckExists(string name, int? id)
        {
            var result = dbContext.Books
                .Where(b => b.Name.Equals(name));
            if (id.HasValue)
                result = result.Where(b => b.Id != id.Value);
            return result.Any();
        }

        public void Delete(int id)
        {
            var book = dbContext.Books.Where(b => b.Id == id).Single();
            dbContext.Books.Remove(book);
            dbContext.SaveChanges();
        }

        public void Insert(InsertBookModel model)
        {
            Translator translator = dbContext.Translators.Where(t => t.Id == model.TranslatorId).Single();

            Book book = new Book()
            {
                Name = model.Name,
                Publisher = model.Publisher,
                Year = model.Year,
                Translator = translator
                //TranslatorId = model.TranslatorId
            };
            dbContext.Books.Add(book);
            dbContext.SaveChanges();
        }

        public List<BookVM> Select()
        {
            var t = dbContext.Books.Select(
               book => new BookVM
               {
                   Id = book.Id,
                   Name = book.Name,
                   Publisher = book.Publisher,
                   Year = book.Year,
                   //TranslatorName = $"{book.Translator.FirstName} {book.Translator.LastName}"
                   TranslatorName = book.Translator.FirstName + " " + book.Translator.LastName
               }
           ).ToList();

            return t;
        }

        public void Update(Book model)
        {
            var book = dbContext.Books.Where(b => b.Id == model.Id).Single();
            book.Name = model.Name;
            book.Publisher = model.Publisher;
            book.Year = model.Year;
            book.TranslatorId = model.TranslatorId;
            dbContext.SaveChanges();
        }
    }
}
