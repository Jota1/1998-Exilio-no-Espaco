﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteract
{
    public string nameItem;

    public bool isHolding;

    public Transform handPosition;

    public PuzzleController puzzleController { get; set; }

    void Awake()
    {
        puzzleController = FindObjectOfType<PuzzleController>();

        isHolding = false;
    }

    public void Interaction()
    {
        

        Feedback();
    }

    void Feedback()
    {
        // Toca som
    }

}
