using CodeBase.Components;
using CodeBase.Infrastructure.Services.AssetManagment;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factories
{
    public class UnitFactory : IUnitFactory
    {
        private const string UnitPrefabPath = "Unit";
        private readonly IAssetProvider _assetProvider;

        public UnitFactory(IAssetProvider assetProvider)
            => _assetProvider = assetProvider;

        public GameObject CreateUnit() 
            => _assetProvider.Instantiate(UnitPrefabPath);
    }
}