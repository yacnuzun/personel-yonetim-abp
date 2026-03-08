using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace PersonelYonetim.Personels
{
    public class Personel : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public string Status { get; set; }
    }


}