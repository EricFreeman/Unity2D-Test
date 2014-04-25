using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 5f;
    public float Spawn;
    public float Y
    {
        get { return transform.position.y; }
        set { transform.Translate(0, transform.position.y * -1 + value, 0); }
    }

    void Update()
    {
        transform.Translate(Vector3.left * Speed * Time.deltaTime);
    }
}