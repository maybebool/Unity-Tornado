using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public Vector3 screenPos;
    public Vector3 worldPos;
    public LayerMask hitLayer;
    private Camera _camera;

    private void Awake() {
        _camera = Camera.main;
    }
    
    private void Update() {
        screenPos = Input.mousePosition;
        var ray = _camera.ScreenPointToRay(screenPos);
        var hitBool = Physics.Raycast(ray, out RaycastHit hitData, 400, hitLayer);
        if (hitBool) {
            worldPos = hitData.point;
            Cursor.visible = false;
            transform.position = worldPos;
        }
        else {
            worldPos = hitData.point;
            Cursor.visible = true;
        }
    }
}
