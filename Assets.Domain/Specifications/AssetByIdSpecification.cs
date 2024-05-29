using Assets.Infrastructure.Specifications;

namespace Assets.Domain.Specifications
{
    public class AssetByIdSpecification : Specification<Asset>
    {

        public AssetByIdSpecification( int assetId): base(a => a.Id == assetId) 
        {

        }
    }
}
