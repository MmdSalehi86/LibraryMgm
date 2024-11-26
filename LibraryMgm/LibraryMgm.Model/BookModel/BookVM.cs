namespace LibraryMgm.Model.BookModel
{
    public sealed class BookVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public string Publisher { get; set; }

        public string TranslatorName { get; set; }
    }
}
