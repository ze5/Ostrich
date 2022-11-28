using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstFire : MonoBehaviour
{
    public GunGroup gun;
    void Update()
    {
        gun.Fire();
    }
}
