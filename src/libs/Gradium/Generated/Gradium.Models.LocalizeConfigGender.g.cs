
#nullable enable

namespace Gradium
{
    /// <summary>
    ///
    /// </summary>
    public enum LocalizeConfigGender
    {
        /// <summary>
        ///
        /// </summary>
        Female,
        /// <summary>
        ///
        /// </summary>
        Male,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class LocalizeConfigGenderExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this LocalizeConfigGender value)
        {
            return value switch
            {
                LocalizeConfigGender.Female => "female",
                LocalizeConfigGender.Male => "male",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static LocalizeConfigGender? ToEnum(string value)
        {
            return value switch
            {
                "female" => LocalizeConfigGender.Female,
                "male" => LocalizeConfigGender.Male,
                _ => null,
            };
        }
    }
}