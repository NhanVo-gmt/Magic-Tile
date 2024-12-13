using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TileDatabase", menuName = "ScriptableObjects/TileDatabase")]
public class TileDatabase : ScriptableObject
{
    [SerializeField] private List<TileData> tileDatas = new();

    public List<TileData> GetTileDatas()
    {
        return tileDatas;
    }
}

[Serializable]
public class TileData
{
    public string     Id;
    public GameObject Prefab;
}