using Assets.Scripts;
using UnityEngine;

public class BatteringRam : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collider)
    {
        // Bullets will handle damaging things on their own, this method is just for ramming things.
        if (collider.tag == "Bullet") return;

        // Decrease health of player
        GetComponent<Health>().CurrentHealth--;

        // Descrease health of whatever you collided with
        var h = collider.GetComponent<Health>();
        if (h != null) h.CurrentHealth--;
    }
}
