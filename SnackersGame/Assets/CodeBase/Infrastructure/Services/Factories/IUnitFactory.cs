using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factories
{
    public interface IUnitFactory : IService
    {
        public GameObject CreateUnit();
    }
}