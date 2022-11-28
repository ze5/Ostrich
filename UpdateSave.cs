using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UpdateSave : MonoBehaviour
{

    // Start is called before the first frame update


    public void UpdateVar()
    {
        if (tag == "LegGun")
        {
            SaveData.LegGun = name;
        }
        setDefault();
        SaveLoad.Save();
    }
    public void AddorSub()
    {
        if (tag == "LegGun")
        {
            SaveData.LegGunLevel += int.Parse(name);
        }
        SaveLoad.Save();
    }
    public void setDefault()
    {
        SaveData.ChargeRate = 10f;
        SaveData.Energy = 10;
        SaveData.Health = 150;
        SaveData.Money = 0;
        SaveData.Shield = 50;
        SaveData.ShieldCost = 20;
        SaveData.ShieldDelay = 0.2f;
        SaveData.ShieldRate = 20f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
