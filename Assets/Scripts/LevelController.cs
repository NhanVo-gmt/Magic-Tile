using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class LevelPhase
{
    public List<Transform> spawners;
        
    // Change per phase
    public PhaseData              phaseData;
    public ObjectPool<GameObject> pool;
    public int                    NumberOfTilesLeft;

    public LevelPhase(List<Transform> spawners)
    {
        this.spawners = spawners;
    }
    
    public void Init(PhaseData phaseData, ObjectPool<GameObject> pool)
    {
        this.phaseData         = phaseData;
        this.pool              = pool;
        this.NumberOfTilesLeft = phaseData.NumberOfTiles;
    }

    public void SpawnTile()
    {
        if (NumberOfTilesLeft <= 0) return;
        
        NumberOfTilesLeft--;

        Transform  spawner = spawners[Random.Range(0, spawners.Count)];
        GameObject tileGO  = pool.Get();
        tileGO.transform.position = spawner.transform.position;
        tileGO.transform.rotation = Quaternion.identity;
        
        tileGO.GetComponent<Tile>().Initialize(pool, phaseData.Speed);
    }
}

public class LevelController : MonoBehaviour
{
    [SerializeField] private TileDatabase    tileDatabase;
    [SerializeField] private LevelData       currentLevelData;
    [SerializeField] private List<Transform> spawners;

    private static LevelController                            Instance;
    private        Dictionary<string, ObjectPool<GameObject>> tilePools = new();
    
    // Single Level
    private bool       isPlaying  = false;
    private LevelPhase levelPhase;
    private PhaseData  currentPhase;
    private int        nextPhaseIndex;
    private float      timeElapse = 0f;

    private Sequence spawnSequence;
    
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);
        
        foreach (var tile in tileDatabase.GetTileDatas())
        {
            GameObject tileGo = tile.Prefab;
            var _pool = new ObjectPool<GameObject>(() =>
            {
                return Instantiate(tileGo, Vector2.zero, Quaternion.identity);
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

        levelPhase = new(spawners);
    }

    private void Start()
    {
        LoadLevel();
    }

    void LoadLevel()
    {
        isPlaying    = true;
        timeElapse   = 0f;
        currentPhase = null;
    }

    void Update()
    {
        if (!isPlaying) return;

        timeElapse += Time.deltaTime;
        
        CheckNewPhase();
    }

    void SpawnCurrentPhaseTile()
    {
        if (currentPhase == null) return;
        
        spawnSequence = DOTween.Sequence()
            .AppendInterval(currentPhase.TimeBetween) // Create a delay in the sequence
            .AppendCallback(levelPhase.SpawnTile)
            .SetLoops(-1);
    }


    void CheckNewPhase()
    {
        if (nextPhaseIndex >= currentLevelData.PhaseDatas.Count) return;
        
        if (timeElapse >= currentLevelData.PhaseDatas[nextPhaseIndex].StartTime)
        {
            currentPhase = currentLevelData.PhaseDatas[nextPhaseIndex];
            nextPhaseIndex++;
            
            if (spawnSequence != null) spawnSequence.Kill();
            
            levelPhase.Init(currentPhase, tilePools[currentPhase.TileId]);
            SpawnCurrentPhaseTile();
        }
    }
}
