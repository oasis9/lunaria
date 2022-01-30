using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FollowMouse : LunariaBehaviour {
    void Start() {

    }

    void Update() {
        transform.position = Lunaria.GameCamera.Camera.ScreenToWorldPoint(Input.mousePosition);
    }
}
