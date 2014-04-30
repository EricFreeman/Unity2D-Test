using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    private float _money = 0;
    // Use this for initialization
    void Start()
    {
        //TODO: load money from player preferences
    }

    void OnGUI()
    {
        var groupWidth = 120;
        var groupHeight = 150;

        var screenWidth = Screen.width;
        var screenHeight = Screen.height;

        var groupX = (screenWidth - groupWidth) / 2;
        var groupY = (screenHeight - groupHeight) / 2;

        GUI.BeginGroup(new Rect(groupX, groupY, groupWidth, groupHeight));
        GUI.Box(new Rect(0, 0, groupWidth, groupHeight), "Upgrades");

        if (GUI.Button(new Rect(10, 30, 100, 30), "Guns++"))
        {
            //check if you have enough money, then add damage to player ship or something?
        }
        if (GUI.Button(new Rect(10, 30, 100, 30), "Damage++"))
        {
            //check if you have enough money, then add damage to player bullets?
        }

        GUI.EndGroup();
    }
}
