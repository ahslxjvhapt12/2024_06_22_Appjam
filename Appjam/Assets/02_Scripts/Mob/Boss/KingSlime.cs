using UnityEngine;
using Random = UnityEngine.Random;

public class KingSlime : MonoBehaviour, IHitAble
{
    private GameObject m_Target;
    private Rigidbody2D m_Rigidbody;
    private SpriteRenderer m_SpriteRenderer;
    private Animator m_Animator;
    [SerializeField] GameObject effect;

    [SerializeField]
    private float m_Speed = 1f;
    [SerializeField]
    private float HP = 100f;
    [SerializeField]
    private float attackDamage = 1f;

    private float lostHP;
    private float currentHP;

    //skill_1
    private float speed;
    private bool isJump = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = HP;

        m_Animator = this.GetComponent<Animator>();
        m_Rigidbody = this.GetComponent<Rigidbody2D>();
        m_SpriteRenderer = this.GetComponent<SpriteRenderer>();
        m_Target = GameManager.Instance.Player;
    }

    void FixedUpdate()
    {
        if (currentHP <= 0f)
        {
            Die();
        }
        Vector2 dirVec = m_Target.transform.position - m_Rigidbody.transform.position;
        Vector2 nextVec = dirVec.normalized * m_Speed * Time.fixedDeltaTime; // vector 정규화를 통해 일정한 속도 유지
        m_Rigidbody.MovePosition(m_Rigidbody.position + nextVec); // 적 이동
        m_Rigidbody.velocity = Vector2.zero; // 가속 방지


        // 타겟 위치에 따라 방향 전환
        if (dirVec.x > 0 && !isJump)
        {
            m_SpriteRenderer.flipX = true;
        }
        else if (dirVec.x < 0 && !isJump)
        {
            m_SpriteRenderer.flipX = false;
        }

        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    Debug.Log(currentHP);
        //    currentHP -= 5f;
        //}
        //if (currentHP <= 90)
        //{
        //    lostHP = HP - currentHP;
        //    if (lostHP >= 10)
        //    {
        //        nextPatternPlay();
        //        lostHP = 0;
        //        HP = currentHP;
        //    }
        //}
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (attackDamage <= 0) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            m_Target.transform.GetComponent<PlayerMovement>().Hit(attackDamage);
        }
    }

    private void nextPatternPlay()
    {
        int ran = Random.RandomRange(1, 2);
        Debug.Log(ran);
        switch (ran)
        {
            case 1:
                m_Animator.SetTrigger("Skill_1");
                break;
            case 2:
                break;
        }
    }

    //skill_1
    public void Skill_1()
    {
        isJump = true;
        speed = m_Speed;
        m_Speed = 10f;
    }
    public void Drop()
    {
        m_Speed = 0f;
        Invoke("IsDrop", 1.5f);
    }
    private void IsDrop()
    {
        m_Speed = speed;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isJump)
        {
            m_Target.transform.GetComponent<Rigidbody2D>().AddForce(-new Vector2(transform.position.x - GameManager.Instance.Player.transform.position.x, transform.position.y - GameManager.Instance.Player.transform.position.y) * 3);
            m_Target.transform.GetComponent<PlayerMovement>().Hit(attackDamage);
            isJump = false;
        }
        else
        {
            collision.GetComponent<Rigidbody2D>().AddForce(-new Vector2(transform.position.x - collision.transform.position.x, transform.position.y - collision.transform.position.y) * 3);
        }
    }

    public void Hit(float Damage)
    {
        HP -= Damage;

        var obj = Instantiate(effect, transform.position, Quaternion.identity);
        obj.transform.position += (Vector3)Random.insideUnitCircle / 2;

        if (HP <= 0)
        {
            Die();
        }

    }
    public void Die()
    {
        Shop.Instance.SetMoney(1000);
        Destroy(gameObject);
    }
}
