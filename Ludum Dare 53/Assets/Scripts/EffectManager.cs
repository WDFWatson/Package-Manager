using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager instance;
    
    public Animator warningLight;
    public AudioSource audioPlayer;
    public AudioClip correctAudio;
    public AudioClip incorrectAudio;
    public AudioClip pickUpAudio;
    public AudioClip dropAudio;
    public AudioClip spawnAudio;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (audioPlayer == null)
        {
            audioPlayer = GetComponent<AudioSource>();
        }
    }

    public void Correct()
    {
        audioPlayer.PlayOneShot(correctAudio);
    }

    public void Incorrect()
    {
        audioPlayer.PlayOneShot(incorrectAudio);
        warningLight.SetTrigger("Warning");
    }

    public void PickUp()
    {
        audioPlayer.PlayOneShot(pickUpAudio);
    }

    public void Drop()
    {
        audioPlayer.PlayOneShot(dropAudio);
    }

    public void Spawn()
    {
        audioPlayer.PlayOneShot(spawnAudio);
    }
    
    
}
