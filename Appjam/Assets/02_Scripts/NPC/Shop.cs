using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public float money = 0;

    private static Shop instance;
    public static Shop Instance
    {
        get
        {
            if (instance != null)
                return instance;

            if (instance == null)
            {
                instance = FindObjectOfType<Shop>();
            }

            if (instance != null)
            {
                if (FindObjectsOfType<Shop>().Length > 1)
                {
                    Debug.LogError($"Multiple {typeof(Shop).Name} is Running!");
                }

                return instance;
            }

            Debug.LogError($"{typeof(Shop).Name} is null");
            return null;
        }
    }


    [SerializeField] TextMeshProUGUI moneyTxt;
    [SerializeField] WarningTxtTween warningTxt;
    [SerializeField] Transform tweenTargetPos;
    [SerializeField] TextMeshProUGUI NPCText;
    [SerializeField] Transform tweenStartPos;
    private void OnEnable()
    {

        moneyTxt.text = $"{money} ��";
        SetNPCText("���.\n���������� �����۵� ���� ���ȵ� ��ȭ �� �� �־�");

    }

    public void SpawnWarnigTxt()
    {
        Debug.Log(1);
        var obj = Instantiate(warningTxt, transform);
        obj.transform.position = tweenStartPos.position;
        obj.Move(tweenTargetPos);
    }

    public void SetNPCText(string str)
    {
        NPCText.text = "";
        NPCText.DOText(str, 2f);

    }

    public void CloseShop()
    {
        gameObject.SetActive(false);
    }
}
