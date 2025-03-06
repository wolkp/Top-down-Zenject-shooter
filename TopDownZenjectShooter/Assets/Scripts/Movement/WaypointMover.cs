using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MovableEntity
{
    private const float WAYPOINT_REACHED_MIN_DISTANCE = 0.1f;

    [SerializeField] private Transform _movedTransform;
    [SerializeField] private List<Transform> _waypoints;

    protected override Vector3 MovementDirection => GetDirectionToCurrentWaypoint();
    protected override Transform MovedTransform => _movedTransform;

    private bool HasWaypoint => _currentWaypoint != null;

    private Transform _currentWaypoint;

    protected override void Awake()
    {
        base.Awake();

        SetNextWaypoint();
    }

    protected override void Update()
    {
        base.Update();
        UpdateCurrentWaypoint();
    }

    protected override bool CanMove()
    {
        return HasWaypoint;
    }

    private void UpdateCurrentWaypoint()
    {
        if(CurrentWaypointReached())
        {
            SetNextWaypoint();
        }
    }

    private void SetNextWaypoint()
    {
        var nextWaypointIndex = 0;

        if (HasWaypoint)
        {
            var currentWaypointIndex = _waypoints.IndexOf(_currentWaypoint);

            if (currentWaypointIndex < _waypoints.Count - 1)
            {
                nextWaypointIndex = currentWaypointIndex + 1;
            }
        }

        var waypointToSet = _waypoints[nextWaypointIndex];
        _currentWaypoint = waypointToSet;
    }

    private bool CurrentWaypointReached()
    {
        if (_currentWaypoint == null)
            return false;

        var distToWaypoint = Vector3.Distance(MovedTransform.position, _currentWaypoint.position);
        var waypointReached = distToWaypoint <= WAYPOINT_REACHED_MIN_DISTANCE;

        return waypointReached;
    }

    private Vector3 GetDirectionToCurrentWaypoint()
    {
        return (_currentWaypoint.position - MovedTransform.position).normalized;
    }
}