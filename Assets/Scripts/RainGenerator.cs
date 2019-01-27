using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainGenerator : MonoBehaviour
{
    public GameObject rainDrop;
    private int rainProbability = 5;
    // Update is called once per frame
    void Update()
    {
        Vector3 rightOffset, frontOffset;
        rightOffset = Random.Range(-5, 5)*transform.right.normalized;
        frontOffset = Random.Range(-5, 5)*transform.forward.normalized;
        if (Random.Range(0, 100) < rainProbability)
        {
            Object.Destroy(Instantiate(rainDrop, transform.position + rightOffset + frontOffset, Quaternion.identity), 15.0f); ;
        }
    }
}
