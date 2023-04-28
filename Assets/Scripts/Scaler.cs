using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    
    public CapsuleCollider capsuleCollider;
    public float minRadius = 10f;
    public float maxRadius = 14f;
    public float speed = 1f;
    
    void Update()
    {
        float radius = Mathf.Lerp(minRadius, maxRadius, Mathf.Abs(Mathf.Sin(Time.time * speed)));
        capsuleCollider.radius = radius;
        
    }
}
