using UnityEngine;

namespace Assets.Scripts
{
    public class Weapon : MonoBehaviour
    {
        public int MaxDelay = 20;
        public int Damage = 1;

        private int _currentDelay;

        public bool IsAutoFire;
        public bool IsDisabled;

        private void Update()
        {
            _currentDelay--;

            if (IsAutoFire) Fire();
        }

        public void Fire()
        {
            if (IsDisabled) return;
            if (_currentDelay < 0)
            {
                var b = (GameObject)Instantiate(Resources.Load("Prefabs/bullet"));
                b.transform.position = transform.position;
                var bc = b.GetComponent<Bullet>();
                bc.Damage = Damage;
                bc.Direction = -1 * (transform.rotation.eulerAngles.z - 90);
                bc.Speed = 10f;
                bc.Source = transform.parent.parent.transform;

                _currentDelay = MaxDelay;
            }
        }
    }
}