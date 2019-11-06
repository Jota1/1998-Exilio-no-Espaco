using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disjuntor : MonoBehaviour, IInteract
{
    public PuzzleController puzzleController { get; set; }

    public static bool forceRestore;

    public AudioClip positiveFeedback;
    public AudioClip negativeFeedback;

    void Awake()
    {
        puzzleController = FindObjectOfType<PuzzleController>();

        forceRestore = false;
    }

    public void Interaction()
    {
        if (forceRestore && FindObjectOfType<Inventory>().CheckCondition("Fusivel 1") && FindObjectOfType<Inventory>().CheckCondition("Fusivel 2") && FindObjectOfType<Inventory>().CheckCondition("Fusivel 3"))
        {
            Feedback(positiveFeedback);
            puzzleController.FinishPuzzle1();
        }

        Feedback(negativeFeedback);
    }

    void Feedback(AudioClip feedback)
    {
        // Toca som
        FindObjectOfType<SoundController>().PlaySFX(feedback);
    }
}
