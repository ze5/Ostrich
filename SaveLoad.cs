using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad
{
    void Sart()
    {

    }

    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.OpenOrCreate);
        SerializableSaveData serializableSaveData = new SerializableSaveData();
        bf.Serialize(file, serializableSaveData);
        file.Close();
        //Debug.Log (SaveData.currentLevel);
    }

    public static bool Load()
    {
        if (File.Exists(Application.persistentDataPath + "/save.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);
            SerializableSaveData serializableSaveData = (SerializableSaveData)bf.Deserialize(file);
            file.Close();
            serializableSaveData.RestoreSaveData();
            return (true);
        }
        else
        {
            return (false);
        }
    }
}

public class SaveData
{
    public static String LegGun = "Homing";
    public static int LegGunLevel = 0;
    public static int Money = 0;
    public static int Health = 200;
    public static int Shield = 50;
    public static int Energy = 10;
    public static float ShieldRate = 1f;
    public static float ShieldDelay = 0.2f;
    public static float ShieldCost = 20f;
    public static float ChargeRate = 10f;
}

[Serializable]
public class SerializableSaveData
{
    private String LegGun = SaveData.LegGun;
    private int LegGunLevel = SaveData.LegGunLevel;
    private int Money = SaveData.Money;
    private int Health = SaveData.Health;
    private int Shield = SaveData.Shield;
    private int Energy = SaveData.Energy;
    private float ShieldRate = SaveData.ShieldRate;
    private float ShieldDelay = SaveData.ShieldDelay;
    private float ShieldCost = SaveData.ShieldCost;
    private float ChargeRate = SaveData.ChargeRate;
     
        public void RestoreSaveData()
    {
        SaveData.LegGun = LegGun;
        SaveData.LegGunLevel = LegGunLevel;
        SaveData.Money = Money;
        SaveData.Health = Health;
        SaveData.Shield = Shield;
        SaveData.Energy = Energy;
        SaveData.ShieldRate = ShieldRate;
        SaveData.ShieldDelay = ShieldDelay;
        SaveData.ShieldCost = ShieldCost;
        SaveData.ChargeRate = ChargeRate;
    }
}
