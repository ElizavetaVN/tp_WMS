using Domain.Common;
using System;

namespace Domain.Entities
{
    public class Moving : BaseEntity
    {
        public Warehouses WarehousesFrom { get; set; }
        public Warehouses WarehousesTo { get; set; }
        public Products Products { get; set; }
        public string Quantity { get; set; }
        public Units Units { get; set; }
        public DateTime Data { get; set; }
        public string Employee { get; set; }
    }
}
