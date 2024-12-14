using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData")]
public class LevelData : ScriptableObject
{
    public int             Id;
    public int             EndTime;
    public int[]           StarScore = new int[3];
    public List<PhaseData> PhaseDatas;
}

[Serializable]
public class PhaseData
{
    public float  StartTime;
    public string TileId;
    public int    NumberOfTiles;
    public float  TimeBetweenTiles;
    public float  Speed;
}
