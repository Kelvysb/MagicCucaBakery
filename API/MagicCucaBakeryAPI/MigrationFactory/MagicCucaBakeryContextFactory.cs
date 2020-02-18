using MagicCucaBakery.DataAccess.Context;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MagicCucaBakery.API.MigrationFactory
{
    public class MagicCucaBakeryContextFactory : IDesignTimeDbContextFactory<MagicCucaBakeryContext>
    {
        public MagicCucaBakeryContext CreateDbContext(string[] args)
        {
            var resourceName = "appsettings.json";
            var config = new ConfigurationBuilder().AddJsonFile(resourceName).Build();
            return new MagicCucaBakeryContext(config);
        }
    }
}
