

using UnityEngine;

public class ScoreArea : MonoBehaviour, IScoreArea
{
    public enum ScoreType
    {
        Missed = 0,
        Good = 1,
        Great = 2,
        Perfect = 3,
    }

    [SerializeField] private ScoreType scoreType;
    
    public void Score()
    {
        
    }
}