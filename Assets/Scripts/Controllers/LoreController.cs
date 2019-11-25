using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreController : MonoBehaviour
{
    private AudioSource dialogueAudio;

    public AudioClip[] dialogueVoice;

    public float[] dialogueTime;

    public int dialoguePlaying;

    public int limitTalk;

    private void Awake()
    {
        dialogueAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && dialoguePlaying == 0)
        {
            StartCoroutine(DialogueEvent());
        }
    }


    IEnumerator DialogueEvent()
    {
        while(dialoguePlaying < limitTalk)
        {
            dialogueAudio.PlayOneShot(dialogueVoice[dialoguePlaying]);
            yield return new WaitForSeconds(dialogueTime[dialoguePlaying]);
            dialoguePlaying++;
        }

        yield return null;
    }
}
