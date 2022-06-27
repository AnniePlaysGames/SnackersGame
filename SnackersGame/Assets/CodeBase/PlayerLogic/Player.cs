using System;
using CodeBase.Components.GateLogic;

namespace CodeBase.Components
{
    public class Player
    {
        public event Action OnUnitsOver;
        private int _unitCount = 1;

        public void ChangeUnitsCount(MathOperation operation, int value)
        {
            ApplyOperation(operation, value);
            CheckForUnitsOver();
        }

        private void ApplyOperation(MathOperation operation, int value)
        {
            switch (operation)
            {
                case MathOperation.Addition:
                    _unitCount += value;
                    break;
                case MathOperation.Subtraction:
                    _unitCount -= value;
                    break;
                case MathOperation.Multiplication:
                    _unitCount *= value;
                    break;
                case MathOperation.Division:
                    _unitCount /= value;
                    break;
            }
        }
        private void CheckForUnitsOver()
        {
            if (_unitCount <= 0)
            {
                OnUnitsOver?.Invoke();
            }
        }
    }
}