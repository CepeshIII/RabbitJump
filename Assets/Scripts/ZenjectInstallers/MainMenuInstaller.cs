using Zenject;

public class MainMenuInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<MainMenuUI>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PrivacyUI>().FromComponentInHierarchy().AsSingle();
        Container.Bind<RecordsUI>().FromComponentInHierarchy().AsSingle();
        Container.Bind<RecordLinesDisplayer>().FromComponentInHierarchy().AsSingle();
        
        Container.BindInterfacesAndSelfTo<MainMenuManager>().FromComponentInHierarchy().AsSingle();
        
    }
}