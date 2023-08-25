using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void UpdateScoreText()
    {
        scoreText.SetText("New score");
    }
}
