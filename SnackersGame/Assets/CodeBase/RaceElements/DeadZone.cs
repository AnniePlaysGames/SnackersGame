using CodeBase.Components;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Spawn;
using UnityEngine;


[RequireComponent((typeof(Collider)))]
public class DeadZone : MonoBehaviour
{
    private ISpawnService _spawnService;

    private void Awake() 
        => _spawnService = ServiceLocator.Container.Single<ISpawnService>();

    private void OnTriggerEnter(Collider other)
    {
        Unit unit = other.GetComponent<Unit>();
        if (unit)
        {
            _spawnService.Player.DeleteUnit(unit);
        }
    }
}
