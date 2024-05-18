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
        public AssetType Category { get; set; } = default!;
        public int Space { get; set; } = default!;

        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        }
    }
