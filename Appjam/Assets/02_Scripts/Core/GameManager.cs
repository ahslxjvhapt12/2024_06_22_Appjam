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



}
