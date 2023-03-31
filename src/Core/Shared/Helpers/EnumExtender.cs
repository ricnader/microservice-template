using System.ComponentModel;

namespace Shared.Helpers
{
    public static class EnumExtender
    {
        public static string? GetDescription(this Enum enumerator)
        {
            if (enumerator != null)
            {
                var type = enumerator.GetType();

                var memInfo = type.GetMember(enumerator.ToString());

                if (memInfo.Length > 0)
                {
                    var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                    if (attrs.Length > 0)
                    {
                        return ((DescriptionAttribute)attrs[0]).Description;
                    }
                }

                
            }

            return enumerator?.ToString();
        }

        public static bool TryParse<TEnum>(string value, out TEnum result) where TEnum : struct
        {
            if (string.IsNullOrWhiteSpace(value) ||
                !typeof(TEnum).IsEnum)
            {
                result = default;
                return false;
            }

            if (Enum.TryParse(value, out result))
                return Enum.IsDefined(typeof(TEnum), result);

            return false;
        }
    }
}
