using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    public Rigidbody rb;
    public float turnSpeedZeroG;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(Vector3.up * turnSpeedZeroG, ForceMode.Impulse);
        }
    }
}
