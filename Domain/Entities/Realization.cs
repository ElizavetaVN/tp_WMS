using Domain.Common;
using System;

namespace Domain.Entities
{
    public class Realization : BaseEntity
    {
        public RealizationType RealizationType { get; set; }
        public DateTime Data { get; set; }
        public Orders Order { get; set; }
        public int Partners { get; set; }
        public int Warehouses { get; set; }
        public int Products { get; set; }
        public string Quantity { get; set; }
        public int Units { get; set; }
        public string Employee { get; set; }
        public string Comment { get; set; }
    }
}
