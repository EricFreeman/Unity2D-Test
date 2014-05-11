using System.Collections.Generic;
using System.Linq;
using Assets.Managers;
using Assets.Models;
using Assets.Scripts.Upgrades;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    private ItemCategory _selectedCategory;
    private List<Item> _storeItems = new List<Item>();
    private PlayerModel _currentPlayer { get; set; }

    private float _money;
    public float Money
    {
        get { return _money; }
        set
        {
            _money = value;
            GameObject.Find("CredsLabel").GetComponent<UILabel>().text = value.ToString("c");
            _currentPlayer.Money = value;
        }
    }

    public GameObject UIParent;
    public GameObject ButtonPrefab;
    public GameObject SelectedPanel;

    void Start()
    {
        #region TODO: Load this stuff from files

        _storeItems.Add(new Item("BB Gun", "Unless you're hunting tin cans in space, this weapon is pretty useless.", 5, ItemCategory.Weapon));
        _storeItems.Add(new Item("Machine Gun", "Better than a BB Gun, but you still won't be doing a lot of damage out there.", 25, ItemCategory.Weapon));
        _storeItems.Add(new Item("Laser Beams", "Pew pew pew!", 250, ItemCategory.Weapon));
        _storeItems.Add(new Item("Plasma Cannon", "PEW PEW PEW!!", 2500, ItemCategory.Weapon));
        _storeItems.Add(new Item("BFG 9000", "PEEEEEEEEEEEEEEEEEEEEEEEEEW!!!", 25000, ItemCategory.Weapon));

        _storeItems.Add(new Item("Ship1", "Starter Ship", 5, ItemCategory.Ship));
        _storeItems.Add(new Item("Ship2", "Okay Ship", 25, ItemCategory.Ship));
        _storeItems.Add(new Item("Ship3", "Best Ship", 250, ItemCategory.Ship));
        _storeItems.Add(new Item("Ship4", "Best Ship+", 2500, ItemCategory.Ship));
        _storeItems.Add(new Item("Ship5", "Best Ship++", 25000, ItemCategory.Ship));
        _storeItems.Add(new Item("Ship6", "Best Ship+++", 250000, ItemCategory.Ship));
        _storeItems.Add(new Item("Ship7", "Best Ship++++", 2500000, ItemCategory.Ship));
        _storeItems.Add(new Item("Ship8", "Best Ship+++++", 25000000, ItemCategory.Ship));
        _storeItems.Add(new Item("Ship9", "Best Ship++++++", 250000000, ItemCategory.Ship));
        _storeItems.Add(new Item("Ship10", "Warren Buffet used this ship when he conquered Earth in 3057.", 2500000000, ItemCategory.Ship));

        _storeItems.Add(new Item("Armor 1", "Starter armor", 5, ItemCategory.ShipUpgrade));
        _storeItems.Add(new Item("Armor 2", "Okay armor", 25, ItemCategory.ShipUpgrade));
        _storeItems.Add(new Item("Armor 3", "Best armor", 250, ItemCategory.ShipUpgrade));
        _storeItems.Add(new Item("Repair Robots", "Floating micro robots that will slowly repair the structural integrity of your ship's hull.", 250000, ItemCategory.ShipUpgrade));

//        var manager = new XmlManager<PlayerModel>();
//
//        _currentPlayer = new PlayerModel
//        {
//            Money = 300,
//            Inventory = new List<Item>(),
//            EquippedItems = new List<Item>()
//        };
//
//        manager.Save("savegame1.xml", _currentPlayer);

        #endregion

        ChangeStoreCategory(ItemCategory.Weapon);

        _currentPlayer = PlayerManager.Load();
        Money = _currentPlayer.Money;
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
        int startX = (columns / 2)*(itemWidth + itemOffset) * -1;
        int startY = (((categoryItems.Count + columns - 1) / columns) * (itemHeight + itemOffset)) * -1;

        int x = 0, y = 0;
        
        for(int i = 0; i < categoryItems.Count(); i++)
        {
            var item = categoryItems[i];
            var child = NGUITools.AddChild(UIParent, ButtonPrefab);
            child.transform.localPosition = new Vector3(
                startX + x * (itemWidth + itemOffset),
                (startY + y * (itemHeight + itemOffset)) * -1,
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

    public void Select(Item item)
    {
        SelectedPanel.SetActive(true);
        SelectedPanel.GetComponent<SelectedItem>().SelectItem(item);
    }

    public void Buy(Item item)
    {
        if (item.Price <= _currentPlayer.Money)
        {
            Money -= item.Price;
            _currentPlayer.Inventory.Add(item);
            SavePlayer();
        }
    }

    public void SavePlayer()
    {
        PlayerManager.Save(_currentPlayer);
    }
}
