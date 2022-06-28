using UnityEngine;

namespace CodeBase.Components
{
    public class SurfaceSlider : MonoBehaviour
    {
        private Vector3 _normal;
        private int _defaultLayerMask;

        public Vector3 Project(Vector3 forward)
            => forward - Vector3.Dot(forward, _normal) * _normal;

        private void OnCollisionEnter(Collision collision)
        {
            _defaultLayerMask = LayerMask.GetMask("Default");
            if (collision.gameObject.layer == _defaultLayerMask)
            {
                _normal = collision.contacts[0].normal;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.position, transform.position + _normal * 3);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + Project(transform.forward));
        }
    }
}