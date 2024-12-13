using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class LevelController : MonoBehaviour
{
    [SerializeField] private TileDatabase tileDatabase;
    [SerializeField] private LevelData    currentLevelData;
    
    private Dictionary<string, ObjectPool<GameObject>> tilePools = new();
    
    void Awake()
    {
        foreach (var tile in tileDatabase.GetTileDatas())
        {
            GameObject tileGo = tile.Prefab;
            var _pool = new ObjectPool<GameObject>(() =>
            {
                return Instantiate(tileGo, Vector3.zero, Quaternion.identity);
            }, (go) =>
            {
                go.SetActive(true);
            }, (go) =>
            {
                go.SetActive(false);
            }, (go) =>
            {
                Destroy(go);
            });
            
            tilePools.Add(tile.Id, _pool);
        }
    }
}
