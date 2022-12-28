using Domain.Common;
using System;

namespace Domain.Entities
{
    public class RegistrationWrite : BaseEntity//оприходование/списание
    {
        public RegistrationWriteType RegistrationWriteType { get; set; } 
        public Inventory Inventory { get; set; }
        public bool Status { get; set; }
        public Warehouses Warehouses { get; set; }
        public Products Products { get; set; }
        public string Quantity { get; set; }
        public Units Units { get; set; }
        public DateTime Data { get; set; }
        public string Employee { get; set; }
    }
}
