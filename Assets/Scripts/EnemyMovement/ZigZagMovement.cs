using UnityEngine;

namespace Assets.Scripts.EnemyMovement
{
    public class ZigZagMovement : MonoBehaviour, IMovement
    {
        public float Speed { get; set; }

        void Update()
        {
            transform.Translate(Vector3.down * Speed * Time.deltaTime
                + new Vector3(.25f * Mathf.Sin(10 * Time.time), 0, 0));
        }
    }
}
