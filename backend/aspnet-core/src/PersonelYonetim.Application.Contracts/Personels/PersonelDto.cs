using System;
using Volo.Abp.Application.Dtos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PersonelYonetim.Personels
{
    public class PersonelDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }

}