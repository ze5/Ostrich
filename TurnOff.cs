using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOff : MonoBehaviour
{
    public float lifetime = 1.0f;
    public float killtime = 0f;
    public bool explode = false;
    public bool dying = false;
    public bool ragDoll = false;
    public ParticleSystem explosion;
    private float killtimer;
    private float life = 0f;
    private Vector3 gone = new Vector3(100, 0);
    void Start()
    {
        life = lifetime;
        killtimer = killtime;
    }
    private void Awake()
    {
        life = lifetime;
        killtimer = killtime;
    }
    // Update is called once per frame
    void Update()
    {
        if (lifetime > 0)
        {
            life -= Time.deltaTime;
            if (life < 0)
            {
                Kill();
            }
        }
        if (dying)
        {
            Kill();
        }
        if (transform.position.x < -20)
        {
            killtimer = -1;
            Kill();
        }
    }
    public void Kill()
    {
        if (gameObject.GetComponent<Rigidbody2D>() != null)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        if (ragDoll)
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).GetComponent<Rigidbody2D>() != null)
                {
                    transform.GetChild(i).GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }
            }
        }
        dying = true;
        killtimer -= Time.deltaTime;
        if (explode)
        {
            if (explosion == null)
            {
                explosion = GetComponentInChildren<ParticleSystem>();

            }
            else if (!explosion.isPlaying)
            {
                explosion.transform.position = transform.position;
                explosion.transform.SetParent(null);
                explosion.Play();
                explosion.gameObject.SetActive(true);
            }
        }
        if (killtimer < 0)
        {
            life = lifetime;
            dying = false;
            transform.position = gone;
            gameObject.SetActive(false);
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        life = -1;
    }

}
