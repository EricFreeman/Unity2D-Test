using Assets.Scripts.EnemyMovement;
using UnityEngine;

public class BasicBossMovement : MonoBehaviour, IMovement
{
    public float MoveToY = 15f;
    public float Speed { get; set; }

    void Update()
    {
        if(transform.position.y > MoveToY)
            transform.Translate(0, -1 * Speed * Time.deltaTime, 0);
    }
}