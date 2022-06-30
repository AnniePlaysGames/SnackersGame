using CodeBase.Transformation.Jump;
using UnityEngine;

namespace CodeBase.RaceElements
{
    [RequireComponent(typeof(Collider))]
    public class JumpZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            PhysicsJump jump = other.GetComponent<PhysicsJump>();
            if (jump)
            {
                jump.Jump(transform.forward);
            }
        }
    }
}
