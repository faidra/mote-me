using UnityEngine;
using Zenject;
using UniRx.Async;

public class TestController : MonoBehaviour
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
