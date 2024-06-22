using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance != null)
                return instance;

            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }

            if (instance != null)
            {
                if (FindObjectsOfType<GameManager>().Length > 1)
                {
                    Debug.LogError($"Multiple {typeof(GameManager).Name} is Running!");
                }

                return instance;
            }

            Debug.LogError($"{typeof(GameManager).Name} is null");
            return null;
        }
    }

    private WeaponController weaponInven;
    public WeaponController WeaponInven => weaponInven;

    private GameObject player;
    public GameObject Player => player;
    private GameObject camTaget;

    private PlayerMovement movement;
    public PlayerMovement Movement => movement;

    public float CoolDownFactor = 0;

    public float DamageFactor = 0;



    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        camTaget = GameObject.Find("CamTarget");
        weaponInven = FindAnyObjectByType<WeaponController>();
        movement = FindAnyObjectByType<PlayerMovement>();
    }

    public void ShakeCamera(float duration, float power)
    {
        camTaget.transform.DOShakePosition(duration, power);
    }



}
