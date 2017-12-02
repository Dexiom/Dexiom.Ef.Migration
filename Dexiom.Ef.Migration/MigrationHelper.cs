using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Dexiom.Ef.Migration
{
    public class MigrationHelper<TContext, TMigrationConfiguration>
        where TContext : DbContext
        where TMigrationConfiguration : DbMigrationsConfiguration<TContext>, new()
    {
        public void ConfigureInitializer(MigrationType migrationType)
        {
            switch (migrationType)
            {
                case MigrationType.None:
                    //nothing to do
                    break;

                case MigrationType.MigrateDatabaseToLatestVersion:
                    //apply migrations
                    Database.SetInitializer(new MigrateDatabaseToLatestVersion<TContext, TMigrationConfiguration>());
                    break;

                case MigrationType.DropCreateDatabaseAlways:
                    //drop and recreate the datebase
                    Database.SetInitializer(new DropCreateDatabaseAlways<TContext>()); 
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(migrationType), migrationType, null);
            }
        }
    }
}
