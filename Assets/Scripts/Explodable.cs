using UnityEngine;

public class Explodable : MonoBehaviour
{
    /// <summary>
    /// How much money the player gets when this object explodes
    /// </summary>
    public float Money;

    public void Explode()
    {
        var p = FindObjectOfType<Player>();
        if(p != null) p.Money += Money;

        Destroy(gameObject);

        //Maybe spawn some debris of a type that's passed in here?
    }
}
