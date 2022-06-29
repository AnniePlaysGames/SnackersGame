using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Components
{
    public class ProgrammableAnimation
    {
        public TransformChange LastChange { get; private set; }

        private readonly MonoBehaviour _context;
        private Coroutine _lastAnimation;

        public ProgrammableAnimation(MonoBehaviour context) 
            => _context = context;

        public void Play(float duration, Func<float, TransformChange> body)
        {
            if (_lastAnimation != null)
            {
                _context.StopCoroutine(_lastAnimation);
            }

            _lastAnimation = _context.StartCoroutine(GetAnimation(duration, body));
        }

        private IEnumerator GetAnimation(float duration, Func<float, TransformChange> body)
        {
            float expiredSeconds = 0f;
            float progress = 0f;

            while (progress < 1)
            {
                expiredSeconds += Time.deltaTime;
                progress = expiredSeconds / duration;

                LastChange = body.Invoke(progress);
                
                yield return null;
            }
        }
    }
}