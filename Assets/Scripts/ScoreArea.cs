

using System;
using UnityEngine;

public enum ScoreType
{
    Missed  = 0,
    Good    = 1,
    Great   = 2,
    Perfect = 3,
}

public class ScoreArea : MonoBehaviour, IScoreArea
{
    [SerializeField] private ScoreType scoreType;

    public ScoreType ScoreType
    {
        get { return scoreType; }
        set {}
    }

    public Action OnClicked { get; set; }
}