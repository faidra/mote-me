using UnityEngine;
using Zenject;
using UniRx.Async;
using UniRx;
using Valve.VR;

public class MainController : MonoBehaviour
{
    [Inject]
    LongPressManager LongPressManager;
    [Inject]
    SceneManager SceneManager;
    [SerializeField]
    SteamVR_Action_Boolean menuAction;

    void Start()
    {
        LongPressManager.LongPressAsObservable(IsPosePressed)
            .First()
            .ContinueWith(_ => SceneManager.ChangeToAsync(SceneManager.SceneId.Result).ToObservable())
            .Subscribe()
            .AddTo(this);
    }

    bool IsPosePressed()
    {
        return menuAction.GetState(SteamVR_Input_Sources.Any);
    }
}
