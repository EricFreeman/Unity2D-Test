using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public float MaxSpeed = 5;

        public float MinX = -8;
        public float MinY = 0;
        public float MaxX = -2;
        public float MaxY = 8;

        public float Money;

        public bool IsAutoFire = true;

        // Update is called once per frame
        void Update()
        {
            // Move Player
            var xSpd = Input.GetAxisRaw("Horizontal");
            var ySpd = Input.GetAxisRaw("Vertical");

            transform.Translate(new Vector3(xSpd, ySpd, 0) * MaxSpeed * Time.deltaTime);
            if (transform.position.x < MinX) transform.Translate(MinX - transform.position.x, 0, 0);
            if (transform.position.x > MaxX) transform.Translate(MaxX - transform.position.x, 0, 0);
            if (transform.position.y < MinY) transform.Translate(0, MinY - transform.position.y, 0);
            if (transform.position.y > MaxY) transform.Translate(0, MaxY - transform.position.y, 0);

            // Fire all weapons attached to the player (uncomment this to turn off autofire)
            if (Input.GetKey(KeyCode.Space) || IsAutoFire)
                foreach (var w in GetComponentsInChildren<Weapon>())
                    w.Fire();
        }

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
}