using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteract
{
    public string nameItem;

    public string condition;

    public PuzzleController puzzleController { get; set; }

    void Awake()
    {
        puzzleController = FindObjectOfType<PuzzleController>();

        // Alteração
    }

    public void Interaction()
    {

        if (FindObjectOfType<Inventory>().CheckCondition(condition) || condition == "")
        {
            FindObjectOfType<Inventory>().itemList.Add(gameObject.GetComponent<Item>());

            Feedback();
        }
    }

    void Feedback()
    {
        // Toca som
    }

}
