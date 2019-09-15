using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteract
{
    PuzzleController puzzleController { get; set; }

    void Interaction();
}
