using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLight : MonoBehaviour, IInteract
{
    public static bool SetLights1;
    public static bool SetLights2;
    public static bool SetLights3;
    public static bool SetLights4;
    public static bool SetLights5;    

    public GameObject miniPuzzle;
    public GameObject miniPuzzleV2; //novo mini puzzle com camera e props

    public Image[] lightsFeedback;

    public bool finishMinigame;

    public Item fusivel1;

    public PuzzleController puzzleController { get; set; }


    private void Start()
    {
        SetLights1 = true;
        SetLights2 = true;
        SetLights3 = true;
        SetLights4 = true;
        SetLights5 = true;
    }

    private void Update()
    {
        // Set light
        if (SetLights1)
        {
            lightsFeedback[0].color = Color.green;
        } else
        {
            lightsFeedback[0].color = Color.red;
        }

        if (SetLights2)
        {
            lightsFeedback[1].color = Color.green;
        }
        else
        {
            lightsFeedback[1].color = Color.red;
        }

        if (SetLights3)
        {
            lightsFeedback[2].color = Color.green;
        }
        else
        {
            lightsFeedback[2].color = Color.red;
        }

        if (SetLights4)
        {
            lightsFeedback[3].color = Color.green;
        }
        else
        {
            lightsFeedback[3].color = Color.red;
        }

        if (SetLights5)
        {
            lightsFeedback[4].color = Color.green;
        }
        else
        {
            lightsFeedback[4].color = Color.red;
        }

        FinishSetLight();
    }

    public void Interaction()
    {
        if (!finishMinigame)
        {
            miniPuzzle.SetActive(true);
            miniPuzzleV2.SetActive(true);
        }
    }

    public void FinishSetLight()
    {
        if(!SetLights1 && !SetLights2 && !SetLights3 && !SetLights4 && !SetLights5 && !finishMinigame)
        {
            miniPuzzle.SetActive(false);
            miniPuzzleV2.SetActive(false);
            FindObjectOfType<Inventory>().itemList.Add(fusivel1);
            finishMinigame = true;
        }
    }

    public void SetLight1()
    {
        // 4
        SetLights2 = true;
        SetLights3 = false;
        SetLights4 = false;
    }

    public void SetLight2()
    {
        // 5
        SetLights1 = false;
        SetLights5 = true;
    }

    public void SetLight3()
    {
        // 1
        SetLights1 = false;
        SetLights3 = false;
        SetLights4 = true;
    }

    public void SetLight4()
    {
        // 2
        SetLights2 = false;
        SetLights5 = false;
    }

    public void SetLight5()
    {
        // 3
        SetLights1 = true;
        SetLights4 = false;
        SetLights5 = true;
       
    }
}
