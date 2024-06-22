using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nucle : Weapon
{
    [SerializeField] GameObject effect;
    public override void Attack(Transform target)
    {

        var obj = Instantiate(effect, transform.position, Quaternion.identity);
        Vector3 dir = target.position - transform.position;
        obj.transform.position += dir * 1.5f;
        effect.transform.up = dir;
        transform.DOShakePosition(0.3f, 1);

    }

}
