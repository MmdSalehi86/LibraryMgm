using LibraryMgm.Model.Entities;
using LibraryMgm.Model.Validations;
using System.Collections.Generic;

namespace LibraryMgm.DataAccess.MemoryDb
{
    public static class LibMgmMMDb
    {
        //

        public static bool HasChange { get; set; } = false;

        public static List<Book> Books { get; set; }
        public static List<Translator> Translators { get; set; }

        private static bool Initialized = false;
        public static void InitialDb()
        {
            if (Initialized)
                return;
            Books = new List<Book>();
            Translators = new List<Translator>();
            Initialized = true;
        }
    }
}
