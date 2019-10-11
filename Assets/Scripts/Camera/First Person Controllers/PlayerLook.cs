﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    #region OLD
    //[SerializeField] private string mouseXInputName, mouseYInputName;
    //[SerializeField] private float mouseSensitivity;

    //[SerializeField] private Transform playerBody;

    //private float xAxisClamp;

    //private void Awake()
    //{
    //    LockCursor();
    //    xAxisClamp = 0.0f;
    //}


    //private void LockCursor()
    //{
    //    Cursor.lockState = CursorLockMode.Locked;
    //}

    //private void Update()
    //{
    //    CameraRotation();
    //}

    //private void CameraRotation()
    //{
    //    float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
    //    float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

    //    xAxisClamp += mouseY;

    //    if (xAxisClamp > 90.0f)
    //    {
    //        xAxisClamp = 90.0f;
    //        mouseY = 0.0f;
    //        ClampXAxisRotationToValue(270.0f);
    //    }
    //    else if (xAxisClamp < -90.0f)
    //    {
    //        xAxisClamp = -90.0f;
    //        mouseY = 0.0f;
    //        ClampXAxisRotationToValue(90.0f);
    //    }

    //    transform.Rotate(Vector3.left * mouseY);
    //    playerBody.Rotate(Vector3.up * mouseX);
    //}

    //private void ClampXAxisRotationToValue(float value)
    //{
    //    Vector3 eulerRotation = transform.eulerAngles;
    //    eulerRotation.x = value;
    //    transform.eulerAngles = eulerRotation;
    //}
    #endregion

    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    public GameObject character;

    public float viewRange;

    private void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);


        //limitando o eixo y da camera 
        //    if (transform.localEulerAngles.x > viewRange)
        //    {
        //        transform.localEulerAngles = new Vector3(viewRange, 0, 0);
        //    }
        //    else
        //    {
        //        if (transform.localEulerAngles.x < -viewRange)
        //        {
        //            transform.localEulerAngles = new Vector3(-viewRange, 0, 0);
        //        }
        //    }
    }

}