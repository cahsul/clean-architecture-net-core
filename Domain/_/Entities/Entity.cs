using System;
using System.Collections.Generic;
using System.Text;

namespace Domain._.Entities
{
    /// <summary>
    /// sebagai kerangka dasar untuk semua enity<br/>
    /// sudah ada kolom ID sebagai primary key nya
    /// </summary>
    public abstract class Entity<T>
    {
        public T Id { get; set; }
    }
}
