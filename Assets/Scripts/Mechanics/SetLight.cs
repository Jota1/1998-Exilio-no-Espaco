using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLight : MonoBehaviour, IInteract
{
    public bool lightSet1;
    public bool lightSet2;
    public bool lightSet3;
    public bool lightSet4;
    public bool lightSet5;

    public GameObject miniPuzzle;

    public Image[] lightsFeedback;

    public bool finishMinigame;

    public Item fusivel1;

    public PuzzleController puzzleController { get; set; }


    private void Start()
    {
        lightSet1 = true;
        lightSet2 = true;
        lightSet3 = true;
        lightSet4 = true;
        lightSet5 = true;
    }

    private void Update()
    {
        // Set light
        if (lightSet1)
        {
            lightsFeedback[0].color = Color.green;
        } else
        {
            lightsFeedback[0].color = Color.red;
        }

        if (lightSet2)
        {
            lightsFeedback[1].color = Color.green;
        }
        else
        {
            lightsFeedback[1].color = Color.red;
        }

        if (lightSet3)
        {
            lightsFeedback[2].color = Color.green;
        }
        else
        {
            lightsFeedback[2].color = Color.red;
        }

        if (lightSet4)
        {
            lightsFeedback[3].color = Color.green;
        }
        else
        {
            lightsFeedback[3].color = Color.red;
        }

        if (lightSet5)
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
        if(!lightSet1 && !lightSet2 && !lightSet3 && !lightSet4 && !lightSet5 && !finishMinigame)
        {
            miniPuzzle.SetActive(false);
            finishMinigame = true;
            FindObjectOfType<Inventory>().itemList.Add(fusivel1);
        }
    }

    public void SetLight1()
    {
        // 4
        lightSet2 = true;
        lightSet3 = false;
        lightSet4 = false;
    }

    public void SetLight2()
    {
        // 5
        lightSet1 = false;
        lightSet5 = true;
    }

    public void SetLight3()
    {
        // 1
        lightSet1 = false;
        lightSet3 = false;
        lightSet4 = true;
    }

    public void SetLight4()
    {
        // 2
        lightSet2 = false;
        lightSet5 = false;
    }

    public void SetLight5()
    {
        // 3
        lightSet1 = true;
        lightSet4 = false;
        lightSet5 = true;
       
    }
}
