namespace Assets.Scripts.Upgrades
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public StoreCategory Category { get; set; }

        public Item(string name, string description, float price, StoreCategory category)
        {
            Name = name;
            Description = description;
            Price = price;
            Category = category;
        }
    }
}
