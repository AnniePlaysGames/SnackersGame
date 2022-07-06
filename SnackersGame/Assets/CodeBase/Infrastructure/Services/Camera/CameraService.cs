using Cinemachine;
using CodeBase.CameraLogic;
using UnityEngine;

public class CameraService : ICameraService
{
    private CinemachineBrain _cameraBrain;
    
    public Camera MainCamera { get; private set; }
    public UpdateState UpdateState { get; private set; }

    public void InitCamera()
    {
        MainCamera = Camera.main;
        _cameraBrain = MainCamera.GetComponent<CinemachineBrain>();
    }

    public void SetCameraUpdateState(UpdateState state)
    {
        UpdateState = state;
        switch (state)
        {
            case UpdateState.FixedUpdate:
                _cameraBrain.m_BlendUpdateMethod = CinemachineBrain.BrainUpdateMethod.FixedUpdate;
                _cameraBrain.m_UpdateMethod = CinemachineBrain.UpdateMethod.FixedUpdate;
                break;
            case UpdateState.LateUpdate:
                _cameraBrain.m_BlendUpdateMethod = CinemachineBrain.BrainUpdateMethod.LateUpdate;
                _cameraBrain.m_UpdateMethod = CinemachineBrain.UpdateMethod.LateUpdate;
                break;
        }
    }
}