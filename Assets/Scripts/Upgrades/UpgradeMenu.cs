using System.Collections.Generic;
using System.Linq;
using Assets.Extensions;
using Assets.Scripts.Upgrades;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    private float _money = 0;
    private StoreCategory _selectedCategory = StoreCategory.Weapon;
    private List<StoreItem> _storeItems = new List<StoreItem>();

    private Vector2 _scrollPosition = Vector2.zero;

    void Start()
    {
        // load a bunch of temp store items
        _storeItems.Add(new StoreItem("Gun1", "Starter gun", 5, StoreCategory.Weapon));
        _storeItems.Add(new StoreItem("Gun2", "Okay gun", 25, StoreCategory.Weapon));
        _storeItems.Add(new StoreItem("Gun3", "Best gun", 250, StoreCategory.Weapon));
    }

    void OnGUI()
    {
        var guiWidth = Screen.width;
        var guiHeight = 200;
        var lineHeight = 30;
        var currentItems = _storeItems.Where(x => x.Category == _selectedCategory).ToList();

        GUI.Box(new Rect(0, 0, guiWidth, guiHeight), "Buy");

        _scrollPosition = GUI.BeginScrollView(
            new Rect(0, 20, guiWidth, guiHeight - 20),      // pos and size of viewer
            _scrollPosition,                                // current scroll pos
            new Rect(0, 0, guiWidth - 20, currentItems.Count() * lineHeight)); // size of section you can scroll

        var currentY = 0;
        foreach (var storeItem in currentItems)
        {
            if (GUI.Button(new Rect(10, currentY, 100, 30), "{0} - {1}".ToFormat(storeItem.Name, storeItem.Price)))
            {
                //check if you have enough money, then add damage to player ship or something?
            }

            currentY += lineHeight;
        }

        GUI.EndScrollView();
    }
}
