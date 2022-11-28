using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlyingNumber : MonoBehaviour
{
    public float VisTime = 0.5f;
    public Vector2 startForceMax;
    public Color startColor;
    public Color endColor;
    private Vector2 randForce;
    private float time = 0;
    private TextMeshPro text;
    private Color realColor;
    private void OnEnable()
    {
        if (text == null)
        {
            text = GetComponent<TextMeshPro>();
        }
        else
        {
            text.color = startColor;
        }
        time = 0;
        randForce.x = Random.Range(-startForceMax.x, startForceMax.x);
        randForce.y = Random.Range(startForceMax.y / 2, startForceMax.y);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().AddForce(randForce);
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        realColor = Color.Lerp(startColor, endColor, time / VisTime);
        text.color = realColor;
        if (time > VisTime)
        {
            gameObject.SetActive(false);
        }
    }
}
