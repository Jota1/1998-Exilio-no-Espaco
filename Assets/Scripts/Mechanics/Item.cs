using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteract
{
    public Transform handPlayer;

    public bool canHold;

    public PuzzleController puzzleController { get; set; }

    void Awake()
    {
        puzzleController = FindObjectOfType<PuzzleController>();
    }

    public void Interaction()
    {
        transform.position = handPlayer.position;

        Feedback();
    }

    void Feedback()
    {
        // Toca som
    }

}
