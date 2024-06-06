﻿using Core.Utilities.Results;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        public ErrorDataResult(T data) : base(data, false)
        {

        }
        public ErrorDataResult(string mesage) : base(default, false, mesage)
        {

        }
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}