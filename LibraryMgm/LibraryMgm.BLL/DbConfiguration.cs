using MMDb = LibraryMgm.DataAccess.MemoryDb.LibMgmMMDb;

namespace LibraryMgm.BLL
{
    public sealed class DbConfiguration
    {
        public static void InitialMemoryDb()
        {
            MMDb.InitialDb();
        }
    }
}
