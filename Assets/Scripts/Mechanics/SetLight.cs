using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLight : MonoBehaviour, IInteract
{
    public bool SetFusiveis1;
    public bool SetFusiveis2;
    public bool SetFusiveis3;
    public bool SetFusiveis4;
    public bool SetFusiveis5;

    public GameObject miniPuzzle;

    public Image[] lightsFeedback;

    public bool finishMinigame;

    public Item fusivel1;

    public PuzzleController puzzleController { get; set; }


    private void Start()
    {
        SetFusiveis1 = true;
        SetFusiveis2 = true;
        SetFusiveis3 = true;
        SetFusiveis4 = true;
        SetFusiveis5 = true;
    }

    private void Update()
    {
        // Set light
        if (SetFusiveis1)
        {
            lightsFeedback[0].color = Color.green;
        } else
        {
            lightsFeedback[0].color = Color.red;
        }

        if (SetFusiveis2)
        {
            lightsFeedback[1].color = Color.green;
        }
        else
        {
            lightsFeedback[1].color = Color.red;
        }

        if (SetFusiveis3)
        {
            lightsFeedback[2].color = Color.green;
        }
        else
        {
            lightsFeedback[2].color = Color.red;
        }

        if (SetFusiveis4)
        {
            lightsFeedback[3].color = Color.green;
        }
        else
        {
            lightsFeedback[3].color = Color.red;
        }

        if (SetFusiveis5)
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
        if(!finishMinigame)
            miniPuzzle.SetActive(true);
    }

    public void FinishSetLight()
    {
        if(!SetFusiveis1 && !SetFusiveis2 && !SetFusiveis3 && !SetFusiveis4 && !SetFusiveis5 && !finishMinigame)
        {
            miniPuzzle.SetActive(false);
            finishMinigame = true;
            FindObjectOfType<Inventory>().itemList.Add(fusivel1);
        }
    }

    public void SetLight1()
    {
        // 4
        SetFusiveis2 = true;
        SetFusiveis3 = false;
        SetFusiveis4 = false;
    }

    public void SetLight2()
    {
        // 5
        SetFusiveis1 = false;
        SetFusiveis5 = true;
    }

    public void SetLight3()
    {
        // 1
        SetFusiveis1 = false;
        SetFusiveis3 = false;
        SetFusiveis4 = true;
    }

    public void SetLight4()
    {
        // 2
        SetFusiveis2 = false;
        SetFusiveis5 = false;
    }

    public void SetLight5()
    {
        // 3
        SetFusiveis1 = true;
        SetFusiveis4 = false;
        SetFusiveis5 = true;
       
    }
}
