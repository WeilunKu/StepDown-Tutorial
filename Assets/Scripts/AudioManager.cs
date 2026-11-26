using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    new AudioSource audio;
    
    [Header("Audio Clips")]
    public AudioClip landClip;
    public AudioClip jumpClip;
    public AudioClip hurtOnCeilingClip;
    public AudioClip hurtOnSpikeClip;
    
    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlayEffect(AudioClip clip)
         => audio.PlayOneShot(clip);
}
