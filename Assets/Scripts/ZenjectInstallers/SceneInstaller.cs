using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IInputManager>().To<NewInputManager>().FromNewComponentOnNewGameObject().AsSingle();
        Container.BindInterfacesTo<SimpleMovement>().FromComponentInHierarchy().AsSingle();
        Container.Bind<CameraBorder>().FromComponentInHierarchy().AsSingle();
        Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
    }
}