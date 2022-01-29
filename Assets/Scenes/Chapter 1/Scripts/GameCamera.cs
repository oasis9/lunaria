using UnityEngine;

public class GameCamera : LunariaBehaviour {

    public SpriteRenderer backgroundSpriteRenderer;
    public Camera Camera;
    public Bounds BackgroundBounds { get; private set; }
    public SpriteRenderer Dialogue;

    void Start() {
        Dialogue = GetComponentInChildren<SpriteRenderer>();

        Camera = GetComponent<Camera>();

        float orthographicSize = Camera.orthographicSize;
        float height = 2f * Camera.orthographicSize;
        float width = height * Camera.aspect;

        BackgroundBounds = new Bounds(Vector3.zero, new Vector3(
            backgroundSpriteRenderer.size.x * backgroundSpriteRenderer.transform.localScale.x / 2 - width / 2,
            backgroundSpriteRenderer.size.y * backgroundSpriteRenderer.transform.localScale.y / 2 - height / 2));

        transform.position = new Vector3(
            BackgroundBounds.size.x,
            BackgroundBounds.size.y,
            -10);
    }

    public void Focus(Vector2 focus) {
        transform.position = new Vector3(
            Mathf.Clamp(
                focus.x,
                -BackgroundBounds.size.x,
                BackgroundBounds.size.x),
            Mathf.Clamp(
                focus.y,
                -BackgroundBounds.size.y,
                BackgroundBounds.size.y),
            transform.position.z);
    }

    void Update() {

    }
}
