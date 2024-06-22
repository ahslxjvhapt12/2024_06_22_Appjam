using System;
using UnityEngine;

public class DopamineManager : MonoBehaviour
{
    private static DopamineManager instance;
    public static DopamineManager Instance
    {
        get
        {
            if (instance != null)
                return instance;

            if (instance == null)
            {
                instance = FindObjectOfType<DopamineManager>();
            }

            if (instance != null)
            {
                if (FindObjectsOfType<DopamineManager>().Length > 1)
                {
                    Debug.LogError($"Multiple {typeof(DopamineManager).Name} is Running!");
                }

                return instance;
            }

            Debug.LogError($"{typeof(DopamineManager).Name} is null");
            return null;
        }
    }

    private float dopamineAmount;
    public float DopamineAmount => dopamineAmount;

    public Action OnChargeDopamine;

    public void UpdateDopamine(float amount)
    {

        dopamineAmount += amount;

        if (dopamineAmount >= 100)
        {

            OnChargeDopamine?.Invoke();

        }

    }


}
