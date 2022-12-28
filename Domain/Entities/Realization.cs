using Domain.Common;
using System;

namespace Domain.Entities
{
    public class Realization : BaseEntity
    {
        public RealizationType RealizationType { get; set; }
        public DateTime Data { get; set; }
        public Orders Order { get; set; }
        public Partners Partners { get; set; }
        public Warehouses Warehouses { get; set; }
        public Products Products { get; set; }
        public string Quantity { get; set; }
        public Units Units { get; set; }
        public string Employee { get; set; }
        public string Comment { get; set; }
    }
}
