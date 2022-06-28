using CodeBase.Components;
using CodeBase.Infrastructure.States;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class Bootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private RectTransform _uiRoot;
        [SerializeField] private LoadingCurtain _loadingCurtain;
        [SerializeField] private ObjectPool _objectPool;

        private void Awake()
        {
            Game game = new Game(this, _loadingCurtain, _uiRoot, _objectPool);
            game.StateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }
    }
}