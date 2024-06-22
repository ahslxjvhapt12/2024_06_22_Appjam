using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class RangedMonster : MonoBehaviour
{
    public GameObject bullet;

    private GameObject m_Target;
    private Rigidbody2D m_Rigidbody;
    private SpriteRenderer m_SpriteRenderer;
    private Animator animator;

    [SerializeField]
    private float m_Speed = 1f;
    [SerializeField]
    private float HP = 1f;
    [SerializeField]
    private float attackDamage = 1f;
    [SerializeField] 
    private float attackRange = 5f;
    [SerializeField]
    private float attackDelay = 1f;

    private bool isShoot = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        m_Rigidbody = this.GetComponent<Rigidbody2D>();
        m_SpriteRenderer = this.GetComponent<SpriteRenderer>();
        m_Target = GameManager.Instance.Player;
    }

    void FixedUpdate()
    {
        float distance = Vector3.Distance(m_Target.transform.position, m_Rigidbody.transform.position);
        Vector2 dirVec = m_Target.transform.position - m_Rigidbody.transform.position;
        if (distance <= attackRange)
        {
            animator.SetBool("Attack", true);
            if (!isShoot)
            {
                Attack();
                isShoot = true;
                StartCoroutine("Shoot");
            }
        }
        else
        {
            animator.SetBool("Attack", false);
            Vector2 nextVec = dirVec.normalized * m_Speed * Time.fixedDeltaTime; // vector 정규화를 통해 일정한 속도 유지
            m_Rigidbody.MovePosition(m_Rigidbody.position + nextVec); // 적 이동
            m_Rigidbody.velocity = Vector2.zero; // 가속 방지
        }

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

    private void Attack()
    {
        float angle = Mathf.Atan2(transform.position.x - GameManager.Instance.Player.transform.position.x, transform.position.y - GameManager.Instance.Player.transform.position.y) * Mathf.Rad2Deg;
        GameObject Instance = Instantiate(bullet, this.transform.position, Quaternion.Euler(0, 0, (angle + 180) * -1)) as GameObject;
        Instance.GetComponent<MonsterBullet>().Satting(attackDamage);
        Instance.transform.parent = this.transform.parent;

        //bullet.gameObject.GetComponent<MonsterBullet>().Satting(attackDamage);
        //Instantiate(bullet, this.transform);
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(attackDelay);
        isShoot = false;
    }
}

