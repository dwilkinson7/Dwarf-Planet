using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewSmashableData", menuName = "ScriptableObjects/Smashable Data", order = 1)]
public class SmashableData : ScriptableObject
{
    public int HitsPerChunk = 4;
    public int ChunksPerLife = 1;
    public float GrowthDelay = 10f;
    public float GrowthTime = 2f;
    public float height = 3f;
}
