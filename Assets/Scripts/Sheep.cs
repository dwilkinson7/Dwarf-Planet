using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public GameObject sheep;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(sheep, transform.position + 55 * transform.up.normalized, Quaternion.identity);
        }
    }

    void Update()
    {

    }

}
