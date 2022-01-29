using UnityEngine;

public class Background : LunariaBehaviour {

    private EdgeCollider2D edgeCollider;

    void Start() {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        edgeCollider = gameObject.AddComponent(typeof(EdgeCollider2D)) as EdgeCollider2D;
        edgeCollider.points = new Vector2[] {
            new Vector2(
                transform.position.x - renderer.size.x / 2,
                transform.position.y + renderer.size.y / 2
            ),
            new Vector2(
                transform.position.x + renderer.size.x / 2,
                transform.position.y + renderer.size.y / 2
            ),
            new Vector2(
                transform.position.x + renderer.size.x / 2,
                transform.position.y - renderer.size.y / 2
            ),
            new Vector2(
                transform.position.x - renderer.size.x / 2,
                transform.position.y - renderer.size.y / 2
            ),
            new Vector2(
                transform.position.x - renderer.size.x / 2,
                transform.position.y + renderer.size.y / 2
            )
        };
    }

    void Update() {

    }
}
