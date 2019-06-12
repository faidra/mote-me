using UnityEngine;
using Zenject;
using UniRx.Async;
using UniRx;
using Valve.VR;

public class TestController : MonoBehaviour
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
            .ContinueWith(_ => SceneManager.ChangeToAsync("result").ToObservable())
            .Subscribe()
            .AddTo(this);
    }

    bool IsPosePressed()
    {
        return menuAction.GetStateDown(SteamVR_Input_Sources.Any);
    }
}
