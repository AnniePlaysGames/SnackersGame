using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.AssetManagment;
using CodeBase.Infrastructure.Services.Factories;
using CodeBase.Infrastructure.Services.Input;
using CodeBase.Infrastructure.Services.Spawn;
using CodeBase.Infrastructure.Services.UI;
using CodeBase.Infrastructure.Services.Windows;
using CodeBase.Infrastructure.States.Interfaces;
using CodeBase.Utilities;
using SimpleInputNamespace;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string InitialSceneName = "Initial";
        private const string MainLevelName = "Main";
        
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly ServiceLocator _services;
        private readonly RectTransform _uiRoot;
        private readonly ObjectPool _objectPool;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, ServiceLocator services, RectTransform uiRoot, ObjectPool objectPool)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            _uiRoot = uiRoot;
            _objectPool = objectPool;

            RegisterServices();
        }

        public void Enter() 
            => _sceneLoader.Load(InitialSceneName, onLoaded: EnterLoadLevelState);

        public void Exit()
        {
        }

        private void EnterLoadLevelState() 
            => _stateMachine.Enter<LoadLevelState, string>(MainLevelName);

        private void RegisterServices()
        {
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<ISpawnService>(new SpawnService(_services.Single<IAssetProvider>(), _objectPool));
            _services.RegisterSingle<IUIFactory>(new UIFactory(_services.Single<IAssetProvider>(), _uiRoot));
            _services.RegisterSingle<IInputService>(new MobileInputService(_uiRoot.GetComponentInChildren<Joystick>()));
            _services.RegisterSingle<IWindowService>(new WindowService(_services.Single<IUIFactory>()));
            _services.RegisterSingle<IUnitFactory>(new UnitFactory(_services.Single<IAssetProvider>(), _services.Single<ISpawnService>()));
        }
    }
}