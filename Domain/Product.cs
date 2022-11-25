using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    class Product
    {
        public Guid Id { get; set; }
        public Guid Provider { get; set; }
        public string Name { get; set; }
    }
}
