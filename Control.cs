using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public float movespeed = 10f;
    public GunGroup Wep1;
    public Player player;
    private Rigidbody2D rig;
    private Vector2 velocity;
    private Vector2 pos;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Wep1.GunCost < player.cEnergy)
            {
                if (Wep1.Fire())
                {
                    player.cEnergy -= Wep1.GunCost;
                }
            }
            player.ShieldCD = 0;
        }
        velocity.x = Input.GetAxis("Horizontal");
        velocity.y = Input.GetAxis("Vertical");
        anim.SetFloat("PlayerVelocity", velocity.y);
        if ((velocity*2).sqrMagnitude > 4f)
        {
            velocity.Normalize();
        }
        velocity *= movespeed;
        pos.x = transform.position.x;
        pos.y = transform.position.y;
        rig.MovePosition(velocity + pos);
    }
}
