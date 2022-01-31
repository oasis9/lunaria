using UnityEngine;

public class GameCamera : LunariaBehaviour {

    public Camera Camera;
    public AudioListener AudioListener;
    public Bounds CameraMovementBounds { get; private set; }
    public SpriteRenderer Dialogue;
    public bool Move = true;

    public override void Awake() {
        base.Awake();

        SetFromChildren(ref Dialogue);
        Set(ref Camera);
        Set(ref AudioListener);
    }

    public virtual void Start() {
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
}
