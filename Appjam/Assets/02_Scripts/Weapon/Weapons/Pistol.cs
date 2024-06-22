using DG.Tweening;
using UnityEngine;

public class Pistol : Weapon
{
    [SerializeField] GameObject bullet;

    [ContextMenu("Test")]
    public void Test()
    {
        GameManager.Instance.WeaponInven.AddWeapon(this);
    }

    public override void Attack(Transform target)
    {

        var blt = Instantiate(bullet, transform.position, Quaternion.identity);
        blt.transform.up = target.position - blt.transform.position;

        transform.DOShakePosition(0.2f, 1f);

    }

}
