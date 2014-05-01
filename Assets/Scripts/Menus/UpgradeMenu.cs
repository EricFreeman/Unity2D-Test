using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    private float _money = 0;

    private Vector2 _scrollPosition = Vector2.zero;

    void OnGUI()
    {
        var guiWidth = Screen.width;
        var guiHeight = 300;


        GUI.Box(new Rect(0, 0, guiWidth, guiHeight), "Buy");
        _scrollPosition = GUI.BeginScrollView(new Rect(0, 20, guiWidth, guiHeight -20), _scrollPosition, new Rect(0, 0, guiWidth - 20, guiHeight + 70));

        if (GUI.Button(new Rect(10, 30, 100, 30), "Gun1"))
        {
            //check if you have enough money, then add damage to player ship or something?
        }
        if (GUI.Button(new Rect(10, 60, 100, 30), "Gun2"))
        {
            //check if you have enough money, then add damage to player bullets?
        }
        if (GUI.Button(new Rect(10, 90, 100, 30), "Gun3")) { }
        if (GUI.Button(new Rect(10, 120, 100, 30), "Gun4")) { }
        if (GUI.Button(new Rect(10, 150, 100, 30), "Gun5")) { }
        if (GUI.Button(new Rect(10, 180, 100, 30), "Gun6")) { }

        GUI.EndScrollView();
    }
}
