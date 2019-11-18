using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIController : MonoBehaviour
{
    public GameObject optionDialogue;

    public Text textQuestion;
    public Text textAnswerGood;
    public Text textAnswerBad;

    public string[] question;
    public string[] answerGood;
    public string[] answerBad;

    public bool onDialogue;

    [Header("Calculo AI")]
    public int choices;
    public int choicesAnswer;
    public int timeToChoices;

    public bool setChoice;

    void Start()
    {
        choices = 0;    
    }

    void Update()
    {

        if(onDialogue)
            ShowOption();
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
            FindObjectOfType<PuzzleController>().counterP3_minutes = Random.Range(2f, 5f);
        } else
        {
            FindObjectOfType<PuzzleController>().counterP3_minutes = 5f;
        }

    }

    public void GoodChoice()
    {
        choices++;
        choicesAnswer++;

        onDialogue = false;

        if (choicesAnswer == timeToChoices)
            ReactChoice();
    }

    public void BadChoice()
    {
        choices--;
        choicesAnswer++;

        onDialogue = false;

        if (choicesAnswer == timeToChoices)
            ReactChoice();
    }
}
