using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float HP = 10f;
    [SerializeField] private float hitDelay = 1.5f;

    private bool isHit = false;
    private bool isdeath = false;

    private AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isdeath) return;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(h, v, 0).normalized * speed * Time.deltaTime;

    }

    public void Hit(float damage)
    {
        if(isHit || isdeath) return;
        else
        {
            IsHit();
            Invoke("IsHit", hitDelay);
        }

        audio.Play();
        HP -= damage;
        if (HP <= 0)
        {
            isdeath = true;
        }
    }
    private void IsHit()
    {
        isHit = !isHit;

        if(isHit) GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.5f);
        else GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
    }
}
