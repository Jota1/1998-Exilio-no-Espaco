using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource playerAudio;
   
    void Awake()
    {
        //playerAudio = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
    }

    public void PlaySFX(AudioClip effect)
    {
        playerAudio.PlayOneShot(effect);
    }

    public void PlayDialogue(AudioClip dialogue)
    {
        //playerAudio.Stop();
        playerAudio.PlayOneShot(dialogue);
    }
}
