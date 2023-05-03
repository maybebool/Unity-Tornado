using UnityEngine;

public class SimplePath : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed = 2f;
    private int _waypointIndex;

    private void Start() {
        transform.position = waypoints[_waypointIndex].transform.position;
    }

    private void Update() {
        Patrol();
    }

    private void Patrol() {
        transform.position = Vector3.MoveTowards(transform.position,
            waypoints[_waypointIndex].transform.position, speed * Time.deltaTime);

        if (transform.position == waypoints[_waypointIndex].transform.position) {
            _waypointIndex += 1;
        }

        if (_waypointIndex == waypoints.Length) {
            _waypointIndex = 0;
        }
    }
}