using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;

namespace CodeBase.Components.GateLogic
{
    public class GateView : MonoBehaviour
    {
        [SerializeField] private Gate _gate;
        [SerializeField] private TextMeshPro _textMesh;
        
        [SerializeField] private Material _goodGateMaterial;
        [SerializeField] private Material _badGateMaterial;
        [SerializeField] private MeshRenderer _gateView;

        private void OnEnable()
        {
            _textMesh.text = SetText(_gate.Operation, _gate.Value);
            
            SetTypeColor(_gate.GateType);
        }

        private string SetText(MathOperation gateOperation, int gateValue)
        {
            StringBuilder stringBuilder = new StringBuilder(gateValue.ToString());
            
            char sign = ' ';
            switch (gateOperation)
            {
                case MathOperation.Addition:
                    sign = '+';
                    break;
                case MathOperation.Subtraction:
                    sign = '-';
                    break;
                case MathOperation.Multiplication:
                    sign = 'x';
                    break;
                case MathOperation.Division:
                    sign = '\u00F7';
                    break;
            }
            
            return stringBuilder.Insert(0,sign).ToString();
        }

        private void SetTypeColor(GateType gateType)
        {
            switch (gateType)
            {
                case GateType.Bad:
                    _gateView.material = _badGateMaterial;
                    break;
                case GateType.Good:
                    _gateView.material = _goodGateMaterial;
                    break;
            }
        }
    }
}