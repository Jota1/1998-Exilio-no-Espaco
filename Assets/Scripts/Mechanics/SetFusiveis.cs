using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetFusiveis : MonoBehaviour
{
    public bool SetFusiveis1;
    public bool SetFusiveis2;
    public bool SetFusiveis3;

    public GameObject miniPuzzle;

    public Image[] lightsFeedback;

    public bool finishMinigame;

    public Item disjuntor;

    public PuzzleController puzzleController { get; set; }


    private void Start()
    {
        SetFusiveis1 = true;
        SetFusiveis2 = true;
        SetFusiveis3 = true;
    }

    private void Update()
    {
        // Set light
        if (SetFusiveis1)
        {
            lightsFeedback[0].rectTransform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else
        {
            lightsFeedback[0].rectTransform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (SetFusiveis2)
        {
            lightsFeedback[1].rectTransform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else
        {
            lightsFeedback[1].rectTransform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (SetFusiveis3)
        {
            lightsFeedback[2].rectTransform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else
        {
            lightsFeedback[2].rectTransform.rotation = Quaternion.Euler(0, 0, 0);
        }

        FinishSetLight();
    }

    public void Interaction()
    {
        if (!finishMinigame)
            miniPuzzle.SetActive(true);
    }

    public void FinishSetLight()
    {
        if (!SetFusiveis1 && !SetFusiveis2 && !SetFusiveis3 && !finishMinigame)
        {
            miniPuzzle.SetActive(false);
            finishMinigame = true;
            FindObjectOfType<Inventory>().itemList.Add(disjuntor);
        }
    }

    public void SetFusivel1()
    {
        // 2 
        SetFusiveis2 = !SetFusiveis2;
        SetFusiveis3 = true;
        SetFusiveis1 = true;
    }

    public void SetFusivel2()
    {
        // 3
        SetFusiveis3 = false;
    }

    public void SetFusivel3()
    {
        // 1 
        SetFusiveis1 = !SetFusiveis1;
    }
}
