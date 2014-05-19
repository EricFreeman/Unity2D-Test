using Assets.Scripts;
using UnityEngine;

public class Armor : MonoBehaviour
{
    public float ArmorAmount = 10;

    void Start()
    {
        var player = transform.parent;
        var health = player.GetComponent<Health>();
        if (health != null)
        {
            health.MaxHealth += ArmorAmount;
            health.CurrentHealth += ArmorAmount;
        }
    }
}