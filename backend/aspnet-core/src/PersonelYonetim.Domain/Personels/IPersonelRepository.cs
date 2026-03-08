using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace PersonelYonetim.Personels
{
    public interface IPersonelRepository : IRepository<Personel, Guid>
    {
        Task<List<Personel>> GetListAsync(
            string? filterText = null,
            string? department = null,
            string? status = null,
            int maxResultCount = 10,
            int skipCount = 0
        );

        Task<int> GetCountAsync(
            string? filterText = null,
            string? department = null,
            string? status = null
        );
    }


}