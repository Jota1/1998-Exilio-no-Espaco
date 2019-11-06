using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Voltimeter : MonoBehaviour
{
    public Scrollbar voltimeter;
    public Scrollbar randomMark;

    public GameObject voltimeterBar;

    public float randomValue;

    public bool back;
    public bool completeMinigame;

    public int countRights;
    public float voltValue;
    public float modSpeed;

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
            if(voltimeter.value >= randomMark.value - 0.02f  && voltimeter.value <= randomMark.value + 0.02f)
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

        RandomizeMark();
    }

    void WrongTiming()
    {
        if (countRights > 0)
            countRights--;
        else
            Fail();

        RandomizeMark();
    }

    void Complete()
    {
        voltimeterBar.SetActive(false);
        countRights = 0;
        completeMinigame = true;
        Disjuntor.forceRestore = true;
    }

    void Fail()
    {
        voltimeterBar.SetActive(false);
        countRights = 0;
        completeMinigame = false;
    }

    public void ActiveVoltimeter()
    {
        voltimeterBar.SetActive(true);
        completeMinigame = false;
    }
}
