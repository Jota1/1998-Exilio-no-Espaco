using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIController : MonoBehaviour
{
    [Header("Text Question")]
    public GameObject optionDialogue;

    public Text textQuestion;
    public Text textAnswerGood;
    public Text textAnswerBad;

    public string[] question;
    public string[] answerGood;
    public string[] answerBad;

    public bool onDialogue;

    [Header("Calculo AI")]
    // Escolhas
    public float choices;
    public int choicesAnswer;
    public int timeToChoices;

    public bool setChoice;

    // Calculo para decisão
    public float[] minTime;
    public float[] timeCompletePuzzle;

    private float timerPuzzle;

    public float extraTime;

    public bool countTime;

    

    void Start()
    {
        choices = 0;    
    }

    void Update()
    {
        // Mostra perguntas de Hal
        if(onDialogue)
            ShowOption();

        // Calcula o tempo para resolução dos puzzles
        if (countTime)
        {
            timerPuzzle += Time.deltaTime;

            timeCompletePuzzle[choicesAnswer] = timerPuzzle;

        }  


    }

    public void EnableTimer()
    {
        countTime = true;
    }

    public void DisableTimer()
    {
        countTime = false;
    }

    void ShowOption()
    {
        textQuestion.text = question[choicesAnswer];
        textAnswerGood.text = answerGood[choicesAnswer];
        textAnswerBad.text = answerBad[choicesAnswer];

        optionDialogue.SetActive(true);
        onDialogue = false;
    }

    void CalculateChoices()
    {
        if(choices < timeToChoices / 2)
        {
            setChoice = false;
        } else
        {
            setChoice = true;
        }
    }

    public void ReactChoice()
    {
        CalculateChoices();

        if (!setChoice)
        {
            float media = 0;

            for (int i = 0; i < timeCompletePuzzle.Length; i++)
            {
                media += timeCompletePuzzle[i];
            }

            media /= timeCompletePuzzle.Length;

            FindObjectOfType<PuzzleController>().counterP3_minutes = minTime[2] + media * choices;
        } 

    }

    public void GoodChoice()
    {
        choices += 0.5f;
        choicesAnswer++;

        onDialogue = false;

        if (choicesAnswer == timeToChoices)
            ReactChoice();
    }

    public void BadChoice()
    {
        if (choices > 0)
            choices -= 0.5f;
        else
            choices = 0f;

        choicesAnswer++;

        onDialogue = false;

        if (choicesAnswer == timeToChoices)
            ReactChoice();
    }
}
