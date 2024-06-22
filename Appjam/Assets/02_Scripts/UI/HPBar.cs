using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Image image;

    public void ChangeHPBar(float cur, float max)
    {

        image.fillAmount = cur / max;
        text.text = $"{cur} / {max}";

    }

}
