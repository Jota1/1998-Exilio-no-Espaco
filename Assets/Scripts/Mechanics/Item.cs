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

    }

    public void Interaction()
    {


        FindObjectOfType<Inventory>().itemList.Add(gameObject.GetComponent<Item>());

        Feedback();
    }

    void Feedback()
    {
        // Toca som
    }

}
