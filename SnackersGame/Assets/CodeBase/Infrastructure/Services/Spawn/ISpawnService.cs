using CodeBase.PlayerLogic;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Spawn
{
    public interface ISpawnService : IService
    {
        public Player Player { get; }
        public void SpawnPlayer();
    }
}