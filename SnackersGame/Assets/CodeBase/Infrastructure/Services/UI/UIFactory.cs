using CodeBase.Infrastructure.Services.AssetManagment;
using CodeBase.Infrastructure.Services.Windows;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.UI
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _assets;
        private readonly RectTransform _uiRoot;

        public UIFactory(IAssetProvider assets, RectTransform uiRoot)
        {
            _assets = assets;
            _uiRoot = uiRoot;
        }
    }
}