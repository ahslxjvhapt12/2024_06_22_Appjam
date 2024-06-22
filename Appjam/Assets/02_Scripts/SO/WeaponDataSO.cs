using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/WeaponData")]
public class WeaponDataSO : ScriptableObject
{
    [field: SerializeField] public Stats AttackCoolDown { get; protected set; }
    [field: SerializeField] public Stats AttackRange { get; protected set; }
    [field: SerializeField] public Stats AttackDamage { get; protected set; }

    private Weapon owner;

    public bool isAttackCoolDown { get; protected set; }

    public void Init(Weapon owner)
    {

        this.owner = owner;

    }

    public void SetCoolDown()
    {

        owner.StartCoroutine(SetCoolDownCo());

    }

    private IEnumerator SetCoolDownCo()
    {
        isAttackCoolDown = true;

        // 기존 공격속도 / (100 + 공격속도 증가 수치) * 100
        yield return new WaitForSeconds(AttackCoolDown.GetValue() / (100 + GameManager.Instance.CoolDownFactor) * 100);

        isAttackCoolDown = false;

    }

}
