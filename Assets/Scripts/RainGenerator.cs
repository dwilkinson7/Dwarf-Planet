using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainGenerator : MonoBehaviour
{
    public GameObject rainDrop;
    private int rainProbability = 20;
    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 100) < rainProbability)
        {
            Object.Destroy(Instantiate(rainDrop, transform.position, Quaternion.identity), 15.0f); ;
        }
    }
}
