﻿using System.Collections.Generic;
using Assets.Scripts.Upgrades;

namespace Assets.Models
{
    public class Player
    {
        public List<Item> Inventory { get; set; }
        public Ship Ship { get; set; }
        public float Money { get; set; }
    }
}