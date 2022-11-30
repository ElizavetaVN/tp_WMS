using Domain.Common;

namespace Domain.Entities
{
    class Products : BaseEntity
    {
        public string Name { get; set; }
        public int ArticleNumber { get; set; }
        public string Provider { get; set; }
        public string Units { get; set; }
        public string Status { get; set; }
    }
}
