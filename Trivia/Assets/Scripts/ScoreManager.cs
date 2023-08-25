using System;
using Zenject;

public class ScoreManager
{
    private int totalScore = 0;
    public int TotalScore { get { return totalScore; } }

    private int correctAnswerPoint = 5;
    private int wrongAnswerPenalty = 5;
    private int timeoutPenalty = 3;

    private void GainScore()
    {
        totalScore += correctAnswerPoint;
    }

    private void LoseScore()
    {
        totalScore -= wrongAnswerPenalty;
    }

    private void TimeOut()
    {
        totalScore -= timeoutPenalty;
    }
}
