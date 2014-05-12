using Assets.Scripts;
using UnityEngine;

public class RepairRobots : MonoBehaviour
{
    public float RepairAmount = .1f;

    void FixedUpdate()
    {
        transform.Rotate(0, 0, 100 * Time.deltaTime);

        var parent = transform.parent;
        var health = parent.GetComponent<Health>();
        if (health.CurrentHealth < health.MaxHealth)
            health.CurrentHealth += RepairAmount * Time.deltaTime;
    }
}