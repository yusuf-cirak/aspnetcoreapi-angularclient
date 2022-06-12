using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success,string message):this(success)
        { 
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }
        // success iki farklı ctor'da yani 2 farklı kullanımda da var. İki kez set etmek yerine this(success) şeklinde 
        public bool Success { get;}
        public string Message { get; }

    }
}
