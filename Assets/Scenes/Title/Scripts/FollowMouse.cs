using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FollowMouse : LunariaBehaviour {
    void Start() {

    }

    void Update() {
        Vector3 worldPoint = Lunaria.GameCamera.Camera.ScreenToWorldPoint(Input.mousePosition);
        worldPoint.z = 0;
        transform.position = worldPoint;
    }
}
