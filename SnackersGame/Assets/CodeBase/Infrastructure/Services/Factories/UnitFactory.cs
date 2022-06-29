using CodeBase.Components;
using CodeBase.Infrastructure.Services.AssetManagment;
using CodeBase.Infrastructure.Services.Spawn;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factories
{
    public class UnitFactory : IUnitFactory
    {
        private const string UnitPrefabPath = "Spawn/Unit";
        private readonly IAssetProvider _assetProvider;
        private readonly ISpawnService _spawnService;

        public UnitFactory(IAssetProvider assetProvider, ISpawnService spawnService)
        {
            _assetProvider = assetProvider;
            _spawnService = spawnService;
        }

        public GameObject CreateUnit()
        {
            GameObject unit = _assetProvider.Instantiate(UnitPrefabPath);
            unit.GetComponent<GroupAroundTarget>().SetTarget(_spawnService.Player.transform);
            return unit;
        }
    }
}