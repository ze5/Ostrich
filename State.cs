using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public bool finished = false;
    public float timer = 0f;
    public MonoBehaviour[] childScripts;
    private float time = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Disable();
    }
    private void OnEnable()
    {
        foreach (MonoBehaviour script in childScripts)
        {
            script.enabled = true;
        }
        time = 0f;
        finished = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void Disable()
    {
        foreach (MonoBehaviour script in childScripts)
        {
            script.enabled = false;
        }
        gameObject.SetActive(false);
    }
    void DoState()
    {

    }
    public bool Done()
    {
        DoState();
        if (timer > 0f)
        {
            time += Time.deltaTime;
            if (time > timer)
            {
                time = 0f;
                finished = true;
            }
        }
        if (finished)
        {
            Disable();
        }
        return finished;
    }
}
