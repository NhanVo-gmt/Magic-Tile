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
        ScoreType  currentScoreType = ScoreType.Missed;
        IScoreArea scoreArea = null;

        Collider2D[] boxes = Physics2D.OverlapBoxAll(transform.position, size, 0f);
        foreach (var box in boxes)
        {
            if (box.TryGetComponent<IScoreArea>(out IScoreArea foundScoreArea))
            {
                if ((int)foundScoreArea.ScoreType > (int)currentScoreType)
                {
                    currentScoreType = foundScoreArea.ScoreType;
                    scoreArea        = foundScoreArea;
                }
            }
             
        }
        
        if (currentScoreType != ScoreType.Missed) scoreArea.OnClicked?.Invoke();
        ScoreController.AddScore(currentScoreType);
        SoundManager.PlayOneShot(SoundClipType.Click);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, size);
    }
}