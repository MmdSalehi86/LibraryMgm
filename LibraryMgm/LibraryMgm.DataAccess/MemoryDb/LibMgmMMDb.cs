using LibraryMgm.Model.Entities;
using System.Collections.Generic;

namespace LibraryMgm.DataAccess.MemoryDb
{
    public static class LibMgmMMDb
    {
        //

        public static bool HasChange { get; set; } = false;

        public static List<Book> Books { get; set; }
        public static List<Translator> Translators { get; set; }


        public static void InitialDb()
        {
            Books = new List<Book>();
            Translators = new List<Translator>();
        }
    }
}
