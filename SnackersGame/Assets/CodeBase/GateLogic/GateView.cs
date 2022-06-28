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

        private void OnEnable()
        {
            _textMesh.text = SetText(_gate.Operation, _gate.Value);
            SetColor(_gate.GateType);
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

        private void SetColor(GateType gateGateType)
        {
            
        }
    }
}