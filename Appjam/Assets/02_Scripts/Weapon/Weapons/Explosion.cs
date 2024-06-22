using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float explosionRadius;
    [SerializeField] float damage;
    [SerializeField] LayerMask targetLayer;

    public void DestroyThis()
    {
        Destroy(gameObject);
    }

    public void CastDamage()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, explosionRadius, targetLayer);

        foreach (var item in cols)
        {
            if (item.TryGetComponent<IHitAble>(out var h))
            {
                h.Hit(damage);
            }
        }
    }
    public void Sound()
    {
        this.GetComponent<AudioSource>().Play();
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
#endif
}
