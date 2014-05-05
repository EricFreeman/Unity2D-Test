using UnityEngine;

public class CancelButton : MonoBehaviour
{
    public Transform Panel;

    void OnClick()
    {
        Panel.gameObject.SetActive(false);
    }
}
