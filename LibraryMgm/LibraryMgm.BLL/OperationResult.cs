using System.Security.Policy;

namespace LibraryMgm.BLL
{
    public class OperationResult
    {
        public bool ExcSucc { get; set; }
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class OperationResult<T> : OperationResult
    {
        public T Data;
    }
}
