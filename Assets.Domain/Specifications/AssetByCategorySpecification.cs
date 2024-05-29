using Assets.Infrastructure.Specifications;

namespace Assets.Domain.Specifications
{
    public class AssetByCategorySpecification : Specification<Asset>
    {

        public AssetByCategorySpecification(string category): base(a=>  string.IsNullOrEmpty(category) || a.Category.Contains(category)) { 

            AddOrderBy(a=> a.Category);
        }
    }
}
