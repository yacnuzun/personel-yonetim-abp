using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace PersonelYonetim.Personels
{
    public class PersonelManager : DomainService
    {
        private readonly IPersonelRepository _personelRepository;

        public PersonelManager(IPersonelRepository personelRepository)
        {
            _personelRepository = personelRepository;
        }

        public async Task<Personel> CreateAsync(
            string name,
            string surname,
            string department,
            string position,
            decimal salary,
            DateTime hireDate,
            string status)
        {
            // İş kuralı: Aynı isim ve departmanda personel olamaz
            var existing = await _personelRepository.GetListAsync(
                filterText: name,
                department: department
            );

            if (existing.Any(p => p.Name == name && p.Surname == surname))
            {
                throw new BusinessException(PersonelYonetimDomainErrorCodes.PersonelAlreadyExists)
                    .WithData("name", name)
                    .WithData("surname", surname);
            }

            return new Personel
            {
                Name = name,
                Surname = surname,
                Department = department,
                Position = position,
                Salary = salary,
                HireDate = hireDate,
                Status = status
            };
        }

        public async Task UpdateSalaryAsync(Personel personel, decimal newSalary)
        {
            // İş kuralı: Maaş düşürülemez
            if (newSalary < personel.Salary)
            {
                throw new BusinessException(PersonelYonetimDomainErrorCodes.SalaryCannotBeDecreased)
                    .WithData("currentSalary", personel.Salary)
                    .WithData("newSalary", newSalary);
            }

            personel.Salary = newSalary;
        }
    }


}