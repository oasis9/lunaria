using UnityEngine;

public class GameCamera : LunariaBehaviour {

    public Camera Camera;
    public Bounds CameraMovementBounds { get; private set; }
    public SpriteRenderer Dialogue;
    public bool Move = true;

    void Start() {
        if (Dialogue == null) Dialogue = GetComponentInChildren<SpriteRenderer>();

        Camera = GetComponent<Camera>();

        float orthographicSize = Camera.orthographicSize;
        float height = 2f * Camera.orthographicSize;
        float width = height * Camera.aspect;

        CameraMovementBounds = new Bounds(Vector3.zero, new Vector3(
            Lunaria.Background.Bounds.size.x - width / 2,
            Lunaria.Background.Bounds.size.y - height / 2));

        if (!Move) return;

        transform.position = new Vector3(
            CameraMovementBounds.size.x,
            CameraMovementBounds.size.y,
            -10);
    }

    public void Focus(Vector2 focus) {
        if (!Move) return;

        transform.position = new Vector3(
            Mathf.Clamp(
                focus.x,
                -CameraMovementBounds.size.x,
                CameraMovementBounds.size.x),
            Mathf.Clamp(
                focus.y,
                -CameraMovementBounds.size.y,
                CameraMovementBounds.size.y),
            transform.position.z);
    }

    void Update() {

    }
}
