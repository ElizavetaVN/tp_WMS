using Domain.Common;
using System;

namespace Domain.Entities
{
    public class Inventory : BaseEntity 
    {
        public DateTime Data { get; set; }
        public Products Products { get; set; }
        public string QuantityFact { get; set; }
        public string QuantityAcc { get; set; }
        public Units Units { get; set; }
        public Warehouses Warehouses { get; set; }
        public string Employee { get; set; }
    }
}
