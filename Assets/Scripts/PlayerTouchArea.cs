using System;
using UnityEngine;

public class PlayerTouchArea : MonoBehaviour
{
    [SerializeField] private Vector2 size;

    private void OnMouseDown()
    {
        CheckArea();
    }

    void CheckArea()
    {
        Collider2D[] boxes = Physics2D.OverlapBoxAll(transform.position, size, 0f);
        foreach (var box in boxes)
        {
            if (box.GetComponent<Tile>())
            {
                Debug.Log("Score");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, size);
    }
}