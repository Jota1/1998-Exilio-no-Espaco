using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleController : MonoBehaviour
{
    public int puzzleOrder;

    public static bool endGame;

    // timer
    public GameObject timeCounterP3;
    public Text timeCounterP3_TEXT; 
    public float counterP3_seconds, counterP3_minutes;

    // Puzzle 2
    public GameObject doorToPuzzle2;

    // Puzzle 3
    public GameObject doorToPuzzle3;

    void Start()
    {
        puzzleOrder = 1;
        timeCounterP3.SetActive(false);        
    }

    private void Update()
    {
        TimerPuzzle3();
    }

    public void FinishPuzzle1()
    {
        FindObjectOfType<Inventory>().ClearList();
        puzzleOrder++;
        doorToPuzzle2.SetActive(false);
    }

    public void FinishPuzzle2()
    {
        FindObjectOfType<Inventory>().ClearList();
        puzzleOrder++;
        doorToPuzzle3.SetActive(false);
    }

    public void FinishPuzzle3()
    {
        FindObjectOfType<Inventory>().ClearList();
        endGame = true;
    }

    void TimerPuzzle3 ()
    {
        if (puzzleOrder == 4 && !endGame && Player.detect_sala_criogenia_P3)
        {
            //inicia contador 
            timeCounterP3.SetActive(true);
            //timeCounterP3_TEXT.text = counterP3--.ToString();
            counterP3_minutes = (int)(Time.time / 60f);
            counterP3_seconds = (int)(Time.time % 60f);
            timeCounterP3_TEXT.text = counterP3_minutes.ToString("00") + ":" + counterP3_seconds.ToString("00");
        }

        if (counterP3_minutes >= 1)
        {
            //acaba puzzle
            Debug.Log("morreu p3");
        }
    }
}
