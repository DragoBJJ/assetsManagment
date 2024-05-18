using MediatR;

namespace Assets.Application.Assets.Commands.CreateAsset
{
    public class CreateAssetCommand: IRequest<int>
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public int Space { get; set; } = default!;

        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }

    }
}
