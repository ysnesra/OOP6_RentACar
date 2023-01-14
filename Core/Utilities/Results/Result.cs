using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message) : this(success)   //ekrana hem true/false hem message döndermek isteyebilirz
        {
            Message = message;
        }
        public Result(bool success)   //ekrana sadece true/false döndermek isteyebilirz
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
