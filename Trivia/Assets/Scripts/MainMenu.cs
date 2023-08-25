using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MenuBase
{
    [SerializeField] private Button playButton;

    private void Awake()
    {
        playButton.onClick.AddListener(() => OnPlayButtonClicked());
    }

    private void OnPlayButtonClicked()
    {
        canvasManager.ChangeCanvas(CanvasType.SpinMenu);
    }
}
