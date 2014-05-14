using System.Linq;
using Assets.Scripts;
using UnityEngine;

public class MultiPartEnemeyExploder : MonoBehaviour
{
    public float Money;

    void Update()
    {
        //if every part of the boss is destroyed
        if (transform.childCount == 0 ||
            (transform.childCount == 1 && transform.GetChild(0).name == "Shield"))
        {
            var p = FindObjectOfType<Player>();
            if (p != null) p.Money += Money;

            DestroyImmediate(gameObject);
        }
    }
}
