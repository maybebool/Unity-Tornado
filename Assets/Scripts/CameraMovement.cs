using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform anchor;
    private float _multiplier;
    private float _time;
    private void Update() {
        transform.RotateAround (anchor.transform.position, Vector3.up, 30 * Time.deltaTime * _multiplier);
    }


    public void SliderMultiplier(float adjustingSpeed) {
        _multiplier = adjustingSpeed;
    }
}
