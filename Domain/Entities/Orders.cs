using Domain.Common;
using System;

namespace Domain.Entities
{
    public class Orders : BaseEntity
    {
        public OrderType OrderType { get; set; }
        public DateTime Data { get; set; }
        public Partners Partners { get; set; }
        public Warehouses Warehouses { get; set; }
        public string Employee { get; set; }
        public Products Products { get; set; }
        public string Quantity { get; set; }
        public Units Units { get; set; }
        public string Comment { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public bool Status { get; set; }
    }
}
