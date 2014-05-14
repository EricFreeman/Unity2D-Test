using Assets.Managers;
using UnityEngine;

public class ResetGameButton : MonoBehaviour
{
    void OnClick()
    {
        PlayerManager.Reset();
    }
}