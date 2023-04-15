using System;
using Infrastructure.States;
using Logic;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class BootstrapInstaller : MonoInstaller, ICoroutineRunner
    {
        public LoadingCurtain CurtainPrefab;

        private GameStateMachine _stateMachine;

        private const string FirstLevelName = "Test";

        public override void InstallBindings()
        {
            BindLoadingCurtain();
            BindServices();
        }

        private void BindLoadingCurtain() =>
            Container
                .Bind<LoadingCurtain>()
                .FromInstance(Instantiate(CurtainPrefab))
                .AsSingle();

        private void BindServices()
        {
            
        }

        private new void Start()
        {
            _stateMachine = new GameStateMachine(new SceneLoader(this), Container.Resolve<LoadingCurtain>());
            _stateMachine.Enter<LoadSceneState,string>(FirstLevelName);
        }
    }
}