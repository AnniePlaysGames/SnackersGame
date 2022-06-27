using System;
using SimpleInputNamespace;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Input
{
    public class MobileInputService : IInputService
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private readonly Joystick _joystick;

        public Vector3 HorizontalStickPosition => new Vector3(SimpleInput.GetAxis(Vertical),0,0);

        public MobileInputService(Joystick joystick) 
            => _joystick = joystick;

        public void EnableInput()
            => _joystick.enabled = true;

        public void DisableInput()
            => _joystick.enabled = false;
    }
}