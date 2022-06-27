using System;
using TMPro;
using UnityEngine;

namespace CodeBase.Components.GateLogic
{
    public class Gate : MonoBehaviour
    {
        public event Action<Gate> OnPlayerEnter;
        
        [SerializeField] private int _value;
        [SerializeField] private MathOperation _operation;
        [SerializeField] private string _text;
        [SerializeField] private MeshRenderer _meshRenderer;
        private void OnTriggerEnter(Collider other)
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                OnPlayerEnter?.Invoke(this);
                player.ChangeUnitsCount(_operation, _value);
                Hide();
            }
        }

        private void Hide() 
            => _meshRenderer.enabled = false;
    }
}