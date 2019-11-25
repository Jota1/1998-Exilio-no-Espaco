using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreController : MonoBehaviour
{
    public AudioSource dialogueAudio;

    public AudioClip[] dialogueVoice;

    public float[] dialogueTime;

    public int dialoguePlaying;

    public int limitTalk;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && dialoguePlaying == 0)
        {
            CallEventDialogue();
        }
    }

    public void CallEventDialogue()
    {
        StartCoroutine(DialogueEvent());
    }


    IEnumerator DialogueEvent()
    {
        while(dialoguePlaying < limitTalk)
        {
            dialogueAudio.Stop();
            dialogueAudio.PlayOneShot(dialogueVoice[dialoguePlaying]);
            yield return new WaitForSeconds(dialogueTime[dialoguePlaying]);
            dialoguePlaying++;
        }

        yield return null;
    }
}
