namespace Assets.Scripts.Upgrades
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public ItemCategory Category { get; set; }

        public Item() { }

        public Item(string name, string description, float price, ItemCategory category)
        {
            Name = name;
            Description = description;
            Price = price;
            Category = category;
        }
    }
}
