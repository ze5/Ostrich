using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLevel : MonoBehaviour
{
    public GunGroup playerGun;
    // Start is called before the first frame update
    void Start()
    {
        playerGun.Optomize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
