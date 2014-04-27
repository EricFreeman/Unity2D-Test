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
               transform.position =
                   Vector3.MoveTowards(
                        transform.position,
                        p.transform.position, 
                        Speed * Time.deltaTime); 
            else
                transform.Translate(Vector3.down * Speed * Time.deltaTime);
        }
    }
}
