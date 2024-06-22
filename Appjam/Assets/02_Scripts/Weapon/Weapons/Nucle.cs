using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nucle : Weapon
{
    [SerializeField] GameObject effect;

    [ContextMenu("Test")]
    public void Test()
    {
        GameManager.Instance.WeaponInven.AddWeapon(this);
    }


    public override void Attack(Transform target)
    {

        var obj = Instantiate(effect, transform.position, Quaternion.identity);
        Vector3 dir = target.position - transform.position;
        obj.transform.position += dir * 0.5f;
        obj.transform.right = dir;
        transform.DOShakePosition(0.3f, 1);

    }

}
