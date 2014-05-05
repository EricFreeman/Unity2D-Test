using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public string LevelName;

    void Start()
    {
        var label = GetComponentInChildren<UILabel>();

        if(label != null)
            label.text = LevelName;
    }

    void OnCLick()
    {
        PlayerPrefs.SetString("SelectedLevel", LevelName);
    }
}