using UnityEngine;
using Zenject;
using UniRx.Async;

public class TestController : MonoBehaviour
{
    [Inject]
    AvatarImporter AvatarImporter;

    void Start()
    {
        AvatarImporter.CreateDefaultModel().Forget();
    }
}
