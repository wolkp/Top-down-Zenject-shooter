using UnityEngine;

public abstract class MovableEntity : MonoBehaviour, IMovable
{
    private static float CHECK_FLOOR_AHEAD_RAY_LENGTH = 0.5f;
    private static string FLOOR_MASK = "Floor";

    [SerializeField] private MovementConfig _movementConfig;

    public bool IsGrounded { get; private set; }
    protected abstract Vector3 MovementDirection { get; }
    protected virtual Transform MovedTransform => transform;
    protected float MovementSpeed => _movementConfig.Speed;

    protected Rigidbody movedRigidbody;

    protected abstract bool CanMove();

    protected virtual void Awake()
    {
        movedRigidbody = MovedTransform.GetComponent<Rigidbody>();
    }

    protected virtual void Update() { }

    protected virtual void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        if(CanMove() && CanMoveInDirection(MovementDirection))
        {
            PerformMovement();
        }
    }

    public bool CanMoveInDirection(Vector3 direction)
    {
        var hasFloorInDirection = HasFloorInMovementDirection(direction);

        return !IsGrounded || hasFloorInDirection || !_movementConfig.RequireFloorForMovement;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!IsGameObjectFloor(collision.gameObject))
            return;

        IsGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!IsGameObjectFloor(collision.gameObject))
            return;

        IsGrounded = false;
    }

    private bool HasFloorInMovementDirection(Vector3 movementDirection)
    {
        var worldMovementDirection = MovedTransform.TransformDirection(movementDirection);
        var rayStart = MovedTransform.position + Vector3.up * CHECK_FLOOR_AHEAD_RAY_LENGTH;
        var rayDirection = worldMovementDirection + Vector3.down * CHECK_FLOOR_AHEAD_RAY_LENGTH;

        if(Physics.Raycast(rayStart, rayDirection, out RaycastHit hit))
        {
            if (hit.transform != null && IsGameObjectFloor(hit.transform.gameObject))
                return true;
        }

        return false;
    }

    private bool IsGameObjectFloor(GameObject gObj)
    {
        return gObj.layer == LayerMask.NameToLayer(FLOOR_MASK);
    }


    private void PerformMovement()
    {
        var movementDelta = MovementDirection * MovementSpeed * Time.fixedDeltaTime;

        if (movedRigidbody != null)
        {
            movedRigidbody.velocity = movementDelta;
        }
        else
        {
            MovedTransform.Translate(movementDelta, Space.World);
        }
    }
}