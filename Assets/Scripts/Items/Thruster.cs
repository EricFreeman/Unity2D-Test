using Assets.Scripts;
using UnityEngine;

public class Thruster : MonoBehaviour
{
    public float ThrustAmount = 2;

    void Start()
    {
        var player = transform.parent.GetComponent<Player>();
        if (player != null) player.MaxSpeed += ThrustAmount;
    }
}
