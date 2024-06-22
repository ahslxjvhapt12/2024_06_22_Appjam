using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nucle : Weapon
{
    [SerializeField] GameObject effect;
    public override void Attack(Transform target)
    {

        Instantiate(effect, transform.position, Quaternion.identity);

        effect.transform.up = target.position - transform.position;
        transform.DOShakePosition(0.3f, 1);

    }

}
