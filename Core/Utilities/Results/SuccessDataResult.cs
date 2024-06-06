using Core.Utilities.Results;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {

        }
        public SuccessDataResult(T data) : base(data, true)
        {

        }
        public SuccessDataResult(string mesage) : base(default,true,mesage)
        {

        }
        public SuccessDataResult() : base (default,true)
        {
            
        }
    }
}
