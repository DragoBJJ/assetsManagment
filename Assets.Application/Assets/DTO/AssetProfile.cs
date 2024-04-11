using Assets.Application.Assets.DTO;
using Assets.Domain;
using AutoMapper;

public class AssetProfile: Profile

{

    public AssetProfile()
    {
        CreateMap<CreateAssetDTO, Asset>()
            .ForMember(d => d.Address, opt => opt.MapFrom(src => new Address
            {
                 City = src.City,
                 PostalCode = src.PostalCode,
                 Street = src.Street,
            }));

        CreateMap<Asset, AssetDTO>()
            .ForMember(d => d.City, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.City))
            .ForMember((d) => d.Street, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.Street))
            .ForMember((d) => d.PostalCode, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.PostalCode))
            .ForMember((d) => d.Materials, opt => opt.MapFrom(src => src.Materials));
    }

}
