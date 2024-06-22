using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

public class MonsterMovement : MonoBehaviour
{
    private GameObject m_Target;
    private Rigidbody2D m_Rigidbody;
    private SpriteRenderer m_SpriteRenderer;

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
        m_Target = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    { 
        Vector2 dirVec = m_Target.transform.position - m_Rigidbody.transform.position;
        Vector2 nextVec = dirVec.normalized * m_Speed * Time.fixedDeltaTime; // vector ����ȭ�� ���� ������ �ӵ� ����
        m_Rigidbody.MovePosition(m_Rigidbody.position + nextVec); // �� �̵�
        m_Rigidbody.velocity = Vector2.zero; // ���� ����


        // Ÿ�� ��ġ�� ���� ���� ��ȯ
        if (dirVec.x > 0)
        {
            m_SpriteRenderer.flipX = false;
        }
        else if (dirVec.x < 0)
        {
            m_SpriteRenderer.flipX = true;
        }
        
    }
}
