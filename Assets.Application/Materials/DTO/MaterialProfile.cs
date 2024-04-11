
using AutoMapper;

namespace Assets.Application.Materials.DTO
{
    internal class MaterialProfile: Profile

    {
        public MaterialProfile()
        {
            CreateMap<Material, MaterialDTO>();
        }
    }
}
