using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Voltimeter : MonoBehaviour
{
    public Scrollbar voltimeter;
    public Scrollbar randomMark;

    public VoltimeterActive[] voltimeterObj;

    public GameObject voltimeterBar;

    public float randomValue;

    public bool back;
    public bool completeMinigame;

    public int countRights;
    public float voltValue;
    public float modSpeed;

    public AudioClip positiveFeedback;
    public AudioClip negativeFeedback;

    // Start is called before the first frame update
    void Start()
    {
        RandomizeMark();

        voltimeterBar.SetActive(false);
        countRights = 0;
        voltimeter.value = 0.025f;
        back = false;
    }

    // Update is called once per frame
    void Update()
    {
        StoppingTiming();

        if(!completeMinigame)
            UpdateTiming();
    }

    void StoppingTiming()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(voltimeter.value >= randomMark.value - 0.09f  && voltimeter.value <= randomMark.value + 0.09f)
            {
                RightTiming();
            } else
            {
                WrongTiming();
            }
        }
            
    }

    void RandomizeMark()
    {
        float n = Random.Range(0.025f, 1f);

        randomMark.value = n;
    }

    void UpdateTiming()
    {

        if (countRights == 0)
            modSpeed = 1f;
        if (countRights == 1)
            modSpeed = 1.5f;
        if (countRights == 2)
            modSpeed = 2f;


        if (!back)
        {
            voltimeter.value += voltValue * modSpeed * Time.deltaTime;

            if (voltimeter.value >= 1f)
                back = true;

        } else
        {
            voltimeter.value -= voltValue * modSpeed * Time.deltaTime;

            if (voltimeter.value <= 0.025f)
                back = false;
        }

    }

    void RightTiming()
    {
        if (countRights < 2)
            countRights++;
        else
            Complete();

        Feedback(positiveFeedback);

        RandomizeMark();
    }

    void WrongTiming()
    {
        if (countRights > 0)
            countRights--;
        else
            Fail();

        Feedback(negativeFeedback);

        RandomizeMark();
    }

    void Complete()
    {

        if (FindObjectOfType<PuzzleController>().puzzleOrder == 1)
        {
            voltimeterObj[0].forceRestore = true;
        }

        // Finish Puzzles
        if (FindObjectOfType<PuzzleController>().puzzleOrder == 2)
        {
            voltimeterObj[1].forceRestore = true;
            FindObjectOfType<PuzzleController>().FinishPuzzle2();
        }

        if (FindObjectOfType<PuzzleController>().puzzleOrder == 3)
        {
            voltimeterObj[2].forceRestore = true;
            FindObjectOfType<PuzzleController>().FinishPuzzle3();
        }

        countRights = 0;
        completeMinigame = true;
        voltimeterBar.SetActive(false);
    }

    void Fail()
    {
        // voltimeterBar.SetActive(false);
        countRights = 0;
        completeMinigame = false;
    }

    void Feedback(AudioClip feedback)
    {
        // Toca som
        FindObjectOfType<SoundController>().PlaySFX(feedback);
    }

    public void ActiveVoltimeter()
    {
        voltimeterBar.SetActive(true);
        completeMinigame = false;
    }
}
