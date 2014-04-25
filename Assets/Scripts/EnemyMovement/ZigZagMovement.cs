using UnityEngine;

namespace Assets.Scripts.EnemyMovement
{
    public class ZigZagMovement : MonoBehaviour, IMovement
    {
        public float Speed { get; set; }

        void Update()
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime
                + new Vector3(0, .25f * Mathf.Sin(10 * Time.time), 0));
        }
    }
}
