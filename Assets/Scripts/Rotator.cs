using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 10f;
    
    
    

    private void Update() {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        
    }
    
}
