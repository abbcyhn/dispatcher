namespace Dispatcher.WebUI.Helpers
{
    using Models.Shared;
    using Entity.Abstract;
    using System.Collections.Generic;

    public static class ErrorCreator
    {
        public static ErrorResult GetError(this ARegister lr, int id, string msg)
        {
            var errorResult = new ErrorResult()
            {
                HasError = (lr != null && lr.Id != id),
                Message = msg
            };
            return errorResult;
        }

        public static ErrorResult CombineErrors(this List<ErrorResult> errorResults)
        {
            var errorResult = new ErrorResult();

            foreach (var er in errorResults)
            {
                if(er.HasError)
                {
                    errorResult.HasError = true;
                    errorResult.Message += $"{er.Message} ";
                }
            }

            return errorResult;
        }
    }
}