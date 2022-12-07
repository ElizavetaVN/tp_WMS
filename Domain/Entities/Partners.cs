using Domain.Common;
namespace Domain.Entities
{
    public class Partners : BaseEntity
    {
        public string Name { get; set; }
        public int INN { get; set; }
        public int OGRN { get; set; }
        public int OKPO { get; set; }
        public int KPP { get; set; }
        //public string Comment { get; set; }
        public string LegalAddress { get; set; }
        public string ActuallAddress { get; set; }
        public string PostallAddress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
