using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PersonelYonetim.Personels
{
    public class PersonelAppService : ApplicationService, IPersonelAppService
    {
        private readonly IPersonelRepository _personelRepository;
        private readonly PersonelManager _personelManager;

        public PersonelAppService(
            IPersonelRepository personelRepository,
            PersonelManager personelManager)
        {
            _personelRepository = personelRepository;
            _personelManager = personelManager;
        }

        public async Task<PersonelDto> GetAsync(Guid id)
        {
            var personel = await _personelRepository.GetAsync(id);
            return ObjectMapper.Map<Personel, PersonelDto>(personel);
        }

        public async Task<PagedResultDto<PersonelDto>> GetListAsync(GetPersonelListDto input)
        {
            var totalCount = await _personelRepository.GetCountAsync(
                filterText: input.FilterText,
                department: input.Department,
                status: input.Status
            );

            var items = await _personelRepository.GetListAsync(
                filterText: input.FilterText,
                department: input.Department,
                status: input.Status,
                maxResultCount: input.MaxResultCount,
                skipCount: input.SkipCount
            );

            return new PagedResultDto<PersonelDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Personel>, List<PersonelDto>>(items)
            };
        }

        public async Task<PersonelDto> CreateAsync(CreateUpdatePersonelDto input)
        {
            var personel = await _personelManager.CreateAsync(
                name: input.Name,
                surname: input.Surname,
                department: input.Department,
                position: input.Position,
                salary: input.Salary,
                hireDate: input.HireDate,
                status: input.Status
            );

            await _personelRepository.InsertAsync(personel);
            return ObjectMapper.Map<Personel, PersonelDto>(personel);
        }

        public async Task<PersonelDto> UpdateAsync(Guid id, CreateUpdatePersonelDto input)
        {
            var personel = await _personelRepository.GetAsync(id);

            await _personelManager.UpdateSalaryAsync(personel, input.Salary);

            personel.Name = input.Name;
            personel.Surname = input.Surname;
            personel.Department = input.Department;
            personel.Position = input.Position;
            personel.HireDate = input.HireDate;
            personel.Status = input.Status;

            await _personelRepository.UpdateAsync(personel);
            return ObjectMapper.Map<Personel, PersonelDto>(personel);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _personelRepository.DeleteAsync(id);
        }
    }

}