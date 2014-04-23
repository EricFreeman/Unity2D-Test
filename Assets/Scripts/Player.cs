using UnityEngine;

public class Player : MonoBehaviour
{
    public float MaxSpeed = 5f;
    private float _currentSpeed;

    public float MinX = -8;
    public float MinY = 0;
    public float MaxX = -2;
    public float MaxY = 8;

    public float Money;

    // Use this for initialization
    void Start()
    {
        _currentSpeed = MaxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Money);

        var xSpd = Input.GetAxisRaw("Horizontal");
        var ySpd = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector3(xSpd, ySpd, 0) * _currentSpeed * Time.deltaTime);
        if (transform.position.x < MinX) transform.Translate(MinX - transform.position.x, 0, 0);
        if (transform.position.x > MaxX) transform.Translate(MaxX - transform.position.x, 0, 0);
        if (transform.position.y < MinY) transform.Translate(0, MinY - transform.position.y, 0);
        if (transform.position.y > MaxY) transform.Translate(0, MaxY - transform.position.y, 0);
        
        if (Input.GetKeyDown(KeyCode.Space))
            foreach (var w in GetComponentsInChildren<Weapon>())
            {
                w.Fire();   
            }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // bullets will handle damaging things on their own, this method is just for ramming things.
        if (collider.tag == "Bullet") return;

        GetComponent<Health>().CurrentHealth--;

        var h = collider.GetComponent<Health>();
        if (h != null) h.CurrentHealth--;
    }
}