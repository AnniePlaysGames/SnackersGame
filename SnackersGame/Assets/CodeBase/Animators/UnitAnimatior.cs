using System.Collections;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Input;
using UnityEngine;

public class UnitAnimatior : MonoBehaviour
{
    [SerializeField] private AnimationCurve _scaleCurve;
    [SerializeField] private float _scaleAnimationDuration;
    [SerializeField] private float _rotationSpeed;
    private IInputService _inputService;

    private void Awake() 
        => _inputService = ServiceLocator.Container.Single<IInputService>();

    private void Update()
    {
        float rotateAroundY = _inputService.HorizontalStickPosition.y;
        transform.Rotate(new Vector3(45 * _rotationSpeed, rotateAroundY, 0) * Time.deltaTime);
    }

    private void OnEnable()
    {
        StartCoroutine(PlaySpawnAnimation());
    }

    private IEnumerator PlaySpawnAnimation()
    {
        float expiredSeconds = 0f;
        float progress = 0f;

        while (progress < 1)
        {
            expiredSeconds += Time.deltaTime;
            progress = expiredSeconds / _scaleAnimationDuration;
            float scale = _scaleCurve.Evaluate(progress);

            transform.localScale = new Vector3(scale, scale, scale);
            yield return null;
        }
    }
}