using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Damage : MonoBehaviour
{
    public int HP = 100;
    public int CurrentHP;
    public TurnOff Off;
    public Light2D Light;
    public SpriteRenderer SpriteR;
    private Color sC;
    // Start is called before the first frame update
    private void Start()
    {
        if (Off == null)
        {
            Off = GetComponent<TurnOff>();
        }
        if (SpriteR == null)
        {
            SpriteR = GetComponent<SpriteRenderer>();
        }
        sC = SpriteR.color;
    }
    private void OnEnable()
    {
        CurrentHP = HP;
        Light.intensity = 0;
    }
    private void Update()
    {
        if (Light.intensity > 0)
        {
            Light.intensity -= Time.deltaTime * (Light.intensity + 1) * 10;
            SpriteR.color = Color.Lerp(sC, Random.ColorHSV(0.7f,1), Light.intensity / 2);
        }
        else
        {
            SpriteR.color = sC;
        }
    }
    public void Hurt(int damage)
    {
        CurrentHP -= damage;
        Light.color = Random.ColorHSV(0.5f, 1, 0.8f, 1);
        Light.intensity = 2;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CurrentHP < 1)
        {
            Off.Kill();
        }
    }
}
