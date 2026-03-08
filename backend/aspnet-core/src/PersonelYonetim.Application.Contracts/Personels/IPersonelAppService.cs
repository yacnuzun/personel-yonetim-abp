using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PersonelYonetim.Personels
{
    public interface IPersonelAppService : IApplicationService
    {
        Task<PersonelDto> GetAsync(Guid id);

        Task<PagedResultDto<PersonelDto>> GetListAsync(GetPersonelListDto input);

        Task<PersonelDto> CreateAsync(CreateUpdatePersonelDto input);

        Task<PersonelDto> UpdateAsync(Guid id, CreateUpdatePersonelDto input);

        Task DeleteAsync(Guid id);
    }

}