using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreArea
{
    public ScoreType ScoreType { get; set; }
    public Action    OnClicked { get; set; }
}
