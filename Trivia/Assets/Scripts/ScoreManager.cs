using System;
using Zenject;

public class ScoreManager : IInitializable, IDisposable
{
    private int totalScore = 0;
    public int TotalScore { get { return totalScore; } }

    private int correctAnswerPoint = 5;
    private int wrongAnswerPenalty = 5;
    private int timeoutPenalty = 3;

    public void Initialize()
    {
        EventManager.GainScoreEvent += GainScore;
        EventManager.LoseScoreEvent += LoseScore;
        EventManager.TimeOutEvent += TimeOut;
    }

    public void Dispose()
    {
        EventManager.GainScoreEvent -= GainScore;
        EventManager.LoseScoreEvent -= LoseScore;
        EventManager.TimeOutEvent -= TimeOut;
    }

    private void GainScore()
    {
        totalScore += correctAnswerPoint;
        EventManager.ScoreChanged();
    }

    private void LoseScore()
    {
        totalScore -= wrongAnswerPenalty;
        EventManager.ScoreChanged();
    }

    private void TimeOut()
    {
        totalScore -= timeoutPenalty;
        EventManager.ScoreChanged();
    }
}
