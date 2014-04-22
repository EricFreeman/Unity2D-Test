using UnityEngine;

public class DirectorScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var p = (GameObject)Instantiate(Resources.Load("Prefabs/enemy"));
        p.transform.Translate(10, 4, 0);
	}
	
	// Update is called once per frame
	void Update () {
        	
	}
}
