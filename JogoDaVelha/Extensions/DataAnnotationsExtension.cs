using System.ComponentModel.DataAnnotations;

namespace JogoDaVelha.Extensions
{
    public static class DataAnnotationsExtension
    {
        public static IEnumerable<ValidationResult> GetValidationResults(this object obj)
        {
            var result = new List<ValidationResult>();
            Validator.TryValidateObject(obj, new ValidationContext(obj, null, null), result, true);
            return result;
        }
    }
}
