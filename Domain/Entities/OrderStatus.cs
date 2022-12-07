using Domain.Common;

namespace Domain.Entities
{
    public class OrderStatus : BaseEntity
    {
        public string Name { get; set; }
        public OrderType OrderType { get; set; }
        public bool Status { get; set; }
    }
}
