﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        // Bana bir data bir de mesaj ver.
        // Ama base a (dataresult)a bu işlemin sonucu datadır. Sonucu true dur. Mesaj şudur de.
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {

        }

        // hiç mesaj olayına girmek istemiyorsa.
        public SuccessDataResult(T data) : base(data, true)
        {

        }

        // Çok az kullanacağımız bir versiyon. Sadece mesaj için...
        // 
        public SuccessDataResult(string message) : base(default, true, message)
        {

        }

        // Hiçbirşey vermek istemiyorum. Base e default datam budur. Mesaj vermiyorum. 
        public SuccessDataResult() : base(default, true)
        {

        }
    }
}
