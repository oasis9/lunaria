using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orderer : MonoBehaviour {

    public float Threshold;
    public GameObject OnObject;
    public Vector2 SwitchLayers;
    public SpriteRenderer Renderer;

    void Start() {
        if (Renderer == null) Renderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        Renderer.sortingOrder = (int)(OnObject.transform.position.y < Threshold ? SwitchLayers.x : SwitchLayers.y);
    }
}
