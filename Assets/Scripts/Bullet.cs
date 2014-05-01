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

            transform.Translate((float) Math.Sin(Direction)*Speed*Time.deltaTime,
                (float) Math.Cos(Direction)*Speed*Time.deltaTime, 0);

            if (!renderer.isVisible)
                DestroyImmediate(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.transform == Source)
                return;

            var h = collider.GetComponent<Health>();
            if (h != null) h.CurrentHealth -= Damage;
            _toDestroyFlag = true;
        }
    }
}