﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleController : MonoBehaviour
{
    public int puzzleOrder;

    public static bool endGame;

    // time
    public GameObject timeCounterP3;
    public Text timeCounterP3_TEXT;
    public float totalTime;

    // Puzzle 2
    public GameObject doorToPuzzle2;

    // Puzzle 3
    public GameObject doorToPuzzle3;

    // Dialogos de finalização do puzzle
    public GameObject finishPuzzle1Dialogue;
    public GameObject finishPuzzle2Dialogue;
    public GameObject finishPuzzle3Dialogue;

    void Start()
    {
        puzzleOrder = 1;
        timeCounterP3.SetActive(false);        
    }

    void Update()
    {
        if (puzzleOrder == 2 && !endGame && Player.detect_sala_criogenia_P3)
        {
            totalTime -= Time.deltaTime;
            TimerPuzzle3(totalTime);
        }
    }

    public void FinishPuzzle1()
    {
        FindObjectOfType<Inventory>().ClearList();
        FindObjectOfType<AIController>().onDialogue = true;
        finishPuzzle1Dialogue.GetComponent<LoreController>().CallEventDialogue();
        puzzleOrder++;
        doorToPuzzle2.SetActive(false);
    }

    public void FinishPuzzle2()
    {
        FindObjectOfType<Inventory>().ClearList();
        FindObjectOfType<AIController>().onDialogue = true;
        finishPuzzle1Dialogue.GetComponent<LoreController>().CallEventDialogue();
        puzzleOrder++;
        doorToPuzzle3.SetActive(false);
    }

    public void FinishPuzzle3()
    {
        FindObjectOfType<Inventory>().ClearList();
        finishPuzzle1Dialogue.GetComponent<LoreController>().CallEventDialogue();
        endGame = true;
    }

    void TimerPuzzle3 (float totalSeconds)
    {

        // inicia contador 
        timeCounterP3.SetActive(true);

        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.RoundToInt(totalSeconds % 60f);

        string formatedSeconds = seconds.ToString();

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        timeCounterP3_TEXT.text = minutes.ToString("00") + ":" + seconds.ToString("00");


        if (totalTime <= 0)
        {
            //acaba puzzle
            Debug.Log("morreu p3");
        }
    }
}
