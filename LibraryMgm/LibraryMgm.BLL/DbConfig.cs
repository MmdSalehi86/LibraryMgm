using MMDb = LibraryMgm.DataAccess.MemoryDb.LibMgmMMDb;

namespace LibraryMgm.BLL
{
    public enum ConnectionMethods { ADO, EF, MemoryDb }
    public sealed class DbConfig
    {
        public static ConnectionMethods ConnectionMethod { get; set; }

        public static void InitialMemoryDb()
        {
            MMDb.InitialDb();
        }
    }
}
