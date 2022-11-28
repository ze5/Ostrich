using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    public Transform target;
    public float force = 1f;
    public float maxVelocity = 10f;
    private Rigidbody2D rig;
    private Vector3 dirforce;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && target.gameObject.activeSelf)
        {
            if ((target.position - transform.position).magnitude < 50)
            {
                dirforce = (target.position - transform.position).normalized;
                
            }
            else
            {
                dirforce = Vector2.right * Random.value;
            }
            
        }
        else
        {
            dirforce = Vector2.right * Random.value;
        }
        dirforce *= force * Time.deltaTime;
        rig.AddForce(dirforce);
        if (rig.velocity.sqrMagnitude > maxVelocity * maxVelocity)
        {
            rig.velocity = Vector3.ClampMagnitude(rig.velocity, maxVelocity);
        }
    }
}
