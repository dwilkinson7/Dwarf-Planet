using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepRun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * 25);
    }
}
