using CodeBase.CameraLogic;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Transformation.Jump
{
    public class JumpView : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _yAnimation;
        [SerializeField] private float _height;
        private ProgrammableAnimation _playTime;
        private ICameraService _cameraService;

        public float Height => _height;

        private void Awake()
        {
            _playTime = new ProgrammableAnimation(this);
            _cameraService = ServiceLocator.Container.Single<ICameraService>();
        }

        public ProgrammableAnimation PlayAnimation(Transform jumper, float duration, Vector3 target)
        {
            _playTime.Play(duration, progress =>
            {
                Vector3 position =
                    Vector3.Scale(new Vector3(0, _height * _yAnimation.Evaluate(progress), 0), jumper.up);

                if (progress >= 1 )
                {
                    ChangeCameraUpdateState();
                }
                
                return new TransformChange(position);

            });
            return _playTime;
        }

        private void ChangeCameraUpdateState()
        {
            if (_cameraService.UpdateState == UpdateState.LateUpdate)
            {
                _cameraService.SetCameraUpdateState(UpdateState.FixedUpdate);
            }
        }
    }
}