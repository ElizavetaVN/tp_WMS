using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Units: BaseEntity
    {
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}