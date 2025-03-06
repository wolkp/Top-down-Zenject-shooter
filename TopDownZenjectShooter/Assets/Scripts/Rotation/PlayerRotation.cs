using UnityEngine;
using Zenject;

public class PlayerRotation : RotatableEntity
{
    private static string RAYCAST_MASK = "Raycast";

    private CameraController _cameraController;
    private SignalBus _signalBus;

    private Vector3 _mouseScreenPosition;
    private Vector3 _worldTargetPosition;

    protected override Vector3 RotationTarget => _worldTargetPosition;

    [Inject]
    public void Construct(SignalBus signalBus, CameraController cameraController)
    {
        _cameraController = cameraController;
        _signalBus = signalBus;

        _signalBus.Subscribe<MousePositionSignal>(OnMousePositionSignal);
    }

    protected override bool CanRotate()
    {
        return true;
    }

    private void OnDestroy()
    {
        _signalBus.Unsubscribe<MousePositionSignal>(OnMousePositionSignal);
    }

    private void OnMousePositionSignal(MousePositionSignal signal)
    {
        _mouseScreenPosition = signal.ScreenPosition;
        _worldTargetPosition = ScreenToWorld(_mouseScreenPosition);
        _worldTargetPosition.y = transform.position.y;
    }

    private Vector3 ScreenToWorld(Vector3 screenPos)
    {
        var camera = _cameraController.Camera;
        var ray = camera.ScreenPointToRay(screenPos);
        var raycastMask = LayerMask.GetMask(RAYCAST_MASK);

        if (Physics.Raycast(ray.origin, ray.direction, out var hit, raycastMask))
        {
            return hit.point;
        }

        return transform.position;
    }
}