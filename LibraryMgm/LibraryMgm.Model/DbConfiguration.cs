namespace LibraryMgm.Model
{
    public enum ConnectionMethods { ADO, EF }
    public sealed class DbConfiguration
    {
        public static ConnectionMethods ConnectionMethod { get; set; }
    }
}
