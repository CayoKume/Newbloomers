using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace Domain.Core.Extensions
{
    public static class CustomConvertersExtensions
    {
        public static DateTime ConvertToDateTimeValidation<TEntity>(TEntity entity)
        {
            try
            {
                if (typeof(TEntity) == typeof(String))
                {
                    if (String.IsNullOrEmpty(entity?.ToString()) || !DateTime.TryParse(entity.ToString(), out var boolean))
                        return new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

                    return TimeZoneInfo.ConvertTimeFromUtc(Convert.ToDateTime(entity.ToString()).ToUniversalTime(), TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo"));
                }

                else if (typeof(TEntity) == typeof(DateTime))
                    return TimeZoneInfo.ConvertTimeFromUtc(Convert.ToDateTime(entity?.ToString()).ToUniversalTime(), TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo"));

                return new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Int32 ConvertToInt32Validation<TEntity>(TEntity entity)
        {
            try
            {
                if (typeof(TEntity) == typeof(String))
                {
                    if (String.IsNullOrEmpty(entity?.ToString()) || !Int32.TryParse(entity.ToString(), out var _bool))
                        return 0;

                    return Convert.ToInt32(entity.ToString());
                }

                else if (typeof(TEntity) == typeof(Int32))
                    return Convert.ToInt32(entity?.ToString());

                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Int64 ConvertToInt64Validation<TEntity>(TEntity entity)
        {
            try
            {
                if (typeof(TEntity) == typeof(String))
                {
                    if (String.IsNullOrEmpty(entity?.ToString()) || !Int64.TryParse(entity.ToString(), out var _bool))
                        return 0;

                    return Convert.ToInt64(entity.ToString());
                }

                else if (typeof(TEntity) == typeof(Int64))
                    return Convert.ToInt64(entity?.ToString());

                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static decimal ConvertToDecimalValidation<TEntity>(TEntity entity)
        {
            try
            {
                if (typeof(TEntity) == typeof(String))
                {
                    if (String.IsNullOrEmpty(entity?.ToString()) || !Decimal.TryParse(entity.ToString(), out var _bool))
                        return 0;

                    return Convert.ToDecimal(entity.ToString(), new CultureInfo("en-US"));
                }

                else if (typeof(TEntity) == typeof(decimal))
                    return Convert.ToDecimal(entity?.ToString(), new CultureInfo("en-US"));

                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Guid ConvertToGuidValidation<TEntity>(TEntity entity)
        {
            try
            {
                if (typeof(TEntity) == typeof(String))
                {
                    if (String.IsNullOrEmpty(entity?.ToString()) || !Guid.TryParse(entity.ToString(), out var _bool))
                        return new Guid();

                    return Guid.Parse(entity?.ToString());
                }

                else if (typeof(TEntity) == typeof(Guid))
                    return Guid.Parse(entity?.ToString());

                return new Guid();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool ConvertToBooleanValidation<TEntity>(TEntity entity)
        {
            try
            {
                if (typeof(TEntity) == typeof(String))
                {
                    if (String.IsNullOrEmpty(entity?.ToString()) || !Boolean.TryParse(entity.ToString(), out var _bool))
                        return false;
                    
                    return Convert.ToBoolean(entity?.ToString());
                }

                else if (typeof(TEntity) == typeof(Boolean))
                    return Convert.ToBoolean(entity?.ToString());

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
