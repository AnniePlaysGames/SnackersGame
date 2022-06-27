using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    internal class Game
    {
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain, RectTransform uiRoot) 
            => StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain, ServiceLocator.Container, uiRoot);
    }
}