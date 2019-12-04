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

    // Play Feedback
    public void PlaySFX(AudioClip effect)
    {
        playerAudio.Stop();
        playerAudio.PlayOneShot(effect);
    }

    public void PlayDialogue(AudioClip dialogue)
    {
        //playerAudio.Stop();
        playerAudio.PlayOneShot(dialogue);
    }
}
