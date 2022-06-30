using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Input;
using CodeBase.Infrastructure.Services.Spawn;
using CodeBase.Infrastructure.States.Interfaces;
using CodeBase.Utilities;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain curtain, ServiceLocator serviceLocator,
            RectTransform uiRoot, ObjectPool objectPool)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, serviceLocator, uiRoot, objectPool),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, curtain, serviceLocator.Single<ISpawnService>(), objectPool),
                [typeof(GameLoopState)] = new GameLoopState(serviceLocator.Single<IInputService>()),
            };
        }
            
        public void Enter<TState>() where TState : class, IState 
            => ChangeState<TState>().Enter();

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload> 
            => ChangeState<TState>().Enter(payload);

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
                
            TState state = GetState<TState>();
            _activeState = state;
                
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState 
            => _states[typeof(TState)] as TState;
    }
}