using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Tile : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    
    private ObjectPool<GameObject> pool;
    private float                  speed = 0;
    private IScoreArea[]           scoreAreas;

    private void Awake()
    {
        scoreAreas = GetComponentsInChildren<IScoreArea>();
        foreach (var scoreArea in scoreAreas)
        {
            scoreArea.OnClicked += OnScoreAreaClicked;
        }
    }

    private void OnDestroy()
    {
        foreach (var scoreArea in scoreAreas)
        {
            scoreArea.OnClicked -= OnScoreAreaClicked;
        }
    }

    private void OnScoreAreaClicked()
    {
        particleSystem.Play();
    }

    public void Initialize(ObjectPool<GameObject> pool, float speed)
    {
        this.pool  = pool;
        this.speed = speed;
    }

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DeadArea"))
        {
            Dispose();
        }
    }


    void Dispose()
    {
        pool.Release(gameObject);
    }
}