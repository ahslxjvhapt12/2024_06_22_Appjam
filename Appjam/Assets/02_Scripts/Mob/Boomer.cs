using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomer : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = this.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            animator.SetTrigger("Boom");
            transform.DOShakePosition(50f, 0.2f).SetEase(Ease.Linear);
        }
    }
    private void Boom()
    {
        this.gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
