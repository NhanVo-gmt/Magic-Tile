using System;
using UnityEngine;
using UnityEngine.Pool;

public class Tile : MonoBehaviour
{
    private ObjectPool<GameObject> pool;
    private float speed = 0;
    
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