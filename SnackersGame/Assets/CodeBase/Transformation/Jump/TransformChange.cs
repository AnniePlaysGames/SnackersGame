using UnityEngine;

namespace CodeBase.Transformation.Jump
{
    public class TransformChange
    {
        public Vector3 Position { get; }

        public TransformChange(Vector3 position) 
            => Position = position;
    }
}