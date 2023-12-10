using Zenject;
using UnityEngine;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private CanvasManager.Menus canvasManagerMenus;

    public override void InstallBindings()
    {
        Container.Bind<CanvasManager>().AsSingle().WithArguments(canvasManagerMenus);
        Container.BindInterfacesAndSelfTo<ScoreManager>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<QuestionManager>().AsSingle().NonLazy();
    }
}
