using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : UIPage
{
    [Header("Score")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI feedBackText;

    private Sequence feedBackSeq;

    [Header("Progress")]
    [SerializeField] private Slider progressSlider;
    
    public override void Initialise()
    {
        feedBackSeq = DOTween.Sequence().AppendCallback(() =>
            {
                feedBackText.DOFade(1f, 0f);
                feedBackText.rectTransform.DOScale(1.3f, 0f);
            })
            .Append(feedBackText.rectTransform.DOScale(1f, 1f))
            .AppendCallback(() =>
            {
                feedBackText.rectTransform.DOScale(0f, 0.5f);
                feedBackText.DOFade(0f, 0.5f);
            })
            .SetAutoKill(false).Pause();
    }

    public void UpdateCurrentScore(int currentScore)
    {
        scoreText.text = currentScore.ToString();
    }
    
    public void UpdateFeedback(string feedBack)
    {
        feedBackText.text = feedBack;
        
        feedBackSeq.Rewind();
        feedBackSeq.Play();
    }
    
    public override void PlayShowAnimation()
    {
        
    }
    
    public override void PlayHideAnimation()
    {
        
    }
}