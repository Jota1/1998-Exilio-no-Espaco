using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public GameObject optionDialogue;
    public bool onDialogue;

    [Header("Calculo AI")]
    public int choices;
    public int timeToChoices;

    public bool setChoice;

    void Start()
    {
        choices = 0;    
    }

    void Update()
    {
        ShowOption(onDialogue);
    }

    void ShowOption(bool show)
    {
        optionDialogue.SetActive(show);
    }

    public void SetActiveDialogue(bool active)
    {
        onDialogue = active;
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
            FindObjectOfType<PuzzleController>().counterP3_minutes = Random.Range(2f, 6f);
        } else
        {
            FindObjectOfType<PuzzleController>().counterP3_minutes = 5f;
        }

    }

    public void GoodChoice()
    {
        choices++;
    }

    public void BadChoice()
    {
        choices--;
    }
}
