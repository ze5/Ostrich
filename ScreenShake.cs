using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private Vector3 ShakeV = Vector3.zero;
    public float Shake = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Shake > 0)
        {
            ShakeV = Random.insideUnitCircle * Shake * Time.deltaTime * 5;
            transform.position = ShakeV + Vector3.back;
            Shake -= (Time.deltaTime + (Shake * Time.deltaTime)) * 2;

        }
        else
        {
            transform.position = Vector3.back;
        }
    }
}
