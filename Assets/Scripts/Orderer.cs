using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orderer : LunariaBehaviour {

    public float Threshold;
    public GameObject OnObject;
    public Vector2 SwitchLayers;
    public SpriteRenderer Renderer;

    void Start() {
        Set(ref Renderer);
    }

    void Update() {
        Renderer.sortingOrder = (int)(OnObject.transform.position.y < Threshold ? SwitchLayers.x : SwitchLayers.y);
    }
}
