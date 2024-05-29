using Assets.Infrastructure.Specifications;

namespace Assets.Domain.Specifications
{
    public class HouseAssetsSpecification: Specification<Asset>
    {

        public HouseAssetsSpecification(): base(a => a.Category == "House") 
        {
        
        }
    }
}
