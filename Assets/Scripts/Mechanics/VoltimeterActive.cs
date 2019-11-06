using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoltimeterActive : MonoBehaviour, IInteract
{
    private Voltimeter voltimeterController;

    public PuzzleController puzzleController { get; set; }

    public string[] condition;

    void Awake()
    {
        voltimeterController = FindObjectOfType<Voltimeter>();
        puzzleController = FindObjectOfType<PuzzleController>();
    }

    public void Interaction()
    {
        voltimeterController.ActiveVoltimeter();
    }

    public void CheckCondition()
    {


    }
}
