using UnityEngine;

public class Effector : MonoBehaviour
{
    private const float PosPointA = 0;
    private const float PosPointB = 10;
    
    // a positive value of (toA - toB) would lead to a negative return in the Tornado effect.
    private const int ToA = 1;
    private const int ToB = 0;
    
    [Header("Tornado Physic Parameters")]
    
    [Tooltip("The power how strong an object will be hold into the tornado")] 
    [SerializeField] private float centripetalForce = 10;
    
    
    [Tooltip("Counter force to centripetal Force")]
    [SerializeField] private float push = 3;
    
    [Tooltip("Overall Multiplication for centripetal Force")]
    [SerializeField] private float forceMultiplier = 10f;
    
    
    [Tooltip("Value point where forces will be reversed. Very fragile Value.")] 
    [SerializeField] private float reverseIndicationValue = 0.8f;

    
    private float _thresholdDistance;
    private float _scalarBetweenAb;
    private Vector3 _vectorAToB;
    private Vector3 _direction;

    private void TornadoPhysics(Collider objCol) {
        _vectorAToB = transform.position - objCol.transform.position;
        _scalarBetweenAb = _vectorAToB.magnitude;
        _direction = _vectorAToB / _scalarBetweenAb;

        // takes the scalar of AB as input and generate a quasi linear interpolation between two points
        // remap distance will reverse after max reach
        _thresholdDistance = _scalarBetweenAb.TornadoRotation(PosPointA, PosPointB, ToA, ToB);

        // if the remapDistance is lower then the given value it reserve the direction by acceleration and gives the needed tornado effect
        // as the objects starts with acceleration then gets moved from A to B by the vector direction. If max is reached direction 
        // gets replaced with acceleration, which inverse the object movement
        if (_thresholdDistance > reverseIndicationValue) {
            _direction = -_direction;
            _thresholdDistance = push;
        }

        if (objCol.attachedRigidbody != null)
            objCol.attachedRigidbody.AddForce(_direction * centripetalForce * forceMultiplier * _thresholdDistance);
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Object")) {
            TornadoPhysics(other);
        }
    }
}
