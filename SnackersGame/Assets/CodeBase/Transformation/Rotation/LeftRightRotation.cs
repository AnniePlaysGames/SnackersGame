using UnityEngine;

namespace CodeBase.Transformation.Rotation
{
    public class LeftRightRotation : MonoBehaviour
    {
        [SerializeField] private float _maxAngle = 45;
        [SerializeField] private float _speedDegreesInSec = 1;
        private Quaternion _initialRotation;
        private float _angle;

        private void Awake() 
            => _initialRotation = transform.rotation;

        private void FixedUpdate()
        {
            _angle += _speedDegreesInSec * Time.fixedDeltaTime;
            float currentAngle =Mathf.PingPong(_angle, _maxAngle);

            Quaternion rotation = Quaternion.AngleAxis(currentAngle, Vector3.back);
            transform.rotation = _initialRotation * rotation;
        }
    }
}