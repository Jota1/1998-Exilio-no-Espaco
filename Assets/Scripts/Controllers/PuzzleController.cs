using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{

    public GameObject feedback;

    // Número do Puzzle / Qual puzzle o jogador está ?
    public int puzzleOrder;

    // Quantidades dos passo a passo
    public int puzzleNumber1;
    public int puzzleNumber2;
    public int puzzleNumber3;

    // Passo a passo do jogador
    public int puzzleProgression;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            feedback.SetActive(false);
        }

    }

    public void FinishPuzzle()
    {
        if(puzzleProgression == puzzleNumber1 && puzzleOrder == 1)
        {
            puzzleOrder++;
            feedback.SetActive(true);
        } 
        else if (puzzleProgression == puzzleNumber2 && puzzleOrder == 2)
        {
            puzzleOrder++;
        }
        else if (puzzleProgression == puzzleNumber2 && puzzleOrder == 3)
        {
            puzzleOrder++;
        }
 
    }
}
