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


    public void FinishSetLight()
    {
        if(lightSet1 && lightSet2 && lightSet3 && lightSet4 && lightSet5 && !finishMinigame)
        {
            finishMinigame = true;
            FindObjectOfType<Inventory>().itemList.Add(fusivel1);
        }
    }

    public void SetLight1()
    {
        // 4
    }

    public void SetLight2()
    {
        // 5
    }

    public void SetLight3()
    {
        // 1
    }

    public void SetLight4()
    {
        // 2
    }

    public void SetLight5()
    {
        // 3
    }
}
