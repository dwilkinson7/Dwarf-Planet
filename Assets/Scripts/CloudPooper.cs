using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudPooper : MonoBehaviour
{

    public GameObject pivot;
    public float magnitude = 10;
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pivot.transform.position, transform.right, speed * Time.deltaTime);
        transform.Rotate(transform.up * Time.deltaTime * magnitude * Random.Range(-1f, 1f), Space.Self);

    }
}
