using System.Threading.Tasks;

namespace GYM.Management.Data;

public interface IManagementDbSchemaMigrator
{
    Task MigrateAsync();
}
