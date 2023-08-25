using UnityEngine;
using Zenject;

public abstract class MenuBase : MonoBehaviour
{
    [Inject] protected CanvasManager canvasManager;

    public virtual void Show() => gameObject.SetActive(true);
    public virtual void Hide() => gameObject.SetActive(false);

}