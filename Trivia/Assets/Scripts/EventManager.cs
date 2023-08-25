using System;

public static class EventManager
{
    public static Action GainScoreEvent;
    public static void GainScore() => GainScoreEvent?.Invoke();

    public static Action LoseScoreEvent;
    public static void LoseScore() => LoseScoreEvent?.Invoke();

    public static Action ScoreChangedEvent;
    public static void ScoreChanged() => ScoreChangedEvent?.Invoke();

    public static Action TimeOutEvent;
    public static void TimeOut() => TimeOutEvent?.Invoke();

    public static Action<QuestionData> LoadNewQuestionEvent;
    public static void LoadNewQuestion(QuestionData questionData) => LoadNewQuestionEvent?.Invoke(questionData);

    public static Action NewQuestionLoadedEvent;
    public static void NewQuestionLoaded() => NewQuestionLoadedEvent?.Invoke();
}
