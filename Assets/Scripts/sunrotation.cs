using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunrotation : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.left, 5 * Time.deltaTime);
    }
}
