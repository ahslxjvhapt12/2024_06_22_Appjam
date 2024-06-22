using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MonsterBullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float despawnTime = 5f;

    private float damage = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", despawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
    public void Satting(float _damage)
    {
        damage = _damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(1);
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().Hit(damage);
            DestroyBullet();
        }
    }
    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
