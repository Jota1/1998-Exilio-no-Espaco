using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteract
{
    public string nameItem;

    public string condition;

    public int puzzleNumber;

    public bool disappear;

    public bool colectItem;

    public PuzzleController puzzleController { get; set; }

    public AudioClip positiveFeedback;
    public AudioClip negativeFeedback;

    void Awake()
    {
        puzzleController = FindObjectOfType<PuzzleController>();

        colectItem = false;

        // Alteração
    }

    public void Interaction()
    {

        if ((FindObjectOfType<Inventory>().CheckCondition(condition) || condition == "") && puzzleNumber == FindObjectOfType<PuzzleController>().puzzleOrder && !colectItem)
        {
            colectItem = true;

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
