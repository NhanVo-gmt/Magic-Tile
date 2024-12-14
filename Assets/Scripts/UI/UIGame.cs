using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : UIPage
{
    [Header("Score")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI feedBackText;
    [SerializeField] private ParticleSystem  scoreParticle;

    private Sequence feedBackSeq;
    private Sequence feedBackFadeSeq;

    [Header("Progress")]
    [SerializeField] private Slider progressSlider;

    [SerializeField] private Image[] stars;
    [SerializeField] private Color unfinishedColor;
    [SerializeField] private Color finishedColor;
    
    public override void Initialise()
    {
        
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

    public void UpdateScore(int currentScore, ScoreType scoreType)
    {
        scoreText.text = currentScore.ToString();
        
        feedBackText.text = scoreType.ToString();
        
        if (feedBackSeq != null) feedBackSeq.Kill();
        
        feedBackSeq = DOTween.Sequence()
            .Append(feedBackText.rectTransform.DOScale(1.3f, 0.1f))
            .Append(feedBackText.rectTransform.DOScale(1f, 1f))
            .Append(feedBackText.rectTransform.DOScale(0f, 0.5f))
            .Play();

        if (feedBackFadeSeq != null) feedBackFadeSeq.Kill();
        
        feedBackFadeSeq = DOTween.Sequence()
            .Append(feedBackText.DOFade(1f, 0.1f))
            .AppendInterval(1f)
            .Append(feedBackText.DOFade(0f, 0.5f))
            .Play();

        this.progressSlider.DOValue(currentScore, 0.2f);
        
        if (scoreType != ScoreType.Missed)
            scoreParticle.Play();
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