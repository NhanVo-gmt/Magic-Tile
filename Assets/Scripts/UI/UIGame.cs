using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : UIPage
{
    [Header("Score")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI feedBackText;

    [Header("Progress")]
    [SerializeField] private Slider progressSlider;
    
    public override void Initialise()
    {
        
    }

    public void UpdateCurrentScore(int currentScore)
    {
        scoreText.text = currentScore.ToString();
    }
    
    public void UpdateFeedback(string feedBack)
    {
        feedBackText.text = feedBack;
    }
    
    public override void PlayShowAnimation()
    {
        
    }
    
    public override void PlayHideAnimation()
    {
        
    }
}