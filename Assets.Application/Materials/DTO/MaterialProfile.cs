
using Assets.Application.Materials.Commands.CreateMaterial;
using Assets.Application.Materials.Commands.UpdateCommand;
using AutoMapper;

namespace Assets.Application.Materials.DTO
{
    internal class MaterialProfile: Profile

    {
        public MaterialProfile()
        {
            CreateMap<CreateMaterialCommand, Material>();
            CreateMap<UpdateMaterialCommand, Material>();
            CreateMap<Material, MaterialDTO>();
        }
    }
}
