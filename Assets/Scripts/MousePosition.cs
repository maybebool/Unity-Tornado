using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public Vector3 screenPos;
    public Vector3 worldPos;
    private Plane plane = new Plane(Vector3.down, 0);


    private void Update() {
        screenPos = Input.mousePosition;
        var ray = Camera.main.ScreenPointToRay(screenPos);
        if (plane.Raycast(ray, out float distance)) {
            worldPos = ray.GetPoint(distance);
        }
        transform.position = worldPos;
    }
}
