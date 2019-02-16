using Zenject;

public class TestInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<VRMAccessor>().AsCached();
        Container.Bind<AvatarImporter>().AsCached();
    }
}
