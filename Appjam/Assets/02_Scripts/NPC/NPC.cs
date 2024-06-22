using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class NPC : MonoBehaviour
{
    [SerializeField] GameObject shopUI;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {

            shopUI.gameObject.SetActive(true);

        }
    }
}
