namespace LibraryMgm.Model
{
    public enum ConnectionMethods { ADO, EF, MemoryDb }
    public sealed class DbConfiguration
    {
        public static ConnectionMethods ConnectionMethod { get; set; }
    }
}
