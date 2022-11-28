using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTransition : MonoBehaviour
{
    public AudioSource LevelAudio;
    public AudioSource BossAudio;
    public AudioEchoFilter delay;
    public AudioLowPassFilter filter;
    public float[] lastBeat = new float[32];
    public float Beats = 0f;
    public float firstBeat = 0f;
    public float thisBeat = 0f;
    public float BPM = 0;
    public bool boss = false;
    public bool beat = false;
    public int curPulse = 0;
    public bool[] peaking = new bool[4];
    public float[] samples = new float[64];
    public float[] peak = new float[4];
    public float[] current = new float[4];
    private AudioSource currentAudio;
    // Start is called before the first frame update
    void Start()
    {
        currentAudio = LevelAudio;
    }
    public void transition()
    {

            if (LevelAudio.pitch > -0.1f)
            {
                LevelAudio.pitch -= Time.deltaTime / 2;
                delay.wetMix = 1 - LevelAudio.pitch;
                filter.cutoffFrequency = 22000 * LevelAudio.pitch;
            }
            else
            {
                if (!BossAudio.isPlaying)
                {
                    LevelAudio.Stop();
                    BossAudio.Play();
                thisBeat = 0;
                }
                if (delay.wetMix > 0)
                {
                BossAudio.pitch = 1 - delay.wetMix;
                delay.wetMix -= Time.deltaTime / 2;
                }
                else
                {
                BossAudio.pitch = 1;
                currentAudio = BossAudio;
                }
                filter.cutoffFrequency += 5 * filter.cutoffFrequency * Time.deltaTime;

            }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (boss)
        {
            transition();
        }
        beat = false;
        Beats = 0f;
        firstBeat = 99999999999f;
        current[0] = 0;
        current[1] = 0;
        current[2] = 0;
        current[3] = 0;
        currentAudio.GetSpectrumData(samples, 1, FFTWindow.Rectangular);
        for (int i = 0; i < samples.Length; i++)
        {
            //add all beats in lastbeat in this loop
            if (i < lastBeat.Length)
            {
                if (lastBeat[i] < firstBeat)
                {
                    firstBeat = lastBeat[i];
                }
                Beats += lastBeat[i];
            }
            if (i < samples.Length / 4)
            {
                current[0] += samples[i];
            }
            else if (i < samples.Length / 2)
            {
                current[1] += samples[i];
            }
            else if (i < samples.Length *0.75)
            {
                current[2] += samples[i];
            }
            else
            {
                current[3] += samples[i];
            }
        }
        for (int o =0; o < 4; o++)
        {
            if (current[o] > peak[o])
            {
                peaking[o] = true;
                beat = true;
            }
            else 
            {
                peaking[o] = false;
            }
        }
        if (beat && currentAudio.time > thisBeat)
        {
            lastBeat[curPulse % lastBeat.Length] = thisBeat;
            thisBeat = currentAudio.time;
            curPulse++;
        }
        if (currentAudio.time < 0.1f)
        {
            thisBeat = 0f;
        }
        Beats -= firstBeat * lastBeat.Length;
        BPM = Beats * 1.875f;//60/32... getting time in seconds, converting to 32nd notes in a minute
    }
}
