using UnityEngine;
using UnityEngine.UI;

public class GameplayMenu : MenuBase
{
    [SerializeField] private Button pauseButton;

    private void Awake()
    {
        pauseButton.onClick.AddListener(() => OnPauseButtonClicked());
    }


    private void OnPauseButtonClicked()
    {
        canvasManager.ChangeCanvas(CanvasType.PauseMenu);
    }
}