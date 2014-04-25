using UnityEngine;

namespace Assets.Scripts.EnemyMovement
{
    public class FindPlayerMovement : MonoBehaviour, IMovement
    {
        public float Speed { get; set; }

        void Update()
        {
            var p = GameObject.FindGameObjectWithTag("Player");
            if (p != null)
               transform.Translate(
                   Vector3.MoveTowards(
                        transform.position,
                        p.transform.position, 
                        Speed)); 
            else
                transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }
    }
}
