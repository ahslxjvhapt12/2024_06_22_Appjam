using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;


[System.Serializable]
public class Stats
{

    [SerializeField] private float value;

    private List<float> modifys = new();

    public float GetValue()
    {

        float mod = value;

        foreach (var item in modifys)
        {

            mod += item;

        }

        return mod;

    }

    public void AddModify(float value)
    {

        modifys.Add(value);

    }

    public void RemoveModify(float value)
    {

        modifys.Remove(value);

    }

}

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

        yield return new WaitForSeconds(AttackCoolDown.GetValue());

        isAttackCoolDown = false;

    }

}
