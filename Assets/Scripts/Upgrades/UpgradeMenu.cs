using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Assets.Managers;
using Assets.Models;
using Assets.Scripts.Upgrades;
using Assets.Services;
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
        var manager = new XmlManager<List<Item>>();
        _storeItems = manager.Load("Assets/Resources/Store/StoreItems.xml");

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
