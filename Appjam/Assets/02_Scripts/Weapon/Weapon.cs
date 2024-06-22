using System;
using UnityEngine;
using static Stats;

public abstract class Weapon : MonoBehaviour
{
    protected Transform target;
    public Transform Target => target;

    [field: SerializeField] public WeaponDataSO DataSO { get; protected set; }
    public Guid WeaponGuid { get; protected set; }

    protected virtual void Awake()
    {

        WeaponGuid = Guid.NewGuid();

        DataSO = Instantiate(DataSO);
        DataSO.Init(this);

    }

    public virtual void Run(Transform target, bool isSkill = false)
    {

        this.target = target;

        RotateWeapon(target);

        if ((!DataSO.isAttackCoolDown || isSkill) && target != null)
        {
            if (!DataSO.isAttackCoolDown)
                DataSO.SetCoolDown();

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
