using System.Linq;
using UnityEngine;

public class Mask : LunariaBehaviour {

    public SpriteRenderer Renderer;
    public float FadeInSpeed = 1;
    public float FadeInDelay = 0;

    private bool fadeIn;
    private float fadeInMax;
    private float fadeTriggerTime;
    private float fadeInterpolator;

    public override void Awake() {
        base.Awake();

        SetFromParent(ref Renderer);

        fadeInMax = Renderer.color.a;
        Renderer.color = Color.clear;
    }

    void Start() {
    }

    void Update() {
        if (fadeTriggerTime == 0 && Lunaria.DidStartMouseDown()) fadeTriggerTime = Time.time + FadeInDelay;
        if (fadeTriggerTime != 0 && !fadeIn && fadeTriggerTime < Time.time) fadeIn = true;

        if (fadeIn && fadeInterpolator < 1) {
            Renderer.color = new Color(1, 1, 1, Mathf.Lerp(0, fadeInMax, fadeInterpolator));
            fadeInterpolator += Time.deltaTime * 1 / FadeInSpeed;
        }

        Vector3 worldPoint = Lunaria.GameCamera.Camera.ScreenToWorldPoint(Input.mousePosition);
        worldPoint.z = 0;
        transform.position = worldPoint;
    }
}
