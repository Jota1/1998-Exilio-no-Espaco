using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    //OLD
    [SerializeField]
    GameObject firstCam;
    [SerializeField]
    GameObject thirdCam;
    [SerializeField]
    GameObject trueThirdCam;

    public static int camMode; // 0 = thirdPerson / 1 = firstPerson

    void Start()
    {
        camMode = 0;
    }
   
    void Update()
    {
        //SwitchCam();        
    }

    //OLD
    void SwitchCam ()
    {
        if (Input.GetKeyDown(KeyCode.C) && camMode == 0)
        {
            camMode = 1;

            FindObjectOfType<Player>().cam = firstCam.transform;
        }
        else if (Input.GetKeyDown(KeyCode.C) && camMode == 1)
        {
            camMode = 0;

            FindObjectOfType<Player>().cam = trueThirdCam.transform;
        }

        StartCoroutine(SwitchCamEnum());      
    }
    IEnumerator SwitchCamEnum ()
    {
        yield return new WaitForSeconds(0.01f);
        if (camMode == 0)
        {
            thirdCam.SetActive(true);
            firstCam.SetActive(false);
        }
        if (camMode == 1)
        {
            thirdCam.SetActive(false);
            firstCam.SetActive(true);
        }
    }
}
