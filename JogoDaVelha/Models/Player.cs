using JogoDaVelha.Extensions;
using System.ComponentModel.DataAnnotations;

namespace JogoDaVelha.Models
{
    public class Player(string name)
    {
        public Guid Guid { get; init; } = Guid.NewGuid();

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "{0} must have length between {2} and {1}")]
        public string Name { get; init; } = name;
    }
}