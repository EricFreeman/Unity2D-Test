﻿using Assets.Models;
using Assets.Scripts.Upgrades;
using Assets.Services;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    private PlayerModel _currentPlayer;
    public int MaxItems = 3;

    private int _equippedItemsCount
    {
        get { return _currentPlayer.EquippedItems.Count; }
    }

    // Top Bar
    public Transform Grid;

    // Bottom Bar
    public Transform SelectedItemLabel;
    public Transform EquipButton;
    public Transform UnequipButton;

    void Start()
    {
        var manager = new XmlManager<PlayerModel>();
        _currentPlayer = manager.Load("savegame1.xml");

        ReloadInventory();
    }

    void ReloadInventory()
    {
        ClearInventoryGrid();
        foreach (var inv in _currentPlayer.Inventory)
            AddItemToGrid(inv);
    }

    void ClearInventoryGrid()
    {
        foreach (Transform child in Grid.transform)
            NGUITools.Destroy(child.gameObject);
    }

    void RemoveItemFromGrid(Item item)
    {
        foreach (Transform child in Grid.transform)
            if(child.GetComponentInChildren<ItemSelectButton>().Item == item)
                NGUITools.Destroy(child.gameObject);

        Grid.GetComponent<UIGrid>().repositionNow = true;
    }

    void AddItemToGrid(Item item)
    {
        var i = (GameObject)Instantiate(Resources.Load("Prefabs/GUI/InventoryItem"));
        i.transform.parent = Grid;
        i.transform.localScale = Vector3.one;

        i.GetComponentInChildren<ItemSelectButton>().Item = item;
        i.GetComponentInChildren<ItemSelectButton>().Gui = transform;
        i.GetComponentInChildren<UILabel>().text = item.Name;

        Grid.GetComponent<UIGrid>().repositionNow = true;
    }

    public void Select(Item item)
    {
        SelectedItemLabel.gameObject.SetActive(true);
        EquipButton.gameObject.SetActive(_currentPlayer.Inventory.Contains(item));
        UnequipButton.gameObject.SetActive(_currentPlayer.EquippedItems.Contains(item));
        SelectedItemLabel.GetComponent<UILabel>().text = item.Name;
        Grid.GetComponent<UIGrid>().repositionNow = true;

        EquipButton.GetComponent<EquipItem>().Item = item;
        UnequipButton.GetComponent<UnequipItem>().Item = item;
    }

    public void Equip(Item item)
    {
        if (_equippedItemsCount < MaxItems)
        {
            _currentPlayer.Inventory.Remove(item);
            _currentPlayer.EquippedItems.Add(item);
            Select(item);
            RemoveItemFromGrid(item);
        }
    }

    public void Unequip(Item item)
    {
        _currentPlayer.EquippedItems.Remove(item);
        _currentPlayer.Inventory.Add(item);
        Select(item);
        AddItemToGrid(item);
    }
}
