using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Dexiom.Ef.Migration
{
    public static class MigrationHelper<TContext>
        where TContext : DbContext
    {
        public static void SetInitializer<TConfiguration>()
            where TConfiguration : IDatabaseInitializer<TContext>, new()
        {
            Database.SetInitializer(new TConfiguration());
        }

        #region MigrateDatabaseToLatestVersion
        public static void MigrateDatabaseToLatestVersion<TConfiguration>()
            where TConfiguration : DbMigrationsConfiguration<TContext>, new()
        {
            SetInitializer<MigrateDatabaseToLatestVersion<TContext, TConfiguration>>();
        }
        #endregion

        #region DropCreateDatabaseIfModelChanges
        public static void DropCreateDatabaseIfModelChanges()
        {
            SetInitializer<DropCreateDatabaseIfModelChanges<TContext>>();
        }

        public static void DropCreateDatabaseIfModelChanges<TConfiguration>()
            where TConfiguration : DropCreateDatabaseIfModelChanges<TContext>, new()
        {
            SetInitializer<TConfiguration>();
        }
        #endregion

        #region DropCreateDatabaseAlways
        public static void DropCreateDatabaseAlways()
        {
            SetInitializer<DropCreateDatabaseAlways<TContext>>();
        }

        public static void DropCreateDatabaseAlways<TConfiguration>()
            where TConfiguration : DropCreateDatabaseAlways<TContext>, new()
        {
            SetInitializer<TConfiguration>();
        }
        #endregion
    }
}
