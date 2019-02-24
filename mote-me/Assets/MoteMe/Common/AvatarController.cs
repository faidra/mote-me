using UnityEngine;
using Zenject;
using UniRx.Async;
using UniRx;
using Valve.VR;

public class AvatarController : MonoBehaviour
{
    [Inject]
    AvatarImporter AvatarImporter;
    [Inject]
    IKApplier IKApplier;

    void Start()
    {
        AvatarImporter.CreateDefaultModel()
            .ContinueWith(avatar => IKApplier.Apply(avatar))
            .Forget();
    }
}
