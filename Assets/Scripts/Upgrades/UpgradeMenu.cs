using System.Collections.Generic;
using System.Linq;
using Assets.Models;
using Assets.Scripts.Upgrades;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    private ItemCategory _selectedCategory;
    private List<Item> _storeItems = new List<Item>();
    private Player _currentPlayer { get; set; }

    public GameObject UIParent;
    public GameObject ButtonPrefab;
    public GameObject SelectedPanel;

    void Start()
    {
        _storeItems.Add(new Item("Gun1", "Starter gun", 5, ItemCategory.Weapon));
        _storeItems.Add(new Item("Gun2", "Okay gun", 25, ItemCategory.Weapon));
        _storeItems.Add(new Item("Gun3", "Best gun", 250, ItemCategory.Weapon));
        _storeItems.Add(new Item("Gun4", "Best gun+", 2500, ItemCategory.Weapon));
        _storeItems.Add(new Item("Gun5", "Best gun++", 25000, ItemCategory.Weapon));

        _storeItems.Add(new Item("Armor1", "Starter armor", 5, ItemCategory.ShipUpgrade));
        _storeItems.Add(new Item("Armor2", "Okay armor", 25, ItemCategory.ShipUpgrade));
        _storeItems.Add(new Item("Armor3", "Best armor", 250, ItemCategory.ShipUpgrade));

        _currentPlayer = new Player
        {
            Money = 300,
            Inventory = new List<Item>()
        };

        ChangeStoreCategory(ItemCategory.Weapon);
    }

    void ClearCurrentItems()
    {
        foreach (Transform child in UIParent.transform)
        {
            if (child.name != "SelectedPanel")
                Destroy(child.gameObject);
        }
    }

    public void ChangeStoreCategory(ItemCategory category)
    {
        ClearCurrentItems();

        _selectedCategory = category;
        var categoryItems = _storeItems.Where(catItem => catItem.Category == _selectedCategory).ToList();

        var itemWidth = 100;
        var itemOffset = 5;
        var itemHeight = 40;

        int columns = 3;
        int xStart = (columns / 2)*(itemWidth + itemOffset) * -1;
        int startY = (categoryItems.Count / columns / 2) * (itemHeight + itemOffset) * -1;
        int yOffset = itemHeight * (_storeItems.Count / columns);

        int x = 0, y = 0;
        
        for(int i = 0; i < categoryItems.Count(); i++)
        {
            var item = categoryItems[i];
            var child = NGUITools.AddChild(UIParent, ButtonPrefab);
            child.transform.localPosition = new Vector3(
                xStart + x * (itemWidth + itemOffset),
                startY + y * (itemHeight + itemOffset) * -1 + yOffset,
                0);

            var s = child.GetComponent<StoreItem>();
            s.Item = item;

            x++;
            if (x == columns)
            {
                x = 0;
                y++;
            }
        }
    }

    public void Select(StoreItem item)
    {
        SelectedPanel.SetActive(true);
        SelectedPanel.GetComponent<SelectedItem>().SelectItem(item);
    }

    public void Buy(StoreItem item)
    {
        if (item.Item.Price <= _currentPlayer.Money)
        {
            _currentPlayer.Money -= item.Item.Price;
            _currentPlayer.Inventory.Add(item.Item);
        }
    }
}
