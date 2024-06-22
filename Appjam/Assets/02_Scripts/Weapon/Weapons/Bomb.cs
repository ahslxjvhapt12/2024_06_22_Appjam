using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Bomb : Weapon
{
    [SerializeField] GameObject BombPrefab;

    [ContextMenu("Test")]
    public void Test()
    {
        GameManager.Instance.WeaponInven.AddWeapon(this);
    }

    protected override void Awake()
    {

        base.Awake();
        transform.DOScale(0, 0);
    }

    public override void Attack(Transform target)
    {

        DOTween.Sequence()
            .Append(transform.DOScale(1, 0.2f))
            .AppendInterval(0.2f)
            .Append(transform.DOShakePosition(0.2f, 1f))
            .Append(transform.DOScale(0, 0))
            .OnComplete(() =>
            {
                var obj = Instantiate(BombPrefab, transform.position, Quaternion.identity);
                obj.transform.DOJump(target.transform.position, 1f, 1, 0.8f);
            });

    }

}
