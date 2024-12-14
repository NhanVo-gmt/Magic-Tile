using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private const int MISSED_SCORE = 0;
    private const int GOOD_SCORE = 1;
    private const int GREAT_SCORE = 4;
    private const int PERFECT_SCORE = 10;
    
    private static ScoreController Instance;

    private static UIGame uiGame;
    private static int    currentScore;
    
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        uiGame       = UIController.GetPage<UIGame>();
        currentScore = 0;
    }

    public static void AddScore(ScoreType scoreType)
    {
        switch (scoreType)
        {
            case ScoreType.Missed:
                currentScore += MISSED_SCORE;
                break;
            case ScoreType.Good:
                currentScore += GOOD_SCORE;
                break;
            case ScoreType.Great:
                currentScore += GREAT_SCORE;
                break;
            case ScoreType.Perfect:
                currentScore += PERFECT_SCORE;
                break;
        }
        
        uiGame.UpdateCurrentScore(currentScore);
        uiGame.UpdateFeedback(scoreType.ToString());
    }
    
}