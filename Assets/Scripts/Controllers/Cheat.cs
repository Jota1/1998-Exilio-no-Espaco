﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    public GameObject player;

    public Transform sala1;
    public Transform sala2;
    public Transform sala3;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player.transform.position = sala1.position;
            FindObjectOfType<PuzzleController>().puzzleOrder = 1;
            FindObjectOfType<UIController>().actualPuzzle = 1;
            FindObjectOfType<Inventory>().ClearList();
            Disjuntor.fusiveisColocados = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player.transform.position = sala2.position;
            FindObjectOfType<PuzzleController>().puzzleOrder = 2;
            FindObjectOfType<UIController>().actualPuzzle = 2;
            FindObjectOfType<Inventory>().ClearList();
            Disjuntor.fusiveisColocados = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            player.transform.position = sala3.position;
            FindObjectOfType<PuzzleController>().puzzleOrder = 3;
            Player.detect_sala_criogenia_P3 = true;
            FindObjectOfType<UIController>().actualPuzzle = 3;
            FindObjectOfType<Inventory>().ClearList();
            Disjuntor.fusiveisColocados = true;
        }
    }
}
