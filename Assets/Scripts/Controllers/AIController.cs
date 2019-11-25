using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIController : MonoBehaviour
{

    [Header("Calculo AI")]
    // Calculo para decisão
    public int choicePuzzle;
    public static bool calculateTime;

    public float[] minTime;
    public float[] timeCompletePuzzle;

    private float timerPuzzle;

    public float extraTime;

    public bool countTime;

    void Start()
    {
        calculateTime = false;    
    }

    void Update()
    {

        if (calculateTime)
        {
            calculateTime = false;
            ReactChoice();
        }

        // Calcula o tempo para resolução dos puzzle
        if (countTime)
        {
            timerPuzzle += Time.deltaTime;

            timeCompletePuzzle[choicePuzzle] = timerPuzzle;

        }  

    }

    public void EnableTimer()
    {
        countTime = true;
    }

    public void DisableTimer()
    {
        countTime = false;
    }

    public void ReactChoice()
    {

            float media = 0;

            for (int i = 0; i < timeCompletePuzzle.Length; i++)
            {
                media += timeCompletePuzzle[i];
            }

            media /= timeCompletePuzzle.Length;

            FindObjectOfType<PuzzleController>().totalTime = minTime[2] + media;
        
    }
}
