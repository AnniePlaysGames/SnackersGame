using System;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Spawn;
using CodeBase.Infrastructure.States.Interfaces;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly ISpawnService _spawnService;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain curtain, ISpawnService spawnService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _spawnService = spawnService;
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