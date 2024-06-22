using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{

    private static StatManager instance;
    public static StatManager Instance
    {
        get
        {
            if (instance != null)
                return instance;

            if (instance == null)
            {
                instance = FindObjectOfType<StatManager>();
            }

            if (instance != null)
            {
                if (FindObjectsOfType<StatManager>().Length > 1)
                {
                    Debug.LogError($"Multiple {typeof(StatManager).Name} is Running!");
                }

                return instance;
            }

            Debug.LogError($"{typeof(StatManager).Name} is null");
            return null;
        }
    }

    public string RerollStat()
    {
        int idx = Random.Range(0, 4);
        string statStr = "";
        int amount = Random.Range(10, 25);

        if (idx == 0)
        {
            statStr = "SPEED";
            GameManager.Instance.Movement.speedFactor += amount * 0.01f;
        }
        if (idx == 1)
        {
            statStr = "DAMAGE";
            GameManager.Instance.DamageFactor += amount * 0.01f;
        }
        if (idx == 2)
        {
            statStr = "HP";
            GameManager.Instance.Movement.HP += amount;
        }
        if (idx == 3)
        {
            statStr = "ATTACK SPEED";
            GameManager.Instance.CoolDownFactor += amount * 0.01f;
        }

        return $"{statStr} {amount} UP!";
    }



}
