using System.Collections.Generic;
using Assets.Scripts.Upgrades;

namespace Assets.Models
{
    public class Ship
    {
        public List<Item> EquippedItems { get; set; }

        public float MaxHealth { get; set; }
    }
}
