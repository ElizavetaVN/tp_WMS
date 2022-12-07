using Domain.Common;

namespace Domain.Entities
{
    public class Products : BaseEntity
    {
        public string Name { get; set; }
        public int ArticleNumber { get; set; }
        public Partners Provider { get; set; }
        public Units Units { get; set; }
        public bool Status { get; set; }
    }
}
