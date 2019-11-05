using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorChange : MonoBehaviour 
{
    public Texture2D cursorDefault;
    public Texture2D cursorInteract;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    
    
    void Update()
    {
        UpdateCursorTexture();
    }

    void UpdateCursorTexture ()
    {
        Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit2;

        if (Physics.Raycast (ray2, out hit2, 10000))
        {
            if (hit2.transform.tag == "Interagivel")
            {
                Cursor.SetCursor (cursorInteract, hotSpot, cursorMode);
            }
            else { Cursor.SetCursor(cursorDefault, hotSpot, cursorMode); }
        }
    }
}
