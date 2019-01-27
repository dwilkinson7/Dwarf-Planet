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
}
