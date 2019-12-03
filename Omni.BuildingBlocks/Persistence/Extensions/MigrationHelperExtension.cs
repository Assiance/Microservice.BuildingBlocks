using System;
using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Omni.BuildingBlocks.Persistence.Extensions
{
    public static class MigrationHelperExtension
    {
        private static string _migrationFolder = "Migrations";
        public static void ComposeSqlUp(this MigrationBuilder builder, Type executingType, string featureName)
        {
            var sqlString = ReadSqlFile(executingType, "Ups", featureName);
            builder.Sql(sqlString);
        }

        public static void ComposeSqlDown(this MigrationBuilder builder, Type executingType, string featureName)
        {
            var sqlString = ReadSqlFile(executingType, "Downs", featureName);
            builder.Sql(sqlString);
        }

        private static string ReadSqlFile(Type executingType, string migrationType, string featureName)
        {
            var myAttribute =
                (MigrationAttribute)Attribute.GetCustomAttribute(executingType, typeof(MigrationAttribute));

            var location = new Uri(Assembly.GetAssembly(executingType).GetName().CodeBase);
            var fileDirectoryInfo = new FileInfo(location.AbsolutePath).Directory;
            var path = $"{fileDirectoryInfo?.FullName}\\{featureName}\\{_migrationFolder}\\{migrationType}\\{myAttribute.Id}.sql";
            var fileExists = File.Exists(path);
            if (!fileExists)
            {
                throw new Exception($"File Was not found with path: {path}");
            }
            var fileString = File.ReadAllText(path);
            return fileString;
        }
    }
}
