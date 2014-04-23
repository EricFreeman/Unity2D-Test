﻿using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage;
    public Vector3 Direction;
    public float Speed;
    public Transform Source;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Direction * Speed * Time.deltaTime);

        // TODO: find a better way to remove when out of camera sight
        if (transform.position.x < -10 || transform.position.x > 10)
            DestroyImmediate(gameObject);
        else if (transform.position.y < -1 || transform.position.y > 10)
            DestroyImmediate(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        var h = collider.GetComponent<Health>();
        if (h != null) h.CurrentHealth -= Damage;
    }
}
