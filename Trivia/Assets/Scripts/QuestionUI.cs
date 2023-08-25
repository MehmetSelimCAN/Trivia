using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

public class QuestionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private AnswerUI[] answers;
    private QuestionData currentQuestionData;

    [Inject] private CanvasManager canvasManager;
    private WaitForSeconds backToSpinMenuDelay = new WaitForSeconds(1f);

    private void OnEnable()
    {
        EventManager.AnswerClickedEvent += OnAnswerClicked;
        EventManager.LoadNewQuestionEvent += LoadNewQuestion;
        EventManager.TimeOutEvent += OnTimeOut;
    }

    private void OnDisable()
    {
        EventManager.AnswerClickedEvent -= OnAnswerClicked;
        EventManager.LoadNewQuestionEvent -= LoadNewQuestion;
        EventManager.TimeOutEvent -= OnTimeOut;
        ResetValues();
    }

    public void LoadNewQuestion(QuestionData questionData)
    {
        currentQuestionData = questionData;
        questionText.SetText(currentQuestionData.question);
        UpdateAnswersUI();
    }

    private void UpdateAnswersUI()
    {
        for (int i = 0; i < answers.Length; i++)
        {
            string choiceTypeString = currentQuestionData.choices[i].Substring(0, 1);
            Enum.TryParse<ChoiceType>(choiceTypeString, out var choiceType);

            answers[i].UpdateUI(currentQuestionData.choices[i], choiceType);
        }
    }

    private void OnAnswerClicked(AnswerUI answerUI)
    {
        DisableInteractions();

        Enum.TryParse<ChoiceType>(currentQuestionData.answer, out var correctChoiceType);
        bool answerCorrect = answerUI.CheckForAnswer(correctChoiceType);

        if (answerCorrect)
        {
            OnAnswerCorrect();
        }
        else
        {
            OnAnswerWrong();
        }

        StartCoroutine(BackToSpinMenu());
    }

    private void DisableInteractions()
    {
        foreach (AnswerUI _answerUI in answers)
        {
            _answerUI.DisableInteraction();
        }
    }

    private void OnAnswerCorrect()
    {
        EventManager.GainScore();
    }

    private void OnAnswerWrong()
    {
        EventManager.LoseScore();
        HighlightCorrectAnswer();
    }

    private void OnTimeOut()
    {
        DisableInteractions();
        HighlightCorrectAnswer();
        StartCoroutine(BackToSpinMenu());
    }

    private void HighlightCorrectAnswer()
    {
        for (int i = 0; i < answers.Length; i++)
        {
            Enum.TryParse<ChoiceType>(currentQuestionData.answer, out var correctChoiceType);

            if (answers[i].ChoiceType == correctChoiceType)
            {
                answers[i].EnableCorrectBackground();
                break;
            }
        }
    }

    private IEnumerator BackToSpinMenu()
    {
        yield return backToSpinMenuDelay;
        canvasManager.ChangeCanvas(CanvasType.SpinMenu);
    }

    private void ResetValues()
    {
        foreach (AnswerUI answerUI in answers)
        {
            answerUI.ResetValues();
        }
    }
}
