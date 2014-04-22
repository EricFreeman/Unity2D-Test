using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float Speed = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    transform.Translate(Vector3.left * Speed * Time.deltaTime);
	}
}
