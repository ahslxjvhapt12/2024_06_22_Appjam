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
}
