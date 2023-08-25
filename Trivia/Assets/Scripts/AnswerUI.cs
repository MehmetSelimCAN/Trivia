using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerUI : MonoBehaviour
{
    [SerializeField] private Button answerButton;
    [SerializeField] private TextMeshProUGUI answerText;

    [Header("Backgrounds")]
    [SerializeField] private Image defaultBackground;
    [SerializeField] private Image correctBackground;
    [SerializeField] private Image wrongBackground;

    private ChoiceType choiceType;
    public ChoiceType ChoiceType { get { return choiceType; } }

    private void Awake()
    {
        answerButton.onClick.AddListener(() => OnAnswerSelected());
    }

    public void UpdateUI(string answer, ChoiceType _choiceType)
    {
        answerText.SetText(answer);
        choiceType = _choiceType;
    }

    private void OnAnswerSelected()
    {
        EventManager.AnswerClicked(this);
    }

    public bool CheckForAnswer(ChoiceType correctChoiceType)
    {
        if (choiceType == correctChoiceType)
        {
            EnableCorrectBackground();
            return true;
        }
        else
        {
            EnableWrongBackground();
            return false;
        }
    }

    public void EnableCorrectBackground()
    {
        DisableDefaultBackground();
        correctBackground.gameObject.SetActive(true);
        transform.DOScale(transform.localScale * 1.1f, 0.2f);
    }

    private void EnableWrongBackground()
    {
        DisableDefaultBackground();
        transform.DOShakeRotation(0.4f, 35f, 10, 30);
        wrongBackground.gameObject.SetActive(true);
    }

    public void DisableDefaultBackground()
    {
        defaultBackground.gameObject.SetActive(false);
    }

    public void DisableInteraction()
    {
        answerButton.interactable = false;
    }

    public void ResetValues()
    {
        defaultBackground.gameObject.SetActive(true);
        correctBackground.gameObject.SetActive(false);
        wrongBackground.gameObject.SetActive(false);

        transform.localScale = Vector3.one;
        answerButton.interactable = true;
    }
}
