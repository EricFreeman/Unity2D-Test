using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Invincibility : MonoBehaviour
{
    // Used to designate parts of a boss as being invincible until other parts are destroyed
    public bool IsInvincible
    {
        get { return DestroyToTurnOff.All(x => x != null); }
    }

    public List<Transform> DestroyToTurnOff;
}