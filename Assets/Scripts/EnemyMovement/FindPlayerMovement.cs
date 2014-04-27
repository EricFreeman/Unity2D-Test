using UnityEngine;

namespace Assets.Scripts.EnemyMovement
{
    public class FindPlayerMovement : MonoBehaviour, IMovement
    {
        public float Speed { get; set; }

        void Update()
        {
            var p = GameObject.FindGameObjectWithTag("Player");
            Debug.Log(transform.position);
            Debug.Log(p.transform.position);
            Debug.Log(Speed * Time.deltaTime);
            if (p != null)
               transform.position =
                   Vector3.MoveTowards(
                        transform.position,
                        p.transform.position, 
                        Speed * Time.deltaTime); 
            else
                transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }
    }
}
