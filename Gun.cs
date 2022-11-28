using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Spawn pool;
    public float force = 200f;
    public float randomAngle = 0f;
    public float minforce = 0f;
    public float FireRate = -1f;
    public float FireDelay = 0.0f;
    public int FireBursts = 0;
    public ParticleSystem particle;
    private float rForce;
    private float delay = 0.0f;
    private int burst = 0;
    private float Rate = 0f;
    private Quaternion Angle;
    private GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        Angle = transform.localRotation;
        rForce = force;
    }
    public GameObject Fire()
    {
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
            Rate -= Time.deltaTime;
            if (Rate < 0)
            {
                bullet = pool.SpawnChild();
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                Rigidbody2D rig = bullet.GetComponent<Rigidbody2D>();
                rig.WakeUp();
                if (minforce > 0)
                {
                    rForce = Random.Range(minforce, force);
                }
                rig.AddForce(transform.right * rForce * rig.mass);
                Rate = FireRate;
                burst--;
                if (particle != null)
                {
                    particle.Emit(1);
                }
                if (randomAngle>0)
                {
                    transform.localRotation = Angle * Quaternion.Euler(0, 0, Random.Range(-randomAngle, randomAngle));
                }
                return bullet;
                
            }
        }
        return null;
    }

}
