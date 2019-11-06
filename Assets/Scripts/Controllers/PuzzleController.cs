﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{

    public int puzzleOrder;

    public static bool endGame;

    void Start()
    {
        puzzleOrder = 1;
    }

    public void FinishPuzzle1()
    {
        FindObjectOfType<Inventory>().ClearList();
        puzzleOrder++;
    }

    public void FinishPuzzle2()
    {
        FindObjectOfType<Inventory>().ClearList();
        puzzleOrder++;
    }

    public void FinishPuzzle3()
    {
        FindObjectOfType<Inventory>().ClearList();
        endGame = true;
    }
}
