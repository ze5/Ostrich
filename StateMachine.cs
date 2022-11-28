using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State[] states;
    public Vector2[] next;
    public int CState = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (states[CState].Done())
        {
            if (next[CState].x > -1f)
            {
                CState = Mathf.RoundToInt(Random.Range(next[CState].x, next[CState].y)) % states.Length;
            }
            else
            {
                CState = (CState + 1) % states.Length;
            }
        }
            states[CState].gameObject.SetActive(true);
    }
}
