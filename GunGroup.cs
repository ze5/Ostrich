using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GunGroup : MonoBehaviour
{
    public Gun[] Guns;
    public float FireRate = 0.2f;
    public float FireDelay = 0.0f;
    public float GunCost = 0;
    public int FireBursts = 0;
    public bool Firing = false;
    float delay = 0;
    int burst = 0;
    private float rate = 0f;
    private GameObject Bullet;
    private Color color;
    public void LoadGuns(Spawn bullet)
    {
        for (int i = 0; i < Guns.Length; i++)
        {
            Guns[i].pool = bullet;
        }
    }
    public void Optomize()
    {
        List<Gun> temp = new List<Gun>();
        for (int i = 0; i < Guns.Length; i++)
        {
            if (Guns[i].isActiveAndEnabled)
            {
                temp.Add(Guns[i]);
            }
        }
        Guns = temp.ToArray();
    }
    private void LateUpdate()
    {
        Firing = false;
    }
    public bool Fire()
    {
        Firing = true;
        if (FireBursts > 0)
        {
            delay -= Time.deltaTime;
            if (burst < 1)
            {
                burst = FireBursts;
                delay = FireDelay;
            }
        }
        if (delay <= 0 || FireBursts == 0)
        {
            rate -= Time.deltaTime;
            //color = new Color(Random.value, Random.value, Random.value, 1);
            if (rate < 0)
            {

                for (int i = 0; i < Guns.Length; i++)
                {
                    if (Guns[i].isActiveAndEnabled)
                    {
                        Bullet = Guns[i].Fire();
                        //you can do whatever extra updates to bullets you want. change color or whatever.
                        if (Bullet != null)
                        {
                            //colorChange();
                        }
                    }
                }
                rate = FireRate;
                burst--;
                return true;
            }
        }
        return false;
    }
    void colorChange()
    {
        Bullet.GetComponent<Light2D>().color = color;
        //Bullet.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value, 1);
    }
}
