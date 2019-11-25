using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChngeButtonMaterial : MonoBehaviour
{
    public Renderer button1_Render;
    public Renderer button2_Render; 
    public Renderer button3_Render;
    public Renderer button4_Render;
    public Renderer button5_Render;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SetLight.SetLights1)
        { 
            button1_Render.material.SetColor("_Color", Color.green);
        }
        else { button1_Render.material.SetColor("_Color", Color.red); }

        if (SetLight.SetLights2)
        {
            button2_Render.material.SetColor("_Color", Color.green);
        }
        else { button2_Render.material.SetColor("_Color", Color.red); }

        if (SetLight.SetLights3)
        {
            button3_Render.material.SetColor("_Color", Color.green);
        }
        else { button3_Render.material.SetColor("_Color", Color.red); }

        if (SetLight.SetLights4)
        {
            button4_Render.material.SetColor("_Color", Color.green);
        }
        else { button4_Render.material.SetColor("_Color", Color.red); }

        if (SetLight.SetLights5)
        {
            button5_Render.material.SetColor("_Color", Color.green);
        }
        else { button5_Render.material.SetColor("_Color", Color.red); }
    }
}
