using UnityEngine;

namespace Assets.Scripts
{
    public class Weapon : MonoBehaviour
    {
        public int MaxDelay = 20;
        public int Damage = 1;

        private int currentDelay;

        private void Update()
        {
            currentDelay--;
        }

        public void Fire()
        {
            if (currentDelay < 0)
            {
                var b = (GameObject) Instantiate(Resources.Load("Prefabs/bullet"));
                b.transform.position = transform.position;
                var bc = b.GetComponent<Bullet>();
                bc.Damage = Damage;
                bc.Direction = -1*transform.rotation.z;
                bc.Speed = 10f;
                bc.Source = transform.parent.parent.transform;

                currentDelay = MaxDelay;
            }
        }
    }
}