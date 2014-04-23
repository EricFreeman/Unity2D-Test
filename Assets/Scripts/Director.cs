using UnityEngine;

public class Director : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        #region Spawn test enemies (TODO: REMOVE THIS)

        //TODO: probs load this from a file but I'm lazy and want think about how to structure levels better later....
        var p = (GameObject)Instantiate(Resources.Load("Prefabs/enemy"));
        p.transform.Translate(10, 4, 0);

        p = (GameObject)Instantiate(Resources.Load("Prefabs/enemy"));
        p.transform.Translate(12, 4, 0);

        p = (GameObject)Instantiate(Resources.Load("Prefabs/enemy"));
        p.transform.Translate(14, 6, 0);

        p = (GameObject)Instantiate(Resources.Load("Prefabs/enemy"));
        p.transform.Translate(14, 2, 0);

        p = (GameObject)Instantiate(Resources.Load("Prefabs/enemy"));
        p.transform.Translate(18, 3, 0);

        p = (GameObject)Instantiate(Resources.Load("Prefabs/enemy"));
        p.transform.Translate(22, 6, 0);

        p = (GameObject)Instantiate(Resources.Load("Prefabs/enemy"));
        p.transform.Translate(23, 4, 0);

        p = (GameObject)Instantiate(Resources.Load("Prefabs/enemy"));
        p.transform.Translate(25, 4, 0);

        p = (GameObject)Instantiate(Resources.Load("Prefabs/enemy"));
        p.transform.Translate(27, 4, 0);

        p = (GameObject)Instantiate(Resources.Load("Prefabs/enemy"));
        p.transform.Translate(29, 4, 0);

        p = (GameObject)Instantiate(Resources.Load("Prefabs/enemy"));
        p.transform.Translate(31, 4, 0);

        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }
}
