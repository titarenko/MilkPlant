using System.Data.Entity.Migrations;

namespace MilkPlant.EntityBackend.Infrastructure
{
    public class MigrationConfiguration : DbMigrationsConfiguration<DataContext>
    {
        public MigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}