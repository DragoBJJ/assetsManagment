using System.ComponentModel.DataAnnotations;
using Assets.Domain;

namespace Assets.Application.Assets.DTO
{
    public class CreateAssetDTO
    {
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; } = default!;

        [StringLength(100, MinimumLength = 3)]
        public string Description { get; set; } = default!;

        [Required(ErrorMessage = "Insert a valid category")]
        public AssetType Category { get; set; } = default!;
        [Required(ErrorMessage = "Insert a valid space in meters")]
        public int Space { get; set; } = default!;

        public string? City { get; set; }
        public string? Street { get; set; }
        [RegularExpression(@"^\d{2}-\d{3}$", ErrorMessage = "Please provide a valid postal code (XX-XXX).")]
        public string? PostalCode { get; set; }
        }
    }
