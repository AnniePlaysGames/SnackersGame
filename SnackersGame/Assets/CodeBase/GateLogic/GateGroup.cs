using UnityEngine;

namespace CodeBase.Components.GateLogic
{
    public class GateGroup : MonoBehaviour
    {
        [SerializeField] private Gate[] _groupedGates;

        private void OnEnable()
        {
            foreach (Gate gate in _groupedGates)
            {
                gate.OnPlayerEnter += LockOtherGates;
            }
        }

        private void OnDisable()
        {
            foreach (Gate gate in _groupedGates)
            {
                gate.OnPlayerEnter -= LockOtherGates;
            }
        }

        private void LockOtherGates(Gate activatedGate)
        {
            foreach (Gate gate in _groupedGates)
            {
                if (gate.Equals(activatedGate) == false)
                {
                    gate.enabled = false;
                }
            }
        }
    }
}