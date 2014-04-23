using UnityEngine;

public class Weapon : MonoBehaviour
{
    public void Fire()
    {
        var b = (GameObject)Instantiate(Resources.Load("Prefabs/bullet"));
        b.transform.position = transform.position;
        var bc = b.GetComponent<Bullet>();
        bc.Damage = 1;
        bc.Direction = Vector3.right;
        bc.Speed = 10f;
        bc.Source = transform.parent.transform;
    }
}