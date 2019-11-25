﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disjuntor : MonoBehaviour, IInteract
{
    public PuzzleController puzzleController { get; set; }

    public static bool forceRestore;
    public static bool fusiveisColocados;

    public int puzzleNumber;

    // Feedbacks
    public AudioClip positiveFeedback;
    public AudioClip negativeFeedback;

    void Awake()
    {
        puzzleController = FindObjectOfType<PuzzleController>();

        forceRestore = false;

        fusiveisColocados = false;
    }

    public void Interaction()
    {
        if(FindObjectOfType<PuzzleController>().puzzleOrder == puzzleNumber) { 

            if (forceRestore && fusiveisColocados)
            {
                Feedback(positiveFeedback);
                puzzleController.FinishPuzzle1();
            }
            else
            {
                Feedback(negativeFeedback);
            }

        }
    }

    void Feedback(AudioClip feedback)
    {
        // Toca som
        FindObjectOfType<SoundController>().PlaySFX(feedback);
    }
}
