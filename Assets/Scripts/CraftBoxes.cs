using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftBoxes : MonoBehaviour {
    public float distance;
    public float delay;
    public Transform box;
    public int count;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Spawn());	
	}

    IEnumerator Spawn()
    {
        Vector3 location;
        Transform nuBox;
        for (int i = 0; i < count; i++)
        {
            location = Random.onUnitSphere * distance;
            
            nuBox = Instantiate(box);
            nuBox.position = location;
            nuBox.up = location - transform.position;
            if (i % 10 == 0)
                yield return new WaitForSeconds(delay);
        }
    }
}
