using Assets.Scripts.Upgrades;
using UnityEngine;

public class CategoryButton : MonoBehaviour
{
    public ItemCategory Category;

    void OnClick()
    {
        var menu = GameObject.Find("GUI").GetComponent<UpgradeMenu>();
        menu.ChangeStoreCategory(Category);
    }
}