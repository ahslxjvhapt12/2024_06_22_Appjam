using UnityEngine;

public class Pistol : Weapon
{
    [SerializeField] GameObject bullet;

    public override void Attack(Transform target)
    {
        var blt = Instantiate(bullet, transform.position, Quaternion.identity);
        blt.transform.up = blt.transform.position - target.position;
    }

}
