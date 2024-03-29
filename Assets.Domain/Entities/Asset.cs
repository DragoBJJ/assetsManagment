namespace Assets.Domain;

public class Asset
{
  public int Id { get; set; }
  public string Name { get; set; } = default!;
  public string Description { get; set; } = default!;
  public AssetType Category { get; set; } = default!;
  public Address? Address { get; set; } = default!;
  public List<Material> Materials { get; set; } = new();
  public bool IsSold { get; set; }
  public int Space { get; set; } = default!;

}
