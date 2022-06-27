using CodeBase.Components;
using CodeBase.Infrastructure.Services.AssetManagment;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Spawn
{
    public class SpawnService : ISpawnService
    {
        private const string SpawnPointTag = "SpawnPoint";
        private const string PlayerPrefabPath = "Spawn/Player";
        private readonly IAssetProvider _assetProvider;

        public Player Player { get; private set; }

        public SpawnService(IAssetProvider assetProvider) 
            => _assetProvider = assetProvider;

        public void SpawnPlayer()
        {
            Transform spawnPoint = GameObject.FindWithTag(SpawnPointTag).transform;
            Player = _assetProvider.Instantiate(PlayerPrefabPath, spawnPoint.position).GetComponent<Player>();
        }
    }
}