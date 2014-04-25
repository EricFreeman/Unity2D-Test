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
            if(m != null) m.Speed = value;

            _speed = value;
        }
    }

    public float Spawn;
    private float _speed;

    public float Y
    {
        get { return transform.position.y; }
        set { transform.Translate(0, transform.position.y * -1 + value, 0); }
    }
}