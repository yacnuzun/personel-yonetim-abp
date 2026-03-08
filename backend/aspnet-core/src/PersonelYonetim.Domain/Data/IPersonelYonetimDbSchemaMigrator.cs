using System.Threading.Tasks;

namespace PersonelYonetim.Data;

public interface IPersonelYonetimDbSchemaMigrator
{
    Task MigrateAsync();
}
