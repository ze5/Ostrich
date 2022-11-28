using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunManager : MonoBehaviour
{

    public GunGroup[] gunGroups;
    public int current = 0;
    public AudioTransition levelAudio;
    public bool ShootPeak = true;
    public int spectrum = 0;
    private void Start()
    {
        if (ShootPeak)
        {
            levelAudio = GameObject.Find("Main Camera").GetComponent<AudioTransition>();
            InvokeRepeating("FireMusic", 0, Time.fixedDeltaTime);
        }
    }
    public void FireMusic()
    {
        if (levelAudio.peaking[spectrum])
        {
            gunGroups[current].Fire();
        }
    }
    public void LoadGuns(Spawn bullet, int mingroup = 0, int maxgroup = 1)
    {
        for (int i = mingroup; i<maxgroup;i++)
        {
            gunGroups[i].LoadGuns(bullet);
        }
    }
    public void Fire()
    {
        gunGroups[current].Fire();
    }
}
