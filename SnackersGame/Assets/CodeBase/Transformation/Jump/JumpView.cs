using UnityEngine;

namespace CodeBase.Transformation.Jump
{
    public class JumpView : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _yAnimation;
        [SerializeField] private float _height;
        private ProgrammableAnimation _playTime;

        public float Height => _height;

        private void Awake() 
            => _playTime = new ProgrammableAnimation(this);

        public ProgrammableAnimation PlayAnimation(Transform jumper, float duration, Vector3 target)
        {
            _playTime.Play(duration, progress =>
            {
                Vector3 position =
                    Vector3.Scale(new Vector3(0, _height * _yAnimation.Evaluate(progress), 0), jumper.up);
                return new TransformChange(position);

            });
            return _playTime;
        }
    }
}