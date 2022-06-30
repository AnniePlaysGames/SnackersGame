using System.Collections;
using CodeBase.Transformation.Movement;
using UnityEngine;

namespace CodeBase.PlayerLogic
{
    [RequireComponent(typeof(Movable))]
    public class Unit : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _deadParticles;
        [SerializeField] private int _particlesCount = 1;
        public void Deactivate()
        {
            _deadParticles.Emit(_particlesCount);
            StartCoroutine(DisableAfterParticles());
        }

        private IEnumerator DisableAfterParticles()
        {
            yield return new WaitForSeconds(0.1f);
            gameObject.SetActive(false);
        }
    }
}