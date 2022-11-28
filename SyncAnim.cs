using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncAnim : MonoBehaviour
{
    private Animator anim;

    private AudioTransition song;
    // Start is called before the first frame update
    void Start()
    {
        
        song = Camera.main.GetComponent<AudioTransition>();
        
    }
    private void OnEnable()
    {
        anim = GetComponent<Animator>();
        anim.StopPlayback();
        anim.Play(0, -1, (Time.time/10) % 1);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        anim.speed = song.BPM / 30;
    }
}
