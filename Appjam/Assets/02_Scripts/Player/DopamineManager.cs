using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

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

    public int dopamineCount = 0;


    [SerializeField] Image screenImage;

    public void EarnDopamine(float amount)
    {

        dopamineAmount += amount;

        if (dopamineAmount >= 100)
        {

            StatChange();

        }

    }
    private void StatChange()
    {
        dopamineCount++;
        dopamineAmount = 0;

        int amount = UnityEngine.Random.Range(10, 25);

        GameManager.Instance.Movement.speedFactor += amount * 0.01f;

        GameManager.Instance.DamageFactor += amount * 0.01f;

        GameManager.Instance.Movement.HP += amount;

        GameManager.Instance.CoolDownFactor += amount * 0.01f;
        screenImage.enabled = true;

        StartCoroutine(ScreenCO());
    }

    IEnumerator ScreenCO()
    {

        yield return new WaitForSeconds(10);
        screenImage.enabled = false;

    }

}
