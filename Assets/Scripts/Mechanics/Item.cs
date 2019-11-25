using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteract
{
    public string nameItem;

    public string condition;

    public int puzzleNumber;

    public bool disappear;

    public bool showInInventory;

    public bool colectItem;

    public PuzzleController puzzleController { get; set; }

    public AudioClip positiveFeedback;
    public AudioClip negativeFeedback;

    void Awake()
    {
        puzzleController = FindObjectOfType<PuzzleController>();

        colectItem = false;

        
    }

    void CheckItemCollect()
    {

        // Puzzle 1
        if(nameItem == "Fusivel 1" || nameItem == "Fusivel 2" || nameItem == "Fusivel 3")
        {
            UIController.fusiveisCount++;
        }

        // Puzzle 2 
        if (nameItem == "Fiaçao")
        {
            UIController.fiacaoCount = 1;
        }

        if (nameItem == "Template")
        {
            UIController.templateCount = 1;
        }

        // Puzzle 3
        if (nameItem == "Circuito")
        {
            UIController.circuitoCount = 1;
        }


    }

    public void Interaction()
    {

        if ((FindObjectOfType<Inventory>().CheckCondition(condition) || condition == "") && puzzleNumber == FindObjectOfType<PuzzleController>().puzzleOrder && !colectItem)
        {
            colectItem = true;

            CheckItemCollect();

            // Adiciona no inventário
            FindObjectOfType<Inventory>().itemList.Add(gameObject.GetComponent<Item>());

            Feedback(positiveFeedback);

            if (disappear)
            {
                gameObject.SetActive(false);
            }
            
        } else
        {
            Feedback(negativeFeedback);
        }
    }

    void Feedback(AudioClip feedback)
    {
        // Toca som
        FindObjectOfType<SoundController>().PlaySFX(feedback);
    }

}
