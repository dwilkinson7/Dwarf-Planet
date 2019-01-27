using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleloop : MonoBehaviour
{
    float speed = 3f;
    float depth = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scaleInOut = 1f + 0.1f*(Mathf.Sin(Time.time * speed));
        transform.localScale = new Vector3(scaleInOut, scaleInOut, scaleInOut);
        //transform.localScale += new Vector3(0.1f, 0, 0);
    }
}
