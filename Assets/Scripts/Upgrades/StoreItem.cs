using Assets.Scripts.Upgrades;
using UnityEngine;

public class StoreItem : MonoBehaviour
{
    private Item _item;
    public Item Item
    {
        get { return _item; }
        set
        {
            _item = value;;
            var c = GetComponentInChildren<UILabel>();
            c.text = value.Name;
        }
    }

    void OnClick()
    {
        GameObject.Find("GUI").GetComponent<UpgradeMenu>().Select(this);
    }
}
