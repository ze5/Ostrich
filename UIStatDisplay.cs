using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIStatDisplay : MonoBehaviour
{
    public RectTransform Bar;
    public TextMeshProUGUI Text;
    private Vector3 scale = Vector3.one;

    public void UpdateUI(float max, float current)
    {

        if (current < 0)
        {
            current = 0;
        }
        if (current > max)
        {
            current = max;
        }
        scale.x = current / max;
        Bar.localScale = scale;
        Text.text = (int)(current) + " / " + (int)(max);
    }
}
