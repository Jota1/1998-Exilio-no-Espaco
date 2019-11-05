using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveItem : MonoBehaviour, IInteract
{
    public PuzzleController puzzleController { get; set; }

    public Item itemReceive;

    public string receiveItem;

    public Transform holdPosition;

    public bool isSettingObj; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isSettingObj)
            itemReceive.transform.position = holdPosition.position;
    }

    public void Interaction()
    {
        if(itemReceive.nameItem == receiveItem)
        {
            isSettingObj = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        //if(col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        //{
        //    itemReceive = col.gameObject.GetComponent<Player>().item;
        //}
    }
}
