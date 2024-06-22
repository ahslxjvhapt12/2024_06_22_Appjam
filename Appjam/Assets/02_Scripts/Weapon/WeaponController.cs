using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private int maxCheckCount = 100;

    private Collider2D[] enemyArr;

    private List<Weapon> weaponContainer = new();

    private void Awake()
    {
        enemyArr = new Collider2D[maxCheckCount];

    }

    private void Update()
    {

        CheckEnemy();

    }

    private void CheckEnemy()
    {

        foreach (var weapon in weaponContainer)
        {

            int cnt = Physics2D.OverlapCircle(
                weapon.transform.position,
                weapon.DataSO.AttackRange.GetValue(),
                new ContactFilter2D { layerMask = enemyLayer, useLayerMask = true, useTriggers = true },
                enemyArr);

            if (cnt != 0)
            {

                weapon.Run(FindCloseEnemy(cnt));

            }
            else
            {

                weapon.Run(null);

            }

        }

    }

    public Transform FindCloseEnemy(int enemyCount)
    {

        float minDist = float.MaxValue;
        Transform curTarget = null;

        for (int i = 0; i < enemyCount; i++)
        {

            float dist = Vector2.Distance(enemyArr[i].transform.position, transform.position);

            if (minDist > dist)
            {

                minDist = dist;
                curTarget = enemyArr[i].transform;

            }

        }

        return curTarget;

    }

    private void RePosition()
    {

        float angle = 360 / (float)weaponContainer.Count;

        for (int i = 1; i <= weaponContainer.Count; i++)
        {

            weaponContainer[i - 1].transform.position = transform.position + (Quaternion.Euler(0, 0, angle * i) * Vector2.right * 1.5f);
        }

    }

    public Guid AddWeapon(Weapon weapon)
    {

        weaponContainer.Add(weapon);

        weapon.transform.SetParent(transform);

        RePosition();

        return weapon.WeaponGuid;

    }

    public void RemoveWeapon(Guid guid)
    {

        var removeWeapon = weaponContainer.Find(x => x.WeaponGuid == guid);

        if (removeWeapon != null)
        {

            weaponContainer.Remove(removeWeapon);

        }

        RePosition();

    }

    public Weapon FindWeapon(Guid guid) => weaponContainer.Find(x => x.WeaponGuid == guid);

    public void RemoveAllWeapon()
    {

        foreach (var item in weaponContainer)
        {

            Destroy(item.gameObject);

        }

        weaponContainer.Clear();

    }

}
