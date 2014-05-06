using System.Collections.Generic;
using Assets.Scripts.Upgrades;

namespace Assets.Models
{
    public class PlayerModel
    {
        public List<Item> Inventory { get; set; }
        public List<Item> EquippedItems { get; set; } 
        public Ship Ship { get; set; }
        public float Money { get; set; }

        public PlayerModel() { }
    }
}
