using UnityEngine;

namespace Assets.Scripts
{
    public class Health : MonoBehaviour
    {
        public float MaxHealth;
        public float CurrentHealth;

        // Update is called once per frame
        private void Update()
        {
            if (CurrentHealth <= 0)
            {
                var e = GetComponent<Explodable>();
                if (e != null)
                    e.Explode();
            }
        }
    }
}