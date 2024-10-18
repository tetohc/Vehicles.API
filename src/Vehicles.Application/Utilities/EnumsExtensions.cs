using System.ComponentModel.DataAnnotations;

namespace Vehicles.Application.Utilities
{
    /// <summary>
    /// Extension class for enumerations, providing additional methods.
    /// </summary>
    public static class EnumsExtensions
    {
        /// <summary>
        /// Retrieves the Display attribute text for a specific enum value.
        /// </summary>
        /// <param name="enumValue">The enum value.</param>
        /// <returns>The Display attribute text.</returns>
        public static string GetDisplayName(this Enum enumValue)
        {
            var displayAttribute = enumValue.GetType()
                .GetField(enumValue.ToString())
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .FirstOrDefault() as DisplayAttribute;

            return displayAttribute?.Name ?? enumValue.ToString();
        }
    }
}