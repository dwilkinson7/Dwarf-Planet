using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBar : MonoBehaviour
{
    public HotBarItem[] items;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Select(int index)
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].SetSelected(index == i);
        }
    }

    internal void SetQuantity(string type, int qty)
    {
        int index = -1;
        switch (type)
        {
            case "Straw":
                index = 0;
                break;
            case "Wood":
                index = 1;
                break;
            case "Stone":
                index = 2;
                break;
            case "Iron":
                index = 3;
                break;
        }

        if (index > -1)
        {
            items[index].TextMesh_Qty.text = qty.ToString();
        }
    }
}
