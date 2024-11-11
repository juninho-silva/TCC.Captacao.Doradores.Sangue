using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
    /// <summary>
    /// Blood Type Attribute
    /// </summary>
    public class BloodTypeAttribute : ValidationAttribute
    {
        private static readonly string[] ValidTypes =
        {
            "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-"
        };

        /// <summary>
        /// is Valid
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
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
