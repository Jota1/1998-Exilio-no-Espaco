using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disjuntor : MonoBehaviour, IInteract
{
    public int numberOrderPuzzle;

    public PuzzleController puzzleController { get; set; }

    void Awake()
    {
        puzzleController = FindObjectOfType<PuzzleController>();
    }

    public void Interaction()
    {
         Feedback();
         puzzleController.FinishPuzzle();
    }

    void Feedback()
    {
        // Toca som
        // Muda alavanca
    }
}
