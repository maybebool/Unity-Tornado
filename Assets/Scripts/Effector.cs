using UnityEngine;
using UnityEngine.Serialization;

public class Effector : MonoBehaviour
{
    private const float PosPointA = 0;
    private const float PosPointB = 10;


    [Header("Tornado Force")] [Tooltip("The power how strong an object will be hold into the tornado")] [SerializeField]
    private float centripetalForce = 10;

    [FormerlySerializedAs("acceleration")]
    [Tooltip("The power how fast an object will be sucked into the tornado")]
    [SerializeField]
    private float push = 3;

    [Tooltip("Overall multiplier. Higher value means bigger tornado swirl diameter")] [SerializeField]
    private float forceMultiplier = 10f;

    [Header("Tornado Swirl Behaviour")] [Tooltip("Very fragile Value.")] [SerializeField]
    private float reverseIndicationValue = 0.8f;


    // a positive value of (d-c) would lead to a negative return in the Swirl effect.
    // tofA must be bigger then tofB because we need a negative value for t
    private int tofA = 1;
    private int tofB = 0;

    private float _thresholdDistance;
    private float _scalarBetweenAb;
    private Vector3 _vectorAToB;
    private Vector3 _direction;

    private void Suction(Collider col) {
        _vectorAToB = transform.position - col.transform.position;
        _scalarBetweenAb = _vectorAToB.magnitude;
        _direction = _vectorAToB / _scalarBetweenAb;

        // takes the scalar of AB as input and generate a quasi linear interpolation between two points
        // remap distance will reverse after max reach
        _thresholdDistance = _scalarBetweenAb.Swirl(PosPointA, PosPointB, tofA, tofB);

        // if the remapDistance is lower then the given value it reserve the direction by acceleration and gives the needed tornado effect
        // as the objects starts with acceleration then gets moved from A to B by the vector direction. If max is reached direction 
        // gets replaced with acceleration, which inverse the object movement
        if (_thresholdDistance > reverseIndicationValue) {
            _direction = -_direction;
            _thresholdDistance = push;
        }

        if (col.attachedRigidbody != null)
            col.attachedRigidbody.AddForce(_direction * centripetalForce * forceMultiplier * _thresholdDistance);
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Spinable")) {
            Suction(other);
        }
    }
}
