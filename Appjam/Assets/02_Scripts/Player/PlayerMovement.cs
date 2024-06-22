using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float HP = 10f;
    [SerializeField] private float hitDelay = 1.5f;

    Animator animator;
    SpriteRenderer spriteRenderer;

    private readonly int walkHash = Animator.StringToHash("Walk");

    private bool isHit = false;
    private bool isdeath = false;

    private void Awake()
    {

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        if (isdeath) return;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 moveVector = new Vector3(h, v, 0).normalized;
        transform.position += moveVector * speed * Time.deltaTime;

        animator.SetBool(walkHash, moveVector != Vector3.zero);
        if (h != 0)
        {
            spriteRenderer.flipX = h < 0;
        }
    }

    public void Hit(float damage)
    {
        if (isHit || isdeath) return;
        else
        {
            IsHit();
            Invoke("IsHit", hitDelay);
        }
        HP -= damage;
        if (HP <= 0)
        {
            isdeath = true;
        }
    }
    private void IsHit()
    {
        isHit = !isHit;

        if (isHit) GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        else GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
}
