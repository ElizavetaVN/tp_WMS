using Domain.Common;

namespace Domain.Entities
{
    public class Warehouses : BaseEntity
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public bool Status { get; set; }
    }
}
