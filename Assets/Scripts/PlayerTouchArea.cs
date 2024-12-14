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
        ScoreType currentScoreType = ScoreType.Missed;

        Collider2D[] boxes = Physics2D.OverlapBoxAll(transform.position, size, 0f);
        foreach (var box in boxes)
        {
            if (box.TryGetComponent<IScoreArea>(out IScoreArea scoreArea))
            {
                if ((int)scoreArea.ScoreType > (int)currentScoreType)
                {
                    currentScoreType = scoreArea.ScoreType;
                }
            }
        }
        
        ScoreController.AddScore(currentScoreType);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, size);
    }
}