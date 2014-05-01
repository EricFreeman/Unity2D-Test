namespace Assets.Scripts.Upgrades
{
    public class StoreItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public StoreCategory Category { get; set; }

        public StoreItem(string name, string description, float price, StoreCategory category)
        {
            Name = name;
            Description = description;
            Price = price;
            Category = category;
        }
    }
}
