using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    // Çıplak Class Kalmasın... Ç.C.K Standardı
    // Eğer ki bir class herhangi bir inheritance veya interface implementasyonu almıyorsa
    // ileride problem yaşama ihtimalin yüksek. Bu varlıklarımızı işaretleme eğilimine 
    // gruplama eğilimine gideriz. Deriz ki Concrete klasöründeki sınıflar, bir veritabanı 
    // tablosuna karşılık geliyor. 
    public class Category: IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
