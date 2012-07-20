using System.Data.Entity.Migrations;

namespace MilkPlant.EntityBackend
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