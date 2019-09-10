using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject gameMenu;
    
    void Start()
    {
        gameMenu.SetActive(false);
    }
   
    void Update()
    {
        UpdateMenu();
    }

    void UpdateMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (Time.timeScale == 1)
            {
                Time.timeScale = 0f;
                gameMenu.SetActive(true);

            }
            else if(Time.timeScale == 0)
            {
                Time.timeScale = 1f;
                gameMenu.SetActive(false);
            }
        }
    }
}
