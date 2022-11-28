using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradiantByTime : MonoBehaviour
{
    private SpriteRenderer sprt;
    public Gradient colors;

    private void OnEnable()
    {
        sprt = GetComponent<SpriteRenderer>();
        sprt.color = colors.Evaluate(Time.realtimeSinceStartup % 1);
    }

}
