using Domain.Common;
using System;

namespace Domain.Entities
{
    public class Internal : BaseEntity
    {
        public Warehouses Warehouses { get; set; }
        public Products Products { get; set; }
        public InternalStatus Status { get; set; }
        public InternalOperation Operation { get; set; }
        public int Number { get; set; }
        public string Quantity { get; set; }
        public DateTime Data { get; set; }
    }
}


