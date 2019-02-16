using Zenject;
using UnityEngine;

public class TestInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<VRMAccessor>().AsCached();
        Container.Bind<AvatarImporter>().AsCached();
        Container.Bind<IKApplier>().AsCached();
    }
}
