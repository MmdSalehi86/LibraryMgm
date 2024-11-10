﻿using System.Security.Policy;

namespace LibraryMgm.BLL
{
    public class OperationResult
    {
        public bool ExcSucc { get; set; } = true;
        public bool IsValid { get; set; } = true;
        public string ErrorMessage { get; set; }
    }

    public class OperationResult<T> : OperationResult
    {
        public T Data;
    }
}
