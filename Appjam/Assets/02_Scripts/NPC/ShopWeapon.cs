using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopWeapon : MonoBehaviour
{
    [SerializeField] int price;
    [SerializeField] Weapon weaponObj;

    public void Purchase()
    {
        if (Shop.Instance.money > price)
        {
            Shop.Instance.money -= price;
            GameManager.Instance.WeaponInven.AddWeapon(Instantiate(weaponObj));
        }
        else
        {
            GameManager.Instance.ShakeCamera(0.1f, 1);
            Debug.Log("돈이 부족합니다");
            Shop.Instance.SpawnWarnigTxt();
        }
    }

    public void Reroll()
    {
        Shop.Instance.SetNPCText(StatManager.Instance.RerollStat());
    }

}
