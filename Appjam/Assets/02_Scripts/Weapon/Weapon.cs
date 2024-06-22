using System;
using UnityEngine;
using static Stats;

public abstract class Weapon : MonoBehaviour
{
    protected Transform target;
    public Transform Target => target;

    [field: SerializeField] public WeaponDataSO Data { get; protected set; }
    public Guid WeaponGuid { get; protected set; }

    protected virtual void Awake()
    {

        WeaponGuid = Guid.NewGuid();

        Data = Instantiate(Data);
        Data.Init(this);

    }

    public virtual void Run(Transform target, bool isSkill = false)
    {

        this.target = target;

        RotateWeapon(target);

        if ((!Data.isAttackCoolDown || isSkill) && target != null)
        {
            if (!Data.isAttackCoolDown)
                Data.SetCoolDown();

            Attack(target);

        }

    }

    protected virtual void RotateWeapon(Transform target)
    {
        if (target == null)
        {
            transform.rotation = Quaternion.identity;
            return;
        }

        var dir = target.position - transform.position;

        transform.up = dir.normalized;

    }

    public abstract void Attack(Transform target);
}
