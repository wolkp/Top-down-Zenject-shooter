using System;
using System.Threading;
using UnityEngine;
using Zenject;

public class CameraController : IInitializable, IDisposable
{
    private readonly SignalBus _signalBus;

    public Camera Camera { get; private set; }

    private Vector3 _cameraOffset;

    public CameraController(SignalBus signalBus, CameraControllerInstaller.Settings settings)
    {
        _signalBus = signalBus;
        _cameraOffset = settings.CameraOffset;
    }

    public void Initialize()
    {
        InitializeCamera();

        _signalBus.Subscribe<MoveSignal>(OnMoveSignal);
        _signalBus.Subscribe<PlayerRigidbodyMoveSignal>(OnRigidbodyMoveSignal);
    }

    public void Dispose()
    {
        _signalBus.Unsubscribe<MoveSignal>(OnMoveSignal);
        _signalBus.Unsubscribe<PlayerRigidbodyMoveSignal>(OnRigidbodyMoveSignal);
    }

    private void InitializeCamera()
    {
        Camera = Camera.main;
    }

    private void OnMoveSignal(MoveSignal signal)
    {
        if (signal.Context.Movable is not PlayerMovement playerMovement)
            return;

        SetCameraPosition(playerMovement.transform.position);
    }

    private void OnRigidbodyMoveSignal(PlayerRigidbodyMoveSignal signal)
    {
        SetCameraPosition(signal.PlayerMovement.transform.position);
    }

    private void SetCameraPosition(Vector3 position)
    {
        Camera.transform.position = position + _cameraOffset;
    }
}