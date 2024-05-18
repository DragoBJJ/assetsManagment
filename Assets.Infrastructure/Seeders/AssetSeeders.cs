


using Assets.Domain;

namespace Assets.Infrastructure.Seeders
{
    internal class AssetSeeders(AssetsDbContext dbContext) : IAssetSeeders
    {

        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
            {

                if (!dbContext.Assets.Any())
                {
                    var assets = GetAssets();
                    dbContext.Assets.AddRange(assets);
                    await dbContext.SaveChangesAsync();
                }

            }
        }

        private IEnumerable<Asset> GetAssets()
        {

            List<Asset> assets = [
        new()
            {
                Name = "Drago House",
                Category = "House",
                Description =
                    "Modern house with beautiful interior, ideal for those who appreciate modernity and comfort. It is located in the prestigious neighborhood of Birch Meadow, offering peace and comfort.",
                IsSold = false,
                Materials =
                [
                    new ()
                    {
                        Name = "Brick",
                        Description = "Bricks are commonly used in construction due to their durability and strength. They provide good insulation and are fire-resistant.",
                        Price = 10.30M,
                        Origin = "United States"
                    },

                    new ()
                    {
                        Name = "Concrete",
                        Description = "Concrete is a versatile material used in various construction elements like foundations, walls, and floors. It offers strength and durability.",
                        Price = 5.30M,
                        Origin = "Poland"
                    },
                ],
                Address = new ()
                {
                    City = "London",
                    Street = "Cork St 5",
                    PostalCode = "10-100"
                }
            },
            new ()
            {
                Name = "Ivan Office",
                Category = "Office",
                Description =
                    "Spacious ground-floor office with a charming fireplace, ideal for families who value comfort and functionality. Situated in the picturesque Stefanów neighborhood, providing tranquility and proximity to nature.",
                IsSold = true,
                Materials = [
                    new() {
                        Name= "Steel",
                        Description = "Steel is commonly used for structural support in buildings. It offers high strength and is resistant to pests and fire.",
                        Price = 20.30M,
                        Origin = "China"
                    }
                    ],
                Address = new Address()
                {
                    City = "London",
                    Street = "Boots 193",
                    PostalCode = "10-100"
                }
            }
    ];

            return assets;
        }
    }
}
