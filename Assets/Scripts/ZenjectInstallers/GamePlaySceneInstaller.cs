using UnityEngine;
using Zenject;


public class GamePlaySceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IInputManager>().To<NewInputManager>().FromNewComponentOnNewGameObject().AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<IMovement>().To<RB2DMovement>().FromComponentInHierarchy().AsSingle();
        Container.Bind<CameraBorder>().FromComponentInHierarchy().AsSingle();
        Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
        Container.Bind<CameraFollow>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PlatformGenerator>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PlatformPoolManager>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<PlatformCuller>().FromComponentInHierarchy().AsSingle();
        Container.Bind<PlayerSoundManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<AudioSource>().FromComponentInHierarchy().AsSingle();

        Container.BindInterfacesAndSelfTo<ScoreCounter>().FromNew().AsSingle();
        Container.BindInterfacesAndSelfTo<GamePlayService>().FromNew().AsSingle();

        Container.Bind<GamePlayUI>().FromComponentInHierarchy().AsSingle();

        Container.Bind<GamePlayUIManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<GameOverUI>().FromComponentInHierarchy().AsSingle();
        Container.Bind<MenuUI>().FromComponentInHierarchy().AsSingle();

        Container.Bind<GameEntryPoint>().FromComponentInHierarchy().AsSingle();
    }
}
