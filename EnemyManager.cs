using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Spawn[] Enemys;
    public PathGroups[] paths;
    public Spawn[] bullets;
    public float[] EnemyOdds;
    public int[] MaxOfType;
    public float MinSpawnRate = 0.5f;
    public float MaxSpawnRate = 3f;
    public float DelayBetween = 0.5f;
    public int MaxSpawns = 2;
    public int MinType = 0;
    public int MaxType = 0;
    private int cType = 0;
    private GameObject currentEnemy;
    private float spawnTime = 0.0f;
    private float delayTime = 0.0f;
    private int NumSpawn = 0;
    private Vector3 StartPosition = new Vector3(15, 0);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <0)
        {
            delayTime -= Time.deltaTime;
            if (delayTime <0)
            {
                cType = Mathf.RoundToInt(Random.Range((float)MinType, (float)MaxType)); //dumb hack cuz int version of random range just casts to int and wont return last index unless random == 1
                if (Random.value < EnemyOdds[cType])
                {
                    //Allows limiting of Enemy types for performance reasons, IF/ELSE lets it skip the for loop for cheaper enemies.
                    if (MaxOfType[cType] > 0)
                    {
                        if (Enemys[cType].AliveChildren() < MaxOfType[cType])
                        {
                            Spawn();
                        }
                    }
                    else
                    {
                        Spawn();
                    }
                }

            }
        }
        if (NumSpawn > MaxSpawns)
        {
            spawnTime = Random.Range(MinSpawnRate, MaxSpawnRate);
            NumSpawn = 0;
        }
    }
    void Spawn()
    {
        currentEnemy = Enemys[cType].SpawnChild();
        currentEnemy.transform.position = StartPosition;
        if (paths[cType] != null)
        {
            currentEnemy.GetComponent<FollowPath>().paths = paths[cType].paths;
        }
        else
        {
            currentEnemy.transform.position =new Vector3(StartPosition.x,Random.Range(-4,4));
        }
        if (bullets[cType] != null)
        {
            currentEnemy.GetComponent<EnemyGunManager>().LoadGuns(bullets[cType]);
        }
        NumSpawn += Random.Range(1, 2);
        delayTime = DelayBetween;
        currentEnemy.transform.parent = transform;
    }
}
