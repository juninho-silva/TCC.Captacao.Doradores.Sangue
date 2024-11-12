using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
    /// <summary>
    /// Blood Type Attribute
    /// </summary>
    /// <seealso cref="ValidationAttribute" />
    public class BloodTypeAttribute : ValidationAttribute
    {
        private static readonly string[] ValidTypes =
        {
            "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-"

        };

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The context information about the validation operation.</param>
        /// <returns>
        /// An instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationResult" /> class.
        /// </returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is null)
                return ValidationResult.Success;

            var type = value.ToString().ToUpper();

            if (ValidTypes.Contains(type))
                return ValidationResult.Success;

            return new ValidationResult($"Tipo sanguíneo inválido. Os valores válidos são: {string.Join(", ", ValidTypes)}");
        }
    }
}
