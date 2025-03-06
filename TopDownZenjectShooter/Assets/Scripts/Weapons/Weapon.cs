using UnityEngine;
using Zenject;

public class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponConfig _weaponConfig;
    [SerializeField] private Transform _projectilesOrigin;

    private float _lastShotTime;

    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;

        _signalBus.Subscribe<KeyboardMouseInputSignal>(OnInputReceived);
    }

    private void OnDestroy()
    {
        _signalBus.Unsubscribe<KeyboardMouseInputSignal>(OnInputReceived);
    }

    public void Shoot(IProjectile projectile)
    {
        _lastShotTime = Time.time;
    }

    public bool CanShoot()
    {
        return Time.time - _lastShotTime > _weaponConfig.ShootInterval;
    }

    private void OnInputReceived(KeyboardMouseInputSignal signal)
    {
        if (signal.KeyCode != _weaponConfig.InputKey)
            return;

        if (!CanShoot())
            return;

        var projectile = SpawnProjectile();
        Shoot(projectile);
    }

    private ProjectileBase SpawnProjectile()
    {
        var direction = _projectilesOrigin.TransformDirection(Vector3.forward);
        var rotation = Quaternion.LookRotation(direction);
        var projectile = Instantiate(_weaponConfig.ProjectilePrefab, _projectilesOrigin.position, rotation);

        return projectile;
    }
}