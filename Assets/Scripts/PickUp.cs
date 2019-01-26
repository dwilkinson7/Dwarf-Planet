using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public int amount = 1;
    string type = "";

    // Start is called before the first frame update
    void Start()
    {
        type = gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 5);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            col.gameObject.GetComponent<Inventory>().addItem(type, amount);
        }
    }
}
