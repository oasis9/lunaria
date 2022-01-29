using UnityEngine;

public class Afterglow : LunariaBehaviour {

    public Vector2 Range = Vector2.left;
    public Vector2 Time = new Vector2(5, 5);
    public SpriteRenderer Renderer;
    public bool IsInwards = true;

    void Start() {
        if (Renderer == null) Renderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        Renderer.color = new Color(1, 1, 1, IsInwards? Mathf.Lerp(Range.x, Range.y, Time.x) : Mathf.Lerp(Range.y, Range.x, Time.y));
    }
}
