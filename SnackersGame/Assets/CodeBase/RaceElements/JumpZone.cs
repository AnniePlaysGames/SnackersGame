using System;
using CodeBase.CameraLogic;
using CodeBase.Infrastructure.Services;
using CodeBase.Transformation.Jump;
using UnityEngine;

namespace CodeBase.RaceElements
{
    [RequireComponent(typeof(Collider))]
    public class JumpZone : MonoBehaviour
    {
        private bool _firstEnter = true;
        private ICameraService _cameraService;

        private void Awake() 
            => _cameraService = ServiceLocator.Container.Single<ICameraService>();

        private void OnTriggerEnter(Collider other)
        {
            if (_firstEnter)
            {
                _cameraService.SetCameraUpdateState(UpdateState.LateUpdate);
                _firstEnter = false;
            }
            
            PhysicsJump jump = other.GetComponent<PhysicsJump>();
            if (jump)
            {
                jump.Jump(transform.forward);
            }
        }
    }
}
