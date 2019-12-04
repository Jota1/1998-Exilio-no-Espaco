using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disjuntor : MonoBehaviour, IInteract
{
    public PuzzleController puzzleController { get; set; }

    public static bool fusiveisColocados;

    public VoltimeterActive voltimeterPuzzle;

    public int puzzleNumber;
    public GameObject miniGame;

    // Feedbacks
    public AudioClip positiveFeedback;
    public AudioClip negativeFeedback;

    void Awake()
    {
        puzzleController = FindObjectOfType<PuzzleController>();

        fusiveisColocados = false;
    }

    public void Interaction()
    {
        if(FindObjectOfType<PuzzleController>().puzzleOrder == puzzleNumber) {

            if (!fusiveisColocados && FindObjectOfType<Inventory>().CheckCondition("Fusivel 1") && FindObjectOfType<Inventory>().CheckCondition("Fusivel 2") && FindObjectOfType<Inventory>().CheckCondition("Fusivel 3"))
            {
                miniGame.SetActive(true);
            }

            if (voltimeterPuzzle.forceRestore && fusiveisColocados)
            {
                // Finish puzzle 1
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
        FindObjectOfType<SoundController>().playerAudio.Stop();
        FindObjectOfType<SoundController>().PlaySFX(feedback);
    }
}
