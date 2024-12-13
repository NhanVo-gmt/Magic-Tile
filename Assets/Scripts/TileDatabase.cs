using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "TileDatabase", menuName = "ScriptableObjects/TileDatabase")]
public class TileDatabase : ScriptableObject
{
    [SerializeField] private List<TileData> tileDatas = new();

    public List<TileData> GetTileDatas()
    {
        return tileDatas;
    }

    public TileData GetTileById(string Id)
    {
        return tileDatas.FirstOrDefault((a) => a.Id == Id);
    }
}

[Serializable]
public class TileData
{
    public string     Id;
    public GameObject Prefab;
}