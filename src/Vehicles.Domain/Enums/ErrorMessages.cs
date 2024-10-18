using System.ComponentModel.DataAnnotations;

namespace Vehicles.Domain.Enums
{
    /// <summary>
    /// Enumeration containing specific error messages.
    /// </summary>
    public enum ErrorMessages
    {
        [Display(Name = "VehicleId cannot be null.")]
        VehicleIdCannotBeNull,

        [Display(Name = "Vehicle not found.")]
        VehicleNotFound,

        [Display(Name = "An unexpected error occurred.")]
        UnexpectedError
    }
}