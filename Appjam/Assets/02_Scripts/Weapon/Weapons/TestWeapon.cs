using UnityEngine;

public class TestWeapon : Weapon
{
    [ContextMenu("Test")]
    public void Test()
    {
        GameManager.Instance.WeaponInven.AddWeapon(this);
    }

    public override void Attack(Transform target)
    {

        Debug.Log("АјАн");

    }
}
