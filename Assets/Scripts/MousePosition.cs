using UnityEngine;

public class MousePosition : MonoBehaviour
{
    private Vector3 _screenPos;
    private Vector3 _worldPos;
    public LayerMask hitLayer;
    private Camera _camera;

    private void Awake() {
        _camera = Camera.main;
    }
    
    private void Update() {
        _screenPos = Input.mousePosition;
        var ray = _camera.ScreenPointToRay(_screenPos);
        var hitBool = Physics.Raycast(ray, out RaycastHit hitData, 400, hitLayer);
        if (hitBool) {
            _worldPos = hitData.point;
            Cursor.visible = false;
            transform.position = _worldPos;
        }
        else {
            _worldPos = hitData.point;
            Cursor.visible = true;
        }
    }
}
