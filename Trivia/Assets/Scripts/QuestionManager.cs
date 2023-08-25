using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestionManager : Zenject.IInitializable
{
    private TextAsset questionJson;
    private QuestionData[] questions;
    public QuestionData[] Questions { get { return questions; } }

    private List<QuestionData> musicQuestions = new List<QuestionData>();
    private List<QuestionData> historyQuestions = new List<QuestionData>();
    private List<QuestionData> cultureQuestions = new List<QuestionData>();
    private List<QuestionData> cinemaQuestions = new List<QuestionData>();

    private CategoryType currentCategoryType;

    public void Initialize()
    {
        LoadQuestions();
    }

    private void LoadQuestions()
    {
        questionJson = Resources.Load<TextAsset>("questions");
        questions = JsonHelper.FromJson<QuestionData>(questionJson.text);
        CategorizeQuestions();
    }

    private void CategorizeQuestions()
    {
        foreach (var questionData in questions)
        {
            Enum.TryParse<CategoryType>(questionData.category.FirstCharacterToUpper(), out var questionCategoryType);
            switch (questionCategoryType)
            {
                case CategoryType.Generalculture:
                    cultureQuestions.Add(questionData);
                    break;
                case CategoryType.Music:
                    musicQuestions.Add(questionData);
                    break;
                case CategoryType.History:
                    historyQuestions.Add(questionData);
                    break;
                case CategoryType.Cinema:
                    cinemaQuestions.Add(questionData);
                    break;
            }
        }
    }

    public void SetCategoryType(CategoryType categoryType)
    {
        currentCategoryType = categoryType;
    }

    public void LoadNewQuestion()
    {
        QuestionData questionData = GetRandomQuestion(currentCategoryType);
        EventManager.LoadNewQuestion(questionData);
        EventManager.NewQuestionLoaded();
    }

    private QuestionData GetRandomQuestion(CategoryType categoryType)
    {
        switch (categoryType)
        {
            case CategoryType.Music:
                return musicQuestions[UnityEngine.Random.Range(0, musicQuestions.Count)];
            case CategoryType.History:
                return historyQuestions[UnityEngine.Random.Range(0, historyQuestions.Count)];
            case CategoryType.Generalculture:
                return cultureQuestions[UnityEngine.Random.Range(0, cultureQuestions.Count)];
            case CategoryType.Cinema:
                return cinemaQuestions[UnityEngine.Random.Range(0, cinemaQuestions.Count)];

            default:
                return musicQuestions[UnityEngine.Random.Range(0, musicQuestions.Count)];
        }
    }
}

[Serializable]
public class QuestionData
{
    public string category;
    public string question;
    public List<string> choices;
    public string answer;
}