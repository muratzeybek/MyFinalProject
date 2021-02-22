using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    // Temel voidler başlangıç. Voidleri IResult yapısıyla süslicez. 
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }

    }
}
