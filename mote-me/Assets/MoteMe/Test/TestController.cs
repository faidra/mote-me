using UnityEngine;
using Zenject;
using UniRx.Async;
using UniRx;
using Valve.VR;

public class TestController : MonoBehaviour
{
    [Inject]
    AvatarImporter AvatarImporter;
    [Inject]
    IKApplier IKApplier;
    [Inject]
    LongPressManager LongPressManager;
    [Inject]
    SceneManager SceneManager;

    SteamVR_Action_Boolean poseAction;

    void Start()
    {
        poseAction = SteamVR_Input.GetBooleanAction("Pose");

        AvatarImporter.CreateDefaultModel()
            .ContinueWith(avatar => IKApplier.Apply(avatar))
            .Forget();

        LongPressManager.LongPressAsObservable(IsPosePressed)
            .First()
            .ContinueWith(_ => SceneManager.ChangeToAsync("result").ToObservable())
            .Subscribe()
            .AddTo(this);
    }

    bool IsPosePressed()
    {
        return poseAction.GetStateDown(SteamVR_Input_Sources.Any);
    }
}
