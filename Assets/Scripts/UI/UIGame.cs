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

    [SerializeField] private Image[] stars;
    [SerializeField] private Color unfinishedColor;
    [SerializeField] private Color finishedColor;
    
    public override void Initialise()
    {
        feedBackSeq = DOTween.Sequence().AppendCallback(() =>
            {
                feedBackText.DOFade(1f, 0.1f);
                feedBackText.rectTransform.DOScale(1.3f, 0.1f);
            })
            .Append(feedBackText.rectTransform.DOScale(1f, 1f))
            .AppendCallback(() =>
            {
                feedBackText.rectTransform.DOScale(0f, 0.5f);
                feedBackText.DOFade(0f, 0.5f);
            })
            .SetAutoKill(false).Pause();
    }

    public void BindData(LevelData levelData)
    {
        this.progressSlider.value = 0;
        this.progressSlider.minValue = 0;
        this.progressSlider.maxValue = levelData.StarScore[2];
        
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].DOColor(unfinishedColor, 0f);
        }
    }

    public void UpdateScore(int currentScore, string feedBack)
    {
        scoreText.text = currentScore.ToString();
        
        feedBackText.text = feedBack;
        feedBackSeq.Rewind();
        feedBackSeq.Play();

        this.progressSlider.DOValue(currentScore, 0.2f);
    }
    
    public void UpdateStar(int index)
    {
        for (int i = 0; i <= index; i++)
        {
            stars[i].DOColor(finishedColor, 0.3f);
        }
    }
    
    public override void PlayShowAnimation()
    {
        
    }
    
    public override void PlayHideAnimation()
    {
        
    }
}