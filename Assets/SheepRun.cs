using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepRun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(transform.up.x * 0.06f, transform.up.y * 0.06f + transform.up.z * 0.06f);
        GetComponent<Rigidbody>().AddForce(Vector3.forward * 20);
    }
}
