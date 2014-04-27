using Assets.Scripts.EnemyMovement;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed
    {
        get { return _speed; }
        set
        {
            var m = (IMovement)gameObject.GetComponent(typeof(IMovement));
            if (m != null) m.Speed = value;

            _speed = value;
        }
    }

    public float Spawn;
    private float _speed;

    public float X
    {
        get { return transform.position.x; }
        set { transform.Translate(transform.position.x * -1 + value, 0, 0); }
    }

    void Update()
    {
        // TODO: Probably should do this better..?
        if(transform.position.y < -2)
            DestroyImmediate(gameObject);
    }
}