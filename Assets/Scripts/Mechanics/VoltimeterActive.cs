using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoltimeterActive : MonoBehaviour, IInteract
{
    private Voltimeter voltimeterController;

    public PuzzleController puzzleController { get; set; }

    public string[] condition;

    public int puzzleNumber;

    void Awake()
    {
        voltimeterController = FindObjectOfType<Voltimeter>();
        puzzleController = FindObjectOfType<PuzzleController>();
    }

    public void Interaction()
    {
        if(CheckCondition() && FindObjectOfType<PuzzleController>().puzzleOrder == puzzleNumber)
            voltimeterController.ActiveVoltimeter();
    }

    public bool CheckCondition()
    {
        return FindObjectOfType<Inventory>().CheckCondition(condition[0]) && FindObjectOfType<Inventory>().CheckCondition(condition[1]);
    }
}
