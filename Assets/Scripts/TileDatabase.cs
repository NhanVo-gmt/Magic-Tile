namespace DefaultNamespace
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "TileDatabase", menuName = "ScriptableObjects/TileDatabase")]
    public class TileDatabase : ScriptableObject
    {
        public List<TileData> tileDatas = new();
    }

    [Serializable]
    public class TileData
    {
        public string     Id;
        public GameObject Prefab;
    }
}