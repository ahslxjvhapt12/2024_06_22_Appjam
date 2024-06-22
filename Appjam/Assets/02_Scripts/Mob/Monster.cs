using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour, IHitAble
{
    private GameObject m_Target;
    private Rigidbody2D m_Rigidbody;
    private SpriteRenderer m_SpriteRenderer;

    [SerializeField] GameObject effect;
    [SerializeField]
    private float m_Speed = 1f;
    [SerializeField]
    private float HP = 1f;
    [SerializeField]
    private float attackDamage = 1f;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = this.GetComponent<Rigidbody2D>();
        m_SpriteRenderer = this.GetComponent<SpriteRenderer>();
        m_Target = GameManager.Instance.Player;
    }

    void FixedUpdate()
    {
        Vector2 dirVec = m_Target.transform.position - m_Rigidbody.transform.position;
        Vector2 nextVec = dirVec.normalized * m_Speed * Time.fixedDeltaTime; // vector 정규화를 통해 일정한 속도 유지
        m_Rigidbody.MovePosition(m_Rigidbody.position + nextVec); // 적 이동
        m_Rigidbody.velocity = Vector2.zero; // 가속 방지


        // 타겟 위치에 따라 방향 전환
        if (dirVec.x > 0)
        {
            m_SpriteRenderer.flipX = false;
        }
        else if (dirVec.x < 0)
        {
            m_SpriteRenderer.flipX = true;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (attackDamage <= 0) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            m_Target.transform.GetComponent<PlayerMovement>().Hit(attackDamage);
        }
    }

    public void Hit(float Damage)
    {
        HP -= Damage;

        var obj = Instantiate(effect, transform.position, Quaternion.identity);
        obj.transform.position += (Vector3)Random.insideUnitCircle / 2;

        if (HP <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        Shop.Instance.SetMoney(UnityEngine.Random.Range(10, 50));
        DopamineManager.Instance.EarnDopamine(5);
    }
}
