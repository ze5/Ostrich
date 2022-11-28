using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityBySong : MonoBehaviour
{
    public AudioTransition song;
    public float Wet = 0.5f;
    public int band = 0;
    private float startMag = 0f;
    private Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        song = Camera.main.GetComponent<AudioTransition>();
    }
    private void FixedUpdate()
    {
        if (startMag == 0f)
        {
            startMag = rig.velocity.magnitude;
        }
        else if (rig.velocity.sqrMagnitude > 0)
        {
            rig.velocity = rig.velocity.normalized * startMag * (((song.current[band] / song.peak[band])* Wet) + (1 -Wet)) ;
        }
    }

}
