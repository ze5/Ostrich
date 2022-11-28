using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int MaxHealth = 10;
    public int CHealth = 10;
    public int MaxEnergy = 10;
    public int MaxShield = 10;
    public float CShield = 10;

    public float cEnergy = 10f;
    public float chargeRate = 1f;
    public float ShieldDelay = 0.5f;
    public float ShieldCD = 0;
    public float ShieldRate = 1f;
    public float ShieldCost = 1f;

    public VFx Fx;
    public UIStatDisplay HealthUI;
    public UIStatDisplay ShieldUI;
    public UIStatDisplay GeneratorUI;

    public AudioSource Sound;
    public int LegLevel = 0;
    public string LegGun = "Homing";
    public Transform[] GunObjs;
    private GunGroup gunGroup;
    // Start is called before the first frame update
    void Start()
    {
        gunGroup = GetComponent<GunGroup>();
        Load();
        CHealth = MaxHealth;
        CShield = MaxShield;
        cEnergy = MaxEnergy;
        HealthUI.UpdateUI(MaxHealth, CHealth);
        ShieldUI.UpdateUI(MaxShield, CShield);
    }
    public void Hurt(int dmg)
    {
        if (CShield > dmg)
        {
            CShield -= dmg; 
        }
        else
        {
            dmg -= (int)CShield;
            CShield = 0;
            CHealth -= dmg;
            HealthUI.UpdateUI(MaxHealth, CHealth);
            Fx.V_Amount += 0.3f;
        }
        Sound.pitch = Random.Range(2, 3);
        Sound.Play();
        ShieldUI.UpdateUI(MaxShield, CShield);
        Camera.main.GetComponent<ScreenShake>().Shake = 10;
    }
    public void Load()
    {
        SaveLoad.Load();
        LegGun = SaveData.LegGun;
        MaxHealth = SaveData.Health;
        MaxShield = SaveData.Shield;
        MaxEnergy = SaveData.Energy;
        ShieldDelay = SaveData.ShieldDelay;
        ShieldRate = SaveData.ShieldRate;
        ShieldCost = SaveData.ShieldCost;
        chargeRate = SaveData.ChargeRate;
        for (int i = 0; i < GunObjs.Length; i++)
        {
            GunObjs[i].gameObject.SetActive(false);
            if (GunObjs[i].name == LegGun)
            {
                GunObjs[i].gameObject.SetActive(true);
                SetupGun(i, "Leg");
            }
        }
        gunGroup.Optomize();
    }
    void SetupGun(int Gun, string slot)
    {
        if (slot == "Leg")
        {
            //hardcoding different upgrade levels, I think thats the way to go? IDK.
            if (LegGun == "Homing")
            {
                gunGroup.GunCost = 1.8f;
                if (SaveData.LegGunLevel == 0)
                {
                    gunGroup.FireBursts = 1;
                    gunGroup.FireDelay = 1f;
                    gunGroup.FireRate = 0.1f;
                }
                if (SaveData.LegGunLevel == 1)
                {
                    gunGroup.FireBursts = 3;
                    gunGroup.FireDelay = 1f;
                    gunGroup.FireRate = 0.1f;
                }
                if (SaveData.LegGunLevel == 2)
                {
                    gunGroup.FireBursts = 3;
                    gunGroup.FireDelay = 0.5f;
                    gunGroup.FireRate = 0.1f;
                }
                if (SaveData.LegGunLevel == 3)
                {
                    gunGroup.FireBursts = 5;
                    gunGroup.FireDelay = 0.5f;
                    gunGroup.FireRate = 0.1f;
                }
                if (SaveData.LegGunLevel == 4)
                {
                    gunGroup.FireBursts = 5;
                    gunGroup.FireDelay = 0.3f;
                    gunGroup.FireRate = 0.1f;
                }
                if (SaveData.LegGunLevel == 5)
                {
                    gunGroup.FireBursts = 7;
                    gunGroup.FireDelay = 0.3f;
                    gunGroup.FireRate = 0.1f;
                }
                if (SaveData.LegGunLevel == 6)
                {
                    gunGroup.FireBursts = 7;
                    gunGroup.FireDelay = 0.2f;
                    gunGroup.FireRate = 0.1f;
                }
                if (SaveData.LegGunLevel == 7)
                {
                    gunGroup.FireBursts = 7;
                    gunGroup.FireDelay = 0.1f;
                    gunGroup.FireRate = 0.1f;
                }
                if (SaveData.LegGunLevel == 8)
                {
                    gunGroup.FireBursts = 0;
                    gunGroup.FireDelay = 0;
                    gunGroup.FireRate = 0.1f;
                }
                if (SaveData.LegGunLevel == 9)
                {
                    gunGroup.FireBursts = 0;
                    gunGroup.FireDelay = 0;
                    gunGroup.FireRate = 0.07f;
                }
                if (SaveData.LegGunLevel == 10)
                {
                    gunGroup.FireBursts = 0;
                    gunGroup.FireDelay = 0;
                    gunGroup.FireRate = 0.05f;
                }
            }
            if (LegGun == "Minigun")
            {
                gunGroup.GunCost = 1;
                if (SaveData.LegGunLevel == 0)
                {
                    GunObjs[Gun].Find("MinigunGunMb2").gameObject.SetActive(false);
                    GunObjs[Gun].Find("MinigunGunMb3").gameObject.SetActive(false);
                    gunGroup.FireBursts = 5;
                    gunGroup.FireDelay = 0.5f;
                    gunGroup.FireRate = 0.1f;
                }
                if (SaveData.LegGunLevel == 1)
                {
                    GunObjs[Gun].Find("MinigunGunMb2").gameObject.SetActive(false);
                    GunObjs[Gun].Find("MinigunGunMb3").gameObject.SetActive(false);
                    gunGroup.FireBursts = 5;
                    gunGroup.FireDelay = 0.3f;
                    gunGroup.FireRate = 0.1f;
                }
                if (SaveData.LegGunLevel == 2)
                {
                    GunObjs[Gun].Find("MinigunGunMb2").gameObject.SetActive(true);
                    GunObjs[Gun].Find("MinigunGunMb3").gameObject.SetActive(false);
                    gunGroup.FireBursts = 5;
                    gunGroup.FireDelay = 0.5f;
                    gunGroup.FireRate = 0.1f;
                }
                if (SaveData.LegGunLevel == 3)
                {
                    GunObjs[Gun].Find("MinigunGunMb2").gameObject.SetActive(true);
                    GunObjs[Gun].Find("MinigunGunMb3").gameObject.SetActive(false);
                    gunGroup.FireBursts = 5;
                    gunGroup.FireDelay = 0.3f;
                    gunGroup.FireRate = 0.1f;
                }
                if (SaveData.LegGunLevel == 4)
                {
                    GunObjs[Gun].Find("MinigunGunMb2").gameObject.SetActive(true);
                    GunObjs[Gun].Find("MinigunGunMb3").gameObject.SetActive(true);
                    gunGroup.FireBursts = 5;
                    gunGroup.FireDelay = 0.5f;
                    gunGroup.FireRate = 0.1f;
                }
                if (SaveData.LegGunLevel == 5)
                {
                    GunObjs[Gun].Find("MinigunGunMb2").gameObject.SetActive(true);
                    GunObjs[Gun].Find("MinigunGunMb3").gameObject.SetActive(true);
                    gunGroup.FireBursts = 5;
                    gunGroup.FireDelay = 0.3f;
                    gunGroup.FireRate = 0.1f;
                }
                if (SaveData.LegGunLevel == 6)
                {
                    GunObjs[Gun].Find("MinigunGunMb2").gameObject.SetActive(true);
                    GunObjs[Gun].Find("MinigunGunMb3").gameObject.SetActive(true);
                    gunGroup.FireBursts = 7;
                    gunGroup.FireDelay = 0.3f;
                    gunGroup.FireRate = 0.1f;
                }
                if (SaveData.LegGunLevel == 7)
                {
                    GunObjs[Gun].Find("MinigunGunMb2").gameObject.SetActive(true);
                    GunObjs[Gun].Find("MinigunGunMb3").gameObject.SetActive(true);
                    gunGroup.FireBursts = 7;
                    gunGroup.FireDelay = 0.2f;
                    gunGroup.FireRate = 0.1f;
                }
                if (SaveData.LegGunLevel == 8)
                {
                    GunObjs[Gun].Find("MinigunGunMb2").gameObject.SetActive(true);
                    GunObjs[Gun].Find("MinigunGunMb3").gameObject.SetActive(true);
                    gunGroup.FireRate = 0.2f;
                    gunGroup.FireDelay = 0;
                    gunGroup.FireBursts = 0;
                }
                if (SaveData.LegGunLevel == 9)
                {
                    GunObjs[Gun].Find("MinigunGunMb2").gameObject.SetActive(true);
                    GunObjs[Gun].Find("MinigunGunMb3").gameObject.SetActive(true);
                    gunGroup.FireRate = 0.1f;
                    gunGroup.FireDelay = 0;
                    gunGroup.FireBursts = 0;
                }
                if (SaveData.LegGunLevel == 10)
                {
                    GunObjs[Gun].Find("MinigunGunMb2").gameObject.SetActive(true);
                    GunObjs[Gun].Find("MinigunGunMb3").gameObject.SetActive(true);
                    gunGroup.FireRate = 0.05f;
                    gunGroup.FireDelay = 0;
                    gunGroup.FireBursts = 0;
                }
            }
            if (LegGun == "Spread")
            {
                gunGroup.GunCost = 2;
                if (SaveData.LegGunLevel == 0)
                {
                    GunObjs[Gun].Find("Barrel3").gameObject.SetActive(false);
                    GunObjs[Gun].Find("Barrel4").gameObject.SetActive(false);
                    //t2
                    GunObjs[Gun].Find("Barrel5").gameObject.SetActive(false);
                    GunObjs[Gun].Find("Barrel6").gameObject.SetActive(false);
                    //t3
                    GunObjs[Gun].Find("Barrel7").gameObject.SetActive(false);
                    GunObjs[Gun].Find("Barrel8").gameObject.SetActive(false);
                    GunObjs[Gun].Find("Barrel9").gameObject.SetActive(false);
                    GunObjs[Gun].Find("Barrel10").gameObject.SetActive(false);
                    GunObjs[Gun].Find("Barrel11").gameObject.SetActive(false);
                    GunObjs[Gun].Find("Barrel12").gameObject.SetActive(false);
                    GunObjs[Gun].Find("Barrel13").gameObject.SetActive(false);
                    GunObjs[Gun].Find("Barrel14").gameObject.SetActive(false);
                    gunGroup.FireBursts = 1;
                    gunGroup.FireDelay = 0.5f;
                    gunGroup.FireRate = 0.1f;
                }
                if (SaveData.LegGunLevel == 1)
                {
                    GunObjs[Gun].Find("Barrel3").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel4").gameObject.SetActive(true);
                    //t2
                    GunObjs[Gun].Find("Barrel5").gameObject.SetActive(false);
                    GunObjs[Gun].Find("Barrel6").gameObject.SetActive(false);
                    //t3
                    GunObjs[Gun].Find("Barrel7").gameObject.SetActive(false);
                    GunObjs[Gun].Find("Barrel8").gameObject.SetActive(false);
                    GunObjs[Gun].Find("Barrel9").gameObject.SetActive(false);
                    GunObjs[Gun].Find("Barrel10").gameObject.SetActive(false);
                    GunObjs[Gun].Find("Barrel11").gameObject.SetActive(false);
                    GunObjs[Gun].Find("Barrel12").gameObject.SetActive(false);
                    GunObjs[Gun].Find("Barrel13").gameObject.SetActive(false);
                    GunObjs[Gun].Find("Barrel14").gameObject.SetActive(false);
                    gunGroup.FireBursts = 1;
                    gunGroup.FireDelay = 0.5f;
                    gunGroup.FireRate = 0.1f;
                }
                if (SaveData.LegGunLevel == 2)
                {
                    GunObjs[Gun].Find("Barrel3").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel4").gameObject.SetActive(true);
                    //t2
                    GunObjs[Gun].Find("Barrel5").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel6").gameObject.SetActive(true);
                    //t3
                    GunObjs[Gun].Find("Barrel7").gameObject.SetActive(false);
                    GunObjs[Gun].Find("Barrel8").gameObject.SetActive(false);
                    GunObjs[Gun].Find("Barrel9").gameObject.SetActive(false);
                    GunObjs[Gun].Find("Barrel10").gameObject.SetActive(false);
                    GunObjs[Gun].Find("Barrel11").gameObject.SetActive(false);
                    GunObjs[Gun].Find("Barrel12").gameObject.SetActive(false);
                    GunObjs[Gun].Find("Barrel13").gameObject.SetActive(false);
                    GunObjs[Gun].Find("Barrel14").gameObject.SetActive(false);
                    gunGroup.FireBursts = 1;
                    gunGroup.FireDelay = 0.5f;
                    gunGroup.FireRate = 0.1f;
                }
                if (SaveData.LegGunLevel == 2)
                {
                    GunObjs[Gun].Find("Barrel3").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel4").gameObject.SetActive(true);
                    //t2
                    GunObjs[Gun].Find("Barrel5").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel6").gameObject.SetActive(true);
                    //t3
                    GunObjs[Gun].Find("Barrel7").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel8").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel9").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel10").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel11").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel12").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel13").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel14").gameObject.SetActive(true);
                    gunGroup.FireBursts = 1;
                    gunGroup.FireDelay = 0.5f;
                    gunGroup.FireRate = 0.1f;
                }
                if (SaveData.LegGunLevel == 3)
                {
                    GunObjs[Gun].Find("Barrel3").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel4").gameObject.SetActive(true);
                    //t2
                    GunObjs[Gun].Find("Barrel5").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel6").gameObject.SetActive(true);
                    //t3
                    GunObjs[Gun].Find("Barrel7").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel8").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel9").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel10").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel11").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel12").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel13").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel14").gameObject.SetActive(true);
                    gunGroup.FireBursts = 2;
                    gunGroup.FireDelay = 0.5f;
                    gunGroup.FireRate = 0.1f;
                }
                if (SaveData.LegGunLevel == 4)
                {
                    GunObjs[Gun].Find("Barrel3").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel4").gameObject.SetActive(true);
                    //t2
                    GunObjs[Gun].Find("Barrel5").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel6").gameObject.SetActive(true);
                    //t3
                    GunObjs[Gun].Find("Barrel7").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel8").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel9").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel10").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel11").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel12").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel13").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel14").gameObject.SetActive(true);
                    gunGroup.FireBursts = 2;
                    gunGroup.FireDelay = 0.4f;
                    gunGroup.FireRate = 0.1f;
                }
                if (SaveData.LegGunLevel == 5)
                {
                    GunObjs[Gun].Find("Barrel3").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel4").gameObject.SetActive(true);
                    //t2
                    GunObjs[Gun].Find("Barrel5").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel6").gameObject.SetActive(true);
                    //t3
                    GunObjs[Gun].Find("Barrel7").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel8").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel9").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel10").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel11").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel12").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel13").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel14").gameObject.SetActive(true);
                    gunGroup.FireBursts = 2;
                    gunGroup.FireDelay = 0.3f;
                    gunGroup.FireRate = 0.1f;
                }
                if (SaveData.LegGunLevel == 6)
                {
                    GunObjs[Gun].Find("Barrel3").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel4").gameObject.SetActive(true);
                    //t2
                    GunObjs[Gun].Find("Barrel5").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel6").gameObject.SetActive(true);
                    //t3
                    GunObjs[Gun].Find("Barrel7").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel8").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel9").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel10").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel11").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel12").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel13").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel14").gameObject.SetActive(true);
                    gunGroup.FireBursts = 2;
                    gunGroup.FireDelay = 0.2f;
                    gunGroup.FireRate = 0.1f;
                }
                if (SaveData.LegGunLevel == 7)
                {
                    GunObjs[Gun].Find("Barrel3").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel4").gameObject.SetActive(true);
                    //t2
                    GunObjs[Gun].Find("Barrel5").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel6").gameObject.SetActive(true);
                    //t3
                    GunObjs[Gun].Find("Barrel7").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel8").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel9").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel10").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel11").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel12").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel13").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel14").gameObject.SetActive(true);
                    gunGroup.FireBursts = 3;
                    gunGroup.FireDelay = 0.2f;
                    gunGroup.FireRate = 0.1f;
                }
                if (SaveData.LegGunLevel == 8)
                {
                    GunObjs[Gun].Find("Barrel3").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel4").gameObject.SetActive(true);
                    //t2
                    GunObjs[Gun].Find("Barrel5").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel6").gameObject.SetActive(true);
                    //t3
                    GunObjs[Gun].Find("Barrel7").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel8").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel9").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel10").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel11").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel12").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel13").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel14").gameObject.SetActive(true);
                    gunGroup.FireBursts = 4;
                    gunGroup.FireDelay = 0.2f;
                    gunGroup.FireRate = 0.1f;
                }
                if (SaveData.LegGunLevel == 9)
                {
                    GunObjs[Gun].Find("Barrel3").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel4").gameObject.SetActive(true);
                    //t2
                    GunObjs[Gun].Find("Barrel5").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel6").gameObject.SetActive(true);
                    //t3
                    GunObjs[Gun].Find("Barrel7").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel8").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel9").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel10").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel11").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel12").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel13").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel14").gameObject.SetActive(true);
                    gunGroup.FireBursts = 5;
                    gunGroup.FireDelay = 0.2f;
                    gunGroup.FireRate = 0.1f;
                }
                if (SaveData.LegGunLevel == 10)
                {
                    GunObjs[Gun].Find("Barrel3").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel4").gameObject.SetActive(true);
                    //t2
                    GunObjs[Gun].Find("Barrel5").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel6").gameObject.SetActive(true);
                    //t3
                    GunObjs[Gun].Find("Barrel7").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel8").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel9").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel10").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel11").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel12").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel13").gameObject.SetActive(true);
                    GunObjs[Gun].Find("Barrel14").gameObject.SetActive(true);
                    gunGroup.FireBursts = 0;
                    gunGroup.FireDelay = 0;
                    gunGroup.FireRate = 0.1f;
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (CShield < MaxShield)
        {
            if (ShieldCD > ShieldDelay)
            {
                if (cEnergy > ShieldCost * Time.deltaTime)
                {
                    CShield += ShieldRate * Time.deltaTime;
                    cEnergy -= ShieldCost * Time.deltaTime;
                    ShieldUI.UpdateUI(MaxShield, CShield);
                }
            }
            else if (ShieldCD < ShieldDelay)
            {
                ShieldCD += Time.deltaTime;
            }
            else
            {
                ShieldUI.UpdateUI(MaxShield, CShield);
                ShieldCD = ShieldDelay;
            }
        }
        else if (CShield > MaxShield)
        {
            CShield = MaxShield;
        }
        if (cEnergy < MaxEnergy)
        {
            cEnergy += chargeRate * Time.deltaTime;
            if (cEnergy < 0)
            {
                cEnergy = 0;
            }
        }
        else if (cEnergy > MaxEnergy)
        {
            cEnergy = MaxEnergy;
        }
        GeneratorUI.UpdateUI(MaxEnergy, cEnergy);
    }
}
