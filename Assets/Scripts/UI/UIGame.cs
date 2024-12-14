using DG.Tweening;
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
        feedBackText.rectTransform.DOScale(1.3f, 0f);
        feedBackText.rectTransform.DOScale(1f, 0.5f);
        feedBackText.text = feedBack;
    }
    
    public override void PlayShowAnimation()
    {
        
    }
    
    public override void PlayHideAnimation()
    {
        
    }
}