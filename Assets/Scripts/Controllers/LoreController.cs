using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreController : MonoBehaviour
{
    private AudioSource dialogueAudio;

    public AudioClip[] dialoguesVoice;

    public float[] dialogueTime;

    private void Awake()
    {
        dialogueAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DialogueEvent());
        }
    }

    IEnumerator DialogueEvent()
    {
        yield return null;
    }
}
