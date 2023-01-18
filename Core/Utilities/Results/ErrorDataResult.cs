﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T>: DataResult<T>
    {
        public ErrorDataResult(T data, bool success, string message) : base(data, false, message)
        {
            
        }
        public ErrorDataResult(T data) : base(data, false)
        {

        }
        public ErrorDataResult(string message) : base(default,false,message)  //data döndermek isterse sadece mesaj verir
        {

        }
        public ErrorDataResult() : base(default, false)  //hiçbirşey döndermek istemeyebilir
        {

        }

    }
}
