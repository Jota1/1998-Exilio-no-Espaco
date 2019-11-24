using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text questLog;
    public static int actualPuzzle;

    [Header("Quest Log Puzzle 1")]
    public static int fusiveisCount;

    [Header("Quest Log Puzzle 2")]
    public static int templateCount;
    public static int fiacaoCount;

    [Header("Quest Log Puzzle 3")]
    public static int circuitoCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        QuestLogUpdate();
    }

    void QuestLogUpdate()
    {

        if(actualPuzzle == 1)
        {
            questLog.text = "Encontre os fusíveis. (" + fusiveisCount.ToString() + "/3)";
        }

        else if(actualPuzzle == 2)
        {
            questLog.text = "Consiga as peças para reparar o botão. Painel (" + templateCount.ToString() + "/1) (" + fiacaoCount.ToString() + "/1)"; 
        } 

        else if(actualPuzzle == 3)
        {
            questLog.text = "Procure pelo circuito. (" + circuitoCount.ToString() + "/1)";
        }
    }
}
