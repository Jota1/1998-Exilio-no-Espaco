using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteract
{
    public string nameItem;

    public string condition;

    public int puzzleNumber;

    public bool disappear;

    public PuzzleController puzzleController { get; set; }

    void Awake()
    {
        puzzleController = FindObjectOfType<PuzzleController>();

        // Alteração
    }

    public void Interaction()
    {

        if ((FindObjectOfType<Inventory>().CheckCondition(condition) || condition == "") && puzzleNumber == 1)
        {
            FindObjectOfType<Inventory>().itemList.Add(gameObject.GetComponent<Item>());

            if (disappear)
            {
                gameObject.SetActive(false);
            }

            Feedback();
        }
    }

    void Feedback()
    {
        // Toca som
    }

}
