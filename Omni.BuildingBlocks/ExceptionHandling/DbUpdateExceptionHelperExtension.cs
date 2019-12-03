using Microsoft.EntityFrameworkCore;

namespace Omni.BuildingBlocks.ExceptionHandling
{
    public static class DbUpdateExceptionHelperExtension
    {
        public static string ExtractConstraints(this DbUpdateException exception)
        {
            var dataNameProperty = "ConstraintName";
            return Extract(exception, dataNameProperty);
        }

        public static string ExtractDetails(this DbUpdateException exception)
        {
            var dataNameProperty = "Detail";
            return Extract(exception, dataNameProperty);
        }

        private static string Extract(DbUpdateException exception, string dataNameProperty)
        {
            var dataExist = exception.InnerException?.Data.Contains(dataNameProperty);

            if (!dataExist.HasValue || !dataExist.Value)
            {
                return string.Empty;
            }

            var data = exception.InnerException?.Data[dataNameProperty];
            return data.ToString();
        }
    }
}
