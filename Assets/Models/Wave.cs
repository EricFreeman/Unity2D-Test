using System.Collections.Generic;
using UnityEngine;

namespace Assets.Models
{
    public class Wave
    {
        public List<GameObject> EnemiesToSpawn { get; set; }
        public float BeforeWaveDelay { get; set; }
    }
}
