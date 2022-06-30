using UnityEngine;

namespace CodeBase.Transformation.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(SurfaceSlider))]
    public class PhysicsMovement : MonoBehaviour
    {
        private const float ConstantMovementForward = 1f;
        [SerializeField] private float _speed;
        private Rigidbody _rigidbody;
        private SurfaceSlider _surfaceSlider;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _surfaceSlider = GetComponent<SurfaceSlider>();
        }

        public void Move(Vector3 direction)
        {
            direction.z = ConstantMovementForward;

            Vector3 directionAlongSurface = _surfaceSlider.Project(direction.normalized);
            Vector3 offset = directionAlongSurface * (_speed * Time.fixedDeltaTime);

            _rigidbody.MovePosition(_rigidbody.position + offset);
        }
    }
}