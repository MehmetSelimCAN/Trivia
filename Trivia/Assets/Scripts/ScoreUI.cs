using TMPro;
using Zenject;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    [Inject] private ScoreManager scoreManager;

    private void OnEnable()
    {
        EventManager.ScoreChangedEvent += UpdateScoreText;
    }

    private void OnDisable()
    {
        EventManager.ScoreChangedEvent -= UpdateScoreText;
    }

    private void UpdateScoreText()
    {
        scoreText.SetText(scoreManager.TotalScore.ToString());
    }
}
