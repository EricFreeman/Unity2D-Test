using System.Collections.Generic;
using System.Linq;
using Assets.Extensions;
using Assets.Models;
using Assets.Scripts.Upgrades;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    private StoreCategory _selectedCategory = StoreCategory.Weapon;
    private List<Item> _storeItems = new List<Item>();
    private Player _currentPlayer { get; set; }

    private Vector2 _scrollPosition = Vector2.zero;

    void Start()
    {
        _storeItems.Add(new Item("Gun1", "Starter gun", 5, StoreCategory.Weapon));
        _storeItems.Add(new Item("Gun2", "Okay gun", 25, StoreCategory.Weapon));
        _storeItems.Add(new Item("Gun3", "Best gun", 250, StoreCategory.Weapon));

        _storeItems.Add(new Item("Armor1", "Starter armor", 5, StoreCategory.ShipUpgrade));
        _storeItems.Add(new Item("Armor2", "Okay armor", 25, StoreCategory.ShipUpgrade));
        _storeItems.Add(new Item("Armor3", "Best armor", 250, StoreCategory.ShipUpgrade));

        _currentPlayer = new Player
        {
            Money = 300
        };
    }

    void OnGUI()
    {
        var guiWidth = Screen.width;
        var guiHeight = 200;
        var lineHeight = 30;
        var currentItems = _storeItems.Where(x => x.Category == _selectedCategory).ToList();

        GUI.Box(new Rect(0, 0, guiWidth, guiHeight), "Buy");

        if (GUI.Button(new Rect(10, 20, 100, 30), "Weapon"))
            _selectedCategory = StoreCategory.Weapon;
        if (GUI.Button(new Rect(110, 20, 100, 30), "Ship Upgrade"))
            _selectedCategory = StoreCategory.ShipUpgrade;
        if (GUI.Button(new Rect(210, 20, 100, 30), "Ship"))
            _selectedCategory = StoreCategory.Ship;

        _scrollPosition = GUI.BeginScrollView(
            new Rect(0, 20, guiWidth, guiHeight - 20),                                      // pos and size of viewer
            _scrollPosition,                                                                // current scroll pos
            new Rect(0, 0, guiWidth - 20, currentItems.Count() * lineHeight + lineHeight)); // size of section you can scroll

        var currentY = 30;
        foreach (var storeItem in currentItems)
        {
            if (GUI.Button(new Rect(10, currentY, 100, 30), "{0} - {1}".ToFormat(storeItem.Name, storeItem.Price)))
            {
                if (_currentPlayer.Money > storeItem.Price)
                {
                    _currentPlayer.Money -= storeItem.Price;
                }
            }

            currentY += lineHeight;
        }

        GUI.EndScrollView();
    }
}
