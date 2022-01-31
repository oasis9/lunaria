using UnityEngine;

public class Afterglow : LunariaBehaviour {

    public Vector2 Range = Vector2.up;
    public Vector2 Timespan = new Vector2(5, 5);
    public SpriteRenderer Renderer;
    public bool IsInwards = true;
    private float interpolator;

    void Start() {
        Set(ref Renderer);
    }

    void Update() {
        interpolator += 1 / (IsInwards ? Timespan.x : Timespan.y) * Time.deltaTime;

        Renderer.color = new Color(1, 1, 1, IsInwards? Mathf.Lerp(Range.x, Range.y, interpolator) : Mathf.Lerp(Range.y, Range.x, interpolator));
        if (Renderer.color.a == (IsInwards? Range.y : Range.x)) {
            IsInwards = !IsInwards;
            interpolator = 0;
        }
    }
}
