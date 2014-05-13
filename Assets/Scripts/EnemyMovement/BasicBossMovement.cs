using System;
using Assets.Scripts;
using Assets.Scripts.EnemyMovement;
using UnityEngine;

public class BasicBossMovement : MonoBehaviour, IMovement
{
    public float MoveToY = 15f;
    public float Speed { get; set; }
    public Transform Shield;

    private bool HasStartedMovement;
    private bool ShouldMoveRight;

    void Update()
    {
        if(transform.position.y > MoveToY)
            transform.Translate(0, -1 * Speed * Time.deltaTime, 0);
        else
        {
            if (!HasStartedMovement)
            {
                // Once you reach the correct y, start firing all weapons
                HasStartedMovement = true;
                Shield.gameObject.SetActive(false);
                foreach (var com in GetComponentsInChildren<Weapon>())
                    com.IsAutoFire = true;
            }
            else
            {
                // If you're already at the correct y, then start strafing side to side
                transform.Translate((ShouldMoveRight ? Vector3.right : Vector3.left) * Speed * Time.deltaTime);

                if (Math.Abs(transform.position.x) > 2) ShouldMoveRight = !ShouldMoveRight;
            }
        }
    }
}