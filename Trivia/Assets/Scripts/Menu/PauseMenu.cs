using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MenuBase
{
    [SerializeField] private Button continueButton;
    [SerializeField] private Button backButton;

    private void Awake()
    {
        continueButton.onClick.AddListener(() => OnContinueButtonClicked());
        backButton.onClick.AddListener(() => OnBackButtonClicked());
    }

    private void OnContinueButtonClicked()
    {
        canvasManager.ChangeCanvas(CanvasType.GameplayMenu);
    }

    private void OnBackButtonClicked()
    {
        canvasManager.ChangeCanvas(CanvasType.MainMenu);
    }
}