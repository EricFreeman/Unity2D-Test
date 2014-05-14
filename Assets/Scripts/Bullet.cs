using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Bullet : MonoBehaviour
    {
        public float Damage;
        public float Direction;
        public float Speed;
        public Transform Source;

        private bool _toDestroyFlag;

        // Update is called once per frame
        private void Update()
        {
            if (_toDestroyFlag)
            {
                DestroyImmediate(gameObject);
                return;
            }

            transform.Translate((float)Math.Cos(Direction * Math.PI/180) * Speed * Time.deltaTime,
                (float)Math.Sin(Direction * Math.PI/180) * Speed * Time.deltaTime, 0);

            if (!renderer.isVisible)
                DestroyImmediate(gameObject);
        }

        public void Destroy()
        {
            _toDestroyFlag = true;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.transform == Source
                || (collider.transform.parent != null && collider.transform.parent.transform == Source) // will check for shields or battering rams since their parent would be the source
                || (Source != null && collider.tag == Source.tag)) // will make sure enemies can't shoot eachother!
                return;

            // Make sure the section of a boss isn't invincible right now
            var inv = collider.GetComponent<Invincibility>();
            if (inv != null && inv.IsInvincible) 
            {
                _toDestroyFlag = true;
                return;
            }

            var h = collider.GetComponent<Health>();
            if (h != null) h.CurrentHealth -= Damage;
            _toDestroyFlag = true;
        }
    }
}