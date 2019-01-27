using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotBarItem : MonoBehaviour
{
    public Outline outline;
    public Color[] colors;
    
    public void SetSelected(bool isSelected)
    {
        outline.effectColor = isSelected ? colors[1] : colors[0];
        outline.effectDistance = Vector2.one * (isSelected ? 4 : 1);
    }
}
