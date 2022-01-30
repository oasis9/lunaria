using UnityEngine;

public class Background : LunariaBehaviour {

    public SpriteRenderer Renderer;
    public Bounds Bounds;

    private EdgeCollider2D edgeCollider;

    public override void Awake() {
        base.Awake();

        Renderer = GetComponent<SpriteRenderer>();

        Bounds = new Bounds(Vector3.zero, new Vector3(
            Renderer.size.x * Renderer.transform.localScale.x / 2,
            Renderer.size.y * Renderer.transform.localScale.y / 2));
    }

    void Start() {
        edgeCollider = gameObject.AddComponent(typeof(EdgeCollider2D)) as EdgeCollider2D;
        edgeCollider.points = new Vector2[] {
            new Vector2(
                transform.position.x - Renderer.size.x / 2,
                transform.position.y + Renderer.size.y / 2
            ),
            new Vector2(
                transform.position.x + Renderer.size.x / 2,
                transform.position.y + Renderer.size.y / 2
            ),
            new Vector2(
                transform.position.x + Renderer.size.x / 2,
                transform.position.y - Renderer.size.y / 2
            ),
            new Vector2(
                transform.position.x - Renderer.size.x / 2,
                transform.position.y - Renderer.size.y / 2
            ),
            new Vector2(
                transform.position.x - Renderer.size.x / 2,
                transform.position.y + Renderer.size.y / 2
            )
        };
    }

    void Update() {

    }
}
