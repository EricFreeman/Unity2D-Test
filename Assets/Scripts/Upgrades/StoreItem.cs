using Assets.Scripts.Upgrades;
using UnityEngine;

public class StoreItem : MonoBehaviour
{
    public string ItemName
    {
        get { return _itemName; }
        set
        {
            _itemName = value;
            var c = GetComponentInChildren<UILabel>();
            c.text = value;
        }
    }

    public string ItemDescription;
    public float ItemPrice;

    public ItemCategory Category;
    private string _itemName;
}
