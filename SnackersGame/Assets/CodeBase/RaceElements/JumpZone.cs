using CodeBase.Components;
using UnityEngine;


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
