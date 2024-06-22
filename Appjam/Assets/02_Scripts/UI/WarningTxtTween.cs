using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WarningTxtTween : MonoBehaviour
{
    TextMeshProUGUI txt;

    private void Awake()
    {
        txt = GetComponent<TextMeshProUGUI>();
    }

    public void Move(Transform target)
    {
        DOTween.Sequence()
            .Append(transform.DOMove(target.position, 2f))
            .Append(txt.DOFade(0, 1));

    }
}
