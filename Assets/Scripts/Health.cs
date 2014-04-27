using UnityEngine;

public class Health : MonoBehaviour
{
    public float MaxHealth;
    public float CurrentHealth;
	
	// Update is called once per frame
	void Update () {
	    if (CurrentHealth <= 0)
	    {
	        var e = GetComponent<Explodable>();
            if(e != null)
                e.Explode();
	    }
	}
}
