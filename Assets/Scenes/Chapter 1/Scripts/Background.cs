using UnityEngine;

public class Background : LunariaBehaviour {

    public SpriteRenderer Renderer;

    private EdgeCollider2D edgeCollider;

    void Awake() {
        Renderer = GetComponent<SpriteRenderer>();
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
