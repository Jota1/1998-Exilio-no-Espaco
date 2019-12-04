using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoltimeterActive : MonoBehaviour, IInteract
{
    private Voltimeter voltimeterController;

    public PuzzleController puzzleController { get; set; }

    public string[] condition;

    public int puzzleNumber;

    public bool forceRestore;

    void Awake()
    {
        voltimeterController = FindObjectOfType<Voltimeter>();
        puzzleController = FindObjectOfType<PuzzleController>();
    }

    public void Interaction()
    {
        // Interação com o voltimetro
        if(CheckCondition() && FindObjectOfType<PuzzleController>().puzzleOrder == puzzleNumber && Disjuntor.fusiveisColocados && !forceRestore)
            voltimeterController.ActiveVoltimeter();
    }

    public bool CheckCondition()
    {
        return FindObjectOfType<Inventory>().CheckCondition(condition[0]) && FindObjectOfType<Inventory>().CheckCondition(condition[1]);
    }
}
