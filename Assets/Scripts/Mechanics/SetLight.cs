using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLight : MonoBehaviour
{
    public bool lightSet1;
    public bool lightSet2;
    public bool lightSet3;
    public bool lightSet4;
    public bool lightSet5;

    public bool finishMinigame;

    public Item fusivel1;


    private void Start()
    {
        lightSet1 = true;
        lightSet2 = true;
        lightSet3 = true;
        lightSet4 = true;
        lightSet5 = true;
    }

    public void FinishSetLight()
    {
        if(!lightSet1 && !lightSet2 && !lightSet3 && !lightSet4 && !lightSet5 && !finishMinigame)
        {
            finishMinigame = true;
            FindObjectOfType<Inventory>().itemList.Add(fusivel1);
        }
    }

    public void SetLight1()
    {
        // 4
        lightSet1 = false;
        lightSet3 = false;
        lightSet4 = true;
    }

    public void SetLight2()
    {
        // 5
        lightSet2 = true;
        lightSet4 = false;
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
        lightSet3 = true;
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
