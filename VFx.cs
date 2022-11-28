using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VFx : MonoBehaviour
{
    public float V_Amount = 0;
    private Vector2 playerC;
    private Vector2Parameter V_Center = new Vector2Parameter(Vector2.zero);
    private Transform Player;
    private Vignette vign;
    private ClampedFloatParameter V_int = new ClampedFloatParameter(0, 0, 1);
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").transform;
        vign = Volume.FindObjectOfType<Vignette>();
    }

    // Update is called once per frame
    void Update()
    {
        if (V_Amount > 0)
        {
            if (V_Amount > 1)
            {
                V_Amount = 1;
            }
            vign = Volume.FindObjectOfType<Vignette>();
            playerC = Camera.main.WorldToScreenPoint(Player.position);
            playerC.x /= Camera.main.pixelWidth;
            playerC.y /= Camera.main.pixelHeight;
            V_Amount -= Time.deltaTime/2;
            V_int.value = V_Amount;
            V_Center.value = playerC;
            vign.center = V_Center;
            vign.intensity = V_int;
        }
    }
}
