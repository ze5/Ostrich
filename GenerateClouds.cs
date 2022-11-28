using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateClouds : MonoBehaviour
{
    public Spawn pool;
    private Vector3 posit;
    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        posit.x = -14;
        while (posit.x < 18)
        {
            if (Random.value > 0.3f)
            {
                posit.x += Random.value * 2;
            }
            if (Random.value > 0.3f)
            {
                MakeCloud();
            }
        }
        posit.x = 18;
        
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            MakeCloud();
            timer = Random.value/2;
        }
    }
    void MakeCloud()
    {
        GameObject cloud = pool.SpawnChild();
        posit.y = Random.Range(-24, 24);
        cloud.transform.position = posit;
        cloud.GetComponent<CloudBG>().Randomize();
    }

}
