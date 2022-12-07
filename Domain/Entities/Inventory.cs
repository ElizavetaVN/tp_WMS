﻿using Domain.Common;
using System;

namespace Domain.Entities
{
    public class Inventory : BaseEntity 
    {
        public DateTime Data { get; set; }
        public Products Products { get; set; }
        public int QuantityFact { get; set; }
        public int QuantityAcc { get; set; }
        public int Units { get; set; }
        public Warehouses Warehouses { get; set; }
        public int Deviation { get; set; }
        public string Employee { get; set; }
    }
}