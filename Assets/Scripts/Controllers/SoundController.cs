using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Awake()
    {
        playerAudio = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
    }

    public void PlaySFX(AudioClip effect)
    {
        playerAudio.PlayOneShot(effect);
    }

    public void PlayDialogue(AudioClip dialogue)
    {
        playerAudio.Stop();
        playerAudio.PlayOneShot(dialogue);
    }
}
