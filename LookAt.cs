using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public float speed = 1f;
    public float angleOffset = 0f;
    public Transform lookObj;
    private void Start()
    {
     if (lookObj == null)
        {
            lookObj = GameObject.Find("Player").transform;
        }
    }
    private void FixedUpdate()
    {
        if (lookObj.position.x < transform.position.x)
        {
            if (lookObj.position.y >= transform.position.y)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, Vector3.Angle(transform.position - lookObj.position, Vector3.left)), Time.deltaTime * speed);
            }
            else
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, Vector3.Angle(transform.position - lookObj.position, Vector3.right) + 180), Time.deltaTime * speed);
            }
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 180), Time.deltaTime * speed);
        }
    }
}
