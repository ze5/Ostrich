using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTarget : MonoBehaviour
{
    public GameObject TargetGroup;
    public string TargetGroupName;
    public Homing This;
    private Vector3 distance;
    private Transform Target;
    // Update is called once per frame
    void Update()
    {
        if (TargetGroup == null)
        {
            TargetGroup = GameObject.Find(TargetGroupName);
        }
        for (int i = 0; i < TargetGroup.transform.childCount; i++)
        {
            if (TargetGroup.transform.GetChild(i).gameObject.activeSelf)
            {
                if ((TargetGroup.transform.GetChild(i).transform.position - transform.position).magnitude < distance.magnitude || distance.magnitude == 0)
                {
                    Target = TargetGroup.transform.GetChild(i);
                    distance = Target.position - transform.position;
                }
            }
            
        }
        if (Target != null)
        {
            This.target = Target;
            if (!Target.gameObject.activeSelf)
            {
                distance = Vector3.zero;
            }
        }
    }
}
