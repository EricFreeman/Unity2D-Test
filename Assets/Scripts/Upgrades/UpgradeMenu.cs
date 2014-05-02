using System.Collections.Generic;
using Assets.Models;
using Assets.Scripts.Upgrades;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    private ItemCategory _selectedCategory = ItemCategory.Weapon;
    private List<Item> _storeItems = new List<Item>();
    private Player _currentPlayer { get; set; }

    public GameObject UIParent;
    public GameObject ButtonPrefab;

    void Start()
    {
        _storeItems.Add(new Item("Gun1", "Starter gun", 5, ItemCategory.Weapon));
        _storeItems.Add(new Item("Gun2", "Okay gun", 25, ItemCategory.Weapon));
        _storeItems.Add(new Item("Gun3", "Best gun", 250, ItemCategory.Weapon));

        _storeItems.Add(new Item("Armor1", "Starter armor", 5, ItemCategory.ShipUpgrade));
        _storeItems.Add(new Item("Armor2", "Okay armor", 25, ItemCategory.ShipUpgrade));
        _storeItems.Add(new Item("Armor3", "Best armor", 250, ItemCategory.ShipUpgrade));

        _currentPlayer = new Player
        {
            Money = 300
        };

        var itemWidth = 100;
        var itemHeight = 40;

        int x = -125, y = 250;

        foreach (var item in _storeItems)
        {
            var child = NGUITools.AddChild(UIParent, ButtonPrefab);
            child.transform.localPosition = new Vector3(x, y, 0);

            var s = child.GetComponent<StoreItem>();
            s.ItemName = item.Name;
            s.ItemDescription = item.Description;
            s.ItemPrice = item.Price;
            s.Category = item.Category;

            x += itemWidth + 5;

            if (x > 85)
            {
                x = -125;
                y -= itemHeight + 5;
            }
        }
    }
}
