using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disjuntor : MonoBehaviour, IInteract
{
    public PuzzleController puzzleController { get; set; }

    public static bool forceRestore;

    void Awake()
    {
        puzzleController = FindObjectOfType<PuzzleController>();

        forceRestore = false;
    }

    public void Interaction()
    {
        if(forceRestore && FindObjectOfType<Inventory>().CheckCondition("Fusivel 1") && FindObjectOfType<Inventory>().CheckCondition("Fusivel 2") && FindObjectOfType<Inventory>().CheckCondition("Fusivel 3"))
            puzzleController.FinishPuzzle1();

        Feedback();
    }

    void Feedback()
    {
        // Toca som
        // Muda alavanca
    }
}
