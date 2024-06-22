using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [field: SerializeField] public Stats Speed { get; protected set; }
    [field: SerializeField] public Stats Damage { get; protected set; }


    private void OnEnable()
    {
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        transform.position += transform.up * Speed.GetValue() * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (collision.TryGetComponent<IHitAble>(out var h))
            {
                h.Hit(Damage.GetValue());
                Destroy(gameObject);
            }
        }
    }

}
