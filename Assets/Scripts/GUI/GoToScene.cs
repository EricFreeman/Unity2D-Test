using UnityEngine;

public class GoToScene : MonoBehaviour
{
    public string SceneName;

    void OnClick()
    {
        Application.LoadLevel(SceneName);
    }
}
