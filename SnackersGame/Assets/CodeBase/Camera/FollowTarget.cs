using Cinemachine;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private CinemachineVirtualCamera _camera;

    private void Awake() 
        => _camera = GetComponent<CinemachineVirtualCamera>();

    public void SetTarget(Transform target)
    {
        _camera.Follow = target;
        _camera.LookAt = target;
    }
}
