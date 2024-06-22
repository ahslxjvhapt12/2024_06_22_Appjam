using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class NPC : MonoBehaviour
{
    [SerializeField] GameObject interactObj;
    [SerializeField] GameObject shopUI;

    private void Start()
    {
        Grow();
    }

    private void Grow()
    {
        DOTween.Sequence()
            .Append(interactObj.transform.DOScale(1.5f, 1f).SetEase(Ease.Linear))
            .OnComplete(() =>
            {
                Reduction();
            });
    }

    private void Reduction()
    {
        DOTween.Sequence()
            .Append(interactObj.transform.DOScale(1f, 1f).SetEase(Ease.Linear))
            .OnComplete(() =>
            {
                Grow();
            });
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {

            if (Input.GetKeyDown(KeyCode.F))
            {

                shopUI.gameObject.SetActive(true);

            }

        }
    }
}
