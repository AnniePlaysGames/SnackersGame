using CodeBase.Infrastructure.Services.AssetManagment;
using CodeBase.PlayerLogic;
using CodeBase.Utilities;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Spawn
{
    public class SpawnService : ISpawnService
    {
        private const string SpawnPointTag = "SpawnPoint";
        private const string PlayerPrefabPath = "Spawn/Player";

        private readonly IAssetProvider _assetProvider;
        private readonly ObjectPool _objectPool;

        public Player Player { get; private set; }

        public SpawnService(IAssetProvider assetProvider, ObjectPool objectPool)
        {
            _assetProvider = assetProvider;
            _objectPool = objectPool;
        }

        public void SpawnPlayer()
        {
            InitPlayer();
            AttachObjectPool();
        }

        private void InitPlayer()
        {
            Transform spawnPoint = GameObject.FindWithTag(SpawnPointTag).transform;
            Player = _assetProvider.Instantiate(PlayerPrefabPath, spawnPoint.position).GetComponent<Player>();
        }

        private void AttachObjectPool() 
            => Player.ObjectPool = _objectPool;
    }
}