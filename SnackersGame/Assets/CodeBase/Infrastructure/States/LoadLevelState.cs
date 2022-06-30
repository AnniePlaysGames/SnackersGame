using System;
using CodeBase.CameraLogic;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Spawn;
using CodeBase.Infrastructure.States.Interfaces;
using CodeBase.Utilities;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly ISpawnService _spawnService;
        private readonly ObjectPool _objectPool;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain curtain, ISpawnService spawnService, ObjectPool objectPool)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _spawnService = spawnService;
            _objectPool = objectPool;
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        private void OnLoaded()
        {
            _spawnService.SpawnPlayer();
            EnableCameraFollow();
            _objectPool.InitPool();

            _gameStateMachine.Enter<GameLoopState>();
        }

        public void Exit() 
            => _curtain.Hide();

        private void EnableCameraFollow()
        {
            FollowTarget followTarget = Camera.main.GetComponentInChildren<FollowTarget>();
            followTarget.SetTarget(_spawnService.Player.LookPoint);
        }
    }
}