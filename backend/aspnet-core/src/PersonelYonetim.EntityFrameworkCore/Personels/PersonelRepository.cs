using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonelYonetim.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace PersonelYonetim.Personels
{
    public class PersonelRepository : EfCoreRepository<PersonelYonetimDbContext, Personel, Guid>,
        IPersonelRepository
    {
        public PersonelRepository(
            IDbContextProvider<PersonelYonetimDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<Personel>> GetListAsync(
            string? filterText = null,
            string? department = null,
            string? status = null,
            int maxResultCount = 10,
            int skipCount = 0)
        {
            var dbContext = await GetDbContextAsync();

            return await dbContext.Personels
                .WhereIf(!filterText.IsNullOrWhiteSpace(),
                    p => p.Name.Contains(filterText!) ||
                         p.Surname.Contains(filterText!) ||
                         p.Position.Contains(filterText!))
                .WhereIf(!department.IsNullOrWhiteSpace(),
                    p => p.Department == department)
                .WhereIf(!status.IsNullOrWhiteSpace(),
                    p => p.Status == status)
                .OrderBy(p => p.Name)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }

        public async Task<int> GetCountAsync(
            string? filterText = null,
            string? department = null,
            string? status = null)
        {
            var dbContext = await GetDbContextAsync();

            return await dbContext.Personels
                .WhereIf(!filterText.IsNullOrWhiteSpace(),
                    p => p.Name.Contains(filterText!) ||
                         p.Surname.Contains(filterText!) ||
                         p.Position.Contains(filterText!))
                .WhereIf(!department.IsNullOrWhiteSpace(),
                    p => p.Department == department)
                .WhereIf(!status.IsNullOrWhiteSpace(),
                    p => p.Status == status)
                .CountAsync();
        }
    }
}