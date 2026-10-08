
#nullable enable

namespace Gradium
{
    /// <summary>
    ///
    /// </summary>
    public enum LocalizeRequestGender
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
    public static class LocalizeRequestGenderExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this LocalizeRequestGender value)
        {
            return value switch
            {
                LocalizeRequestGender.Female => "female",
                LocalizeRequestGender.Male => "male",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static LocalizeRequestGender? ToEnum(string value)
        {
            return value switch
            {
                "female" => LocalizeRequestGender.Female,
                "male" => LocalizeRequestGender.Male,
                _ => null,
            };
        }
    }
}