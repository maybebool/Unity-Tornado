using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MousePosition : MonoBehaviour
{
    public Vector3 screenPos;
    public Vector3 worldPos;
    public LayerMask hitLayer;


    private void Update() {
        screenPos = Input.mousePosition;
        var ray = Camera.main.ScreenPointToRay(screenPos);
        if (Physics.Raycast(ray, out RaycastHit hitData, 120, hitLayer)) {
            worldPos = hitData.point;
        }
        transform.position = worldPos;
    }
}
