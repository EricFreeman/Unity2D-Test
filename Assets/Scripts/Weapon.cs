using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int MaxDelay = 20;
    private int currentDelay;

    void Update()
    {
        currentDelay--;
    }

    public void Fire()
    {
        if (currentDelay < 0)
        {
            var b = (GameObject) Instantiate(Resources.Load("Prefabs/bullet"));
            b.transform.position = transform.GetChild(0).position;
            var bc = b.GetComponent<Bullet>();
            bc.Damage = 1;
            bc.Direction = -1*transform.rotation.z + (float) Math.PI/2;
            bc.Speed = 10f;
            bc.Source = transform.parent.transform;

            currentDelay = MaxDelay;
        }
    }
}