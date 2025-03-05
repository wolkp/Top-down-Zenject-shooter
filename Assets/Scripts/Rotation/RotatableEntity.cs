using UnityEngine;

public abstract class RotatableEntity : MonoBehaviour, IRotatable
{
    [SerializeField] private RotationConfig _config;

    protected virtual Transform RotatedTransform => transform;
    protected float RotationSpeed => _config.Speed;

    protected abstract Vector3 RotationTarget { get; }

    protected abstract bool CanRotate();

    protected virtual void Update()
    {
        Rotate();
    }

    public void Rotate()
    {
        if (CanRotate())
        {
            RotateTowards(RotationTarget);
        }
    }

    public void RotateTowards(Vector3 targetPosition)
    {
        var direction = (RotationTarget - RotatedTransform.position).normalized;

        if (direction.sqrMagnitude > 0.01f)
        {
            var targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            RotatedTransform.rotation = Quaternion.Slerp(
                RotatedTransform.rotation,
                targetRotation,
                RotationSpeed * Time.deltaTime
            );
        }
    }
}
