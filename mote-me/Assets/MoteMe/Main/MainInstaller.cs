using Zenject;

public class MainInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<VRMAccessor>().AsCached();
        Container.Bind<AvatarImporter>().AsCached();
        Container.Bind<IKApplier>().AsCached();
        Container.Bind<LongPressManager>().AsSingle();
        Container.Bind<SceneManager>().AsSingle();
        Container.BindInstance(1.5f).WithId("LongPressDuration");
    }
}
