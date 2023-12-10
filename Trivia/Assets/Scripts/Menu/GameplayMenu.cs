using UnityEngine;
using UnityEngine.UI;

public class GameplayMenu : MenuBase
{
    [SerializeField] private Button pauseButton;

    private void OnEnable()
    {
        EventManager.AnswerClickedEvent += DisablePauseButton;
    }

    private void OnDisable()
    {
        EventManager.AnswerClickedEvent -= DisablePauseButton;
    }

    private void Awake()
    {
        EnablePauseButton();
        pauseButton.onClick.AddListener(() => OnPauseButtonClicked());
    }

    private void OnPauseButtonClicked()
    {
        canvasManager.ChangeCanvas(CanvasType.PauseMenu);
    }

    private void EnablePauseButton()
    {
        pauseButton.interactable = true;
    }

    private void DisablePauseButton(AnswerUI answerUI)
    {
        pauseButton.interactable = false;
    }
}