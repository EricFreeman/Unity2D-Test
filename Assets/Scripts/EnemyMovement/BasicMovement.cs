using UnityEngine;

namespace Assets.Scripts.EnemyMovement
{
    public class BasicMovement : MonoBehaviour, IMovement
    {
        public float Speed { get; set; }

        void Update()
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }
    }
}
