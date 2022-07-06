using CodeBase.CameraLogic;
using CodeBase.Infrastructure.Services;
using UnityEngine;

public interface ICameraService : IService
{
    Camera MainCamera { get; }
    UpdateState UpdateState { get; }

    public void InitCamera();
    public void SetCameraUpdateState(UpdateState state);
}