using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    Dictionary<string, int> items = new Dictionary<string, int>();
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addItem(string type, int amount)
    {
        items.TryGetValue()
        items.Add(type, amount);
        Debug.Log("Added: " + type + " of amount: " + amount.ToString());
    }
}
