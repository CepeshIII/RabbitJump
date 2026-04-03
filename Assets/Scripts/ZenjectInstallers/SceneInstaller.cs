using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IInputManager>().To<NewInputManager>().FromNewComponentOnNewGameObject().AsSingle();
        Container.BindInterfacesTo<PlayerController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<IMovement>().To<RB2DMovement>().FromComponentInHierarchy().AsSingle();
        Container.Bind<CameraBorder>().FromComponentInHierarchy().AsSingle();
        Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
        Container.Bind<CameraFollow>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PlatformGenerator>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PlatformPoolManager>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<PlatformCuller>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PlayerSoundManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<AudioSource>().FromComponentInHierarchy().AsSingle();

    }
}