using System.Collections.Generic;
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
}
