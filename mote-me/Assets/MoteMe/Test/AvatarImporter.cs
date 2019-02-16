using UnityEngine;
using UniRx.Async;
using Zenject;

public class AvatarImporter
{
    const string DefaultAvatarPath = "MoteMe/Resources/Avatar/Alicia/VRM/AliciaSolid.vrm";

    [Inject]
    VRMAccessor VRMAccessor;

    public async UniTask<GameObject> CreateDefaultModel()
    {
        return await VRMAccessor.LoadAsync(DefaultAvatarPath);
    }
}
