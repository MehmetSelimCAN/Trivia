using System;

public class CanvasManager
{
    private Menus menus;
    private MenuBase lastActiveMenu;

    public CanvasManager(Menus _menus)
    {
        menus = _menus;
        lastActiveMenu = menus.mainMenu;
    }

    public void ChangeCanvas(CanvasType canvasType)
    {
        lastActiveMenu.Hide();

        switch (canvasType)
        {
            case CanvasType.MainMenu:
                menus.mainMenu.Show();
                lastActiveMenu = menus.mainMenu;
                break;
            case CanvasType.SpinMenu:
                menus.spinMenu.Show();
                lastActiveMenu = menus.spinMenu;
                break;
            case CanvasType.GameplayMenu:
                menus.gameplayMenu.Show();
                lastActiveMenu = menus.gameplayMenu;
                break;
        }
    }

    [Serializable]
    public class Menus
    {
        public MainMenu mainMenu;
        public SpinMenu spinMenu;
        public GameplayMenu gameplayMenu;
    }
}
