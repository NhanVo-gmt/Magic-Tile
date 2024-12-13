using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData")]
public class LevelData : ScriptableObject
{
    public int             Id;
    public List<PhaseData> PhaseDatas;
}

[Serializable]
public class PhaseData
{
    public float  StartTime;
    public string TileId;
    public int    NumberOfTiles;
    public float  TimeBetween;
    public float  Speed;
}
