using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Effector : MonoBehaviour
{
        [Header("Tornado Force")]
        [Tooltip("The power how strong an object will be hold into the tornado")]
        [SerializeField] private float centripetalForce = 10;
        
        [Tooltip("The power how fast an object will be sucked into the tornado")]
        [SerializeField] private float acceleration = 3;
        
        [Tooltip("Overall multiplier. Higher value means bigger tornado swirl diameter")]
        [SerializeField] private float forceMultiplier;

        [Header("Tornado Swirl Behaviour")]
        [Tooltip("Very fragile Value. Must be higher then the remapDistance output. Otherwise it reverse the effect")]
        [SerializeField] private float referceIndicationValue;
        
        [Tooltip("This value must be higher then the posPointB or higher then 21")]
        [SerializeField] private float posPointA = 8;
        [SerializeField] private float posPointB = 5;
        
        // a positive value of (d-c) would lead to a negative return in the Swirl effect.
        // tofA must be bigger then tofB because we need a negative value for t
        [SerializeField] [Range(0.6f,1f)] private float tofA = 1;
        [SerializeField] [Range(0f,0.5f)] private float tofB = 1;
        
        private float _thresholdDistance;
        private float _scalarBetweenAB;
        private Vector3 _vectorAToB;
        private Vector3 _direction;
        private float speed = 10;
        private float upMultiplier = 2.2f;

        private void Suction(Collider col) {
            _vectorAToB = transform.position - col.transform.position;
            _scalarBetweenAB = _vectorAToB.magnitude;
            _direction = _vectorAToB / _scalarBetweenAB;
            
            // takes the scalar of AB as input and generate a quasi linear interpolation between two points
            // remap distance will reverse after max reach
            _thresholdDistance = _scalarBetweenAB.Swirl(posPointA, posPointB, tofA, tofB);
            
            // if the remapDistance is lower then the given value it reserve the direction by acceleration and gives the needed tornado effect
            // as the objects starts with acceleration then gets moved from A to B by the vector direction. If max is reached direction 
            // gets replaced with acceleration, which inverse the object movement
            if (_thresholdDistance > referceIndicationValue) {
                _direction = -_direction;
                _thresholdDistance = acceleration;
            }

            if (col.attachedRigidbody != null)
                col.attachedRigidbody.AddForce(_direction * centripetalForce * forceMultiplier * _thresholdDistance);
        }

        private void OnTriggerStay(Collider other) {
            var reduction = 0.9f;
            if (other.CompareTag("Spinable")) {
                Suction(other);
                //other.transform.position += Vector3.up * speed * Time.deltaTime;
                //other.attachedRigidbody.mass -= reduction * Time.deltaTime;
            }
        }

        
}
