using System.Collections.Generic;
using UnityEngine;

public class Invincibility : MonoBehaviour
{
    // Used to designate parts of a boss as being invincible until other parts are destroyed
    public bool IsInvincible
    {
        get
        {
            return DestroyToTurnOff.Count != 0;
        }
    }

    public List<Transform> DestroyToTurnOff;
}