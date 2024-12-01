using MMDb = LibraryMgm.DataAccess.MemoryDb.LibMgmMMDb;

namespace LibraryMgm.BLL
{
    public enum ConnectionMethods { ADO, EF, MemoryDb }
    public sealed class DbConfiguration
    {
        public static ConnectionMethods ConnectionMethod { get; set; }

        public static void InitialMemoryDb()
        {
            MMDb.InitialDb();
        }
    }
}
