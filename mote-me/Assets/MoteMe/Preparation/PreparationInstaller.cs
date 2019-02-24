using Zenject;

public class PreparationInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<VRMAccessor>().AsCached();
        Container.Bind<AvatarImporter>().AsCached();
        Container.Bind<IKApplier>().AsCached();
        Container.Bind<SceneManager>().AsSingle();
    }
}
