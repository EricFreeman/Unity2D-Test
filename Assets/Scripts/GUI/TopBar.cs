using Assets.Extensions;
using Assets.Managers;
using UnityEngine;

public class TopBar : MonoBehaviour
{
    public Transform MoneyEdit;
    public Transform ScreenNameEdit;
    public string ScreenName;

    void Start()
    {
        var p = PlayerManager.Load();
        MoneyEdit.GetComponent<UILabel>().text = "Creds: {0:c}".ToFormat(p.Money);

        ScreenNameEdit.GetComponent<UILabel>().text = ScreenName;
    }

    public void UpdateScreenName(string name)
    {
        ScreenName = name;
        ScreenNameEdit.GetComponent<UILabel>().text = ScreenName;
    }

    public void UpdateMoney(float money)
    {
        MoneyEdit.GetComponent<UILabel>().text = "Creds: {0:c}".ToFormat(money);
    }
}