
using Assets.Application.Materials.Commands.CreateMaterial;
using AutoMapper;

namespace Assets.Application.Materials.DTO
{
    internal class MaterialProfile: Profile

    {
        public MaterialProfile()
        {
            CreateMap<CreateMaterialCommand, Material>();
            CreateMap<Material, MaterialDTO>();
        }
    }
}
