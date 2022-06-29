using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Components
{
    public class PhysicsJump : MonoBehaviour
    {
        [SerializeField] private JumpView _jumpView;
        [SerializeField] private Movable _movable;
        [SerializeField] private float _length;
        [SerializeField] private float _duration;
        [SerializeField] private LayerMask _groundEnableMask;

        private ProgrammableAnimation _playtime;
        private Ray _findPlatformRay;

        public bool isGrounding { get; private set; }

        private void Awake()
        {
            _playtime = new ProgrammableAnimation(this);
            _movable = GetComponent<Movable>();
        }

        public void Jump(Vector3 direction)
        {
            _movable.enabled = false;

            Vector3 target = FindGroundPosition(direction);

            Vector3 startPosition = transform.position;
            ProgrammableAnimation fxPlaytime = _jumpView.PlayAnimation(transform, _duration, target);
            
            _playtime.Play(_duration, (progress) =>
            {
                transform.position = Vector3.Lerp(startPosition, target, progress) + fxPlaytime.LastChange.Position;
                if (progress >= 1)
                {
                    isGrounding = true;
                    StartCoroutine(DisableIsGrounding());
                    _movable.enabled = true;
                }
                return null;
            });

        }

        private IEnumerator DisableIsGrounding()
        {
            yield return new WaitForSeconds(3);
            isGrounding = false;
        }

        private Vector3 FindGroundPosition(Vector3 direction)
        {
            Vector3 target = transform.position + (direction * _length);
            Vector3 rayOrigin = new Vector3(target.x, target.y + _jumpView.Height, target.z);
            Ray findPlatformRay = new Ray(rayOrigin, target - rayOrigin);
            RaycastHit hit;

            _findPlatformRay = findPlatformRay;
            if (Physics.Raycast(_findPlatformRay, out hit, _jumpView.Height * 5, _groundEnableMask))
            {
                target = hit.point;
            };
            return target;
        }
    }
}