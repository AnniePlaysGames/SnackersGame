using System;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Input
{
    public interface IInputService : IService
    {
        public Vector3 HorizontalStickPosition { get; }

        public void EnableInput();
        public void DisableInput();
    }
}