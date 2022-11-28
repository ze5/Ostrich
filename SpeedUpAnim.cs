using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpAnim : MonoBehaviour
{
    // Start is called before the first frame update
    public GunGroup gun;
    private Animator anim;
    private float rate = 0;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gun.Firing && rate < 1)
            {

            rate += (Time.deltaTime + (rate * Time.deltaTime))*10;
            }
        else if (rate > 0)
        {
            rate -= (rate * rate * Time.deltaTime) + Time.deltaTime;
        }
        if (rate < 0)
        {
            rate = 0;
        }
                anim.speed = rate;
    }
}
