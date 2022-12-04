using Domain.Common;

namespace Domain.Entities
{
    public class Products : BaseEntity
    {
        public string Name { get; set; }
        public int ArticleNumber { get; set; }
        public string Provider { get; set; }
        public int Units { get; set; }
        public string Status { get; set; }
    }
}
