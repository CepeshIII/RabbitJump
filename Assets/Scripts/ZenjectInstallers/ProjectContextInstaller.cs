using System;
using UnityEngine;
using Zenject;


public class ProjectContextInstaller : MonoInstaller<ProjectContextInstaller>
{
    [SerializeField]
    private LoadingSceneUI loadingSceneUI;


    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<MySceneManager>().FromNewComponentOnNewGameObject().AsSingle();
        Container.Bind<RecordsService>().FromNew().AsSingle();
        Container.Bind<LoadingSceneUI>().FromComponentInNewPrefab(loadingSceneUI).AsSingle();
    }
}
