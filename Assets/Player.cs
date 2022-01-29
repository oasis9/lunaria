using System.Linq;
using UnityEngine;

public class Player : LunariaBehaviour {

    // Properties
    public GameCamera GameCamera;
    public Vector2 Speed = Vector2.one;
    public SpriteRenderer ColorSquare;
    public LayerMask HideLayers;
    public KeyCode[] MoveUp = { KeyCode.UpArrow, KeyCode.W };
    public KeyCode[] MoveLeft = { KeyCode.LeftArrow, KeyCode.A };
    public KeyCode[] MoveDown = { KeyCode.DownArrow, KeyCode.S };
    public KeyCode[] MoveRight = { KeyCode.RightArrow, KeyCode.D };

    // Components
    private Rigidbody2D rb;
    private SpriteRenderer renderer;
    private Animator animator;

    private Vector2 backgroundSize;
    private Vector2 backgroundScale;
    private RaycastHit2D hit;

    void Start() {
        // Components
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        // Content
    }

    void Update() {
        rb.velocity = Vector2.zero;

        if (animator.GetInteger("State") != (int) AnimationState.Idle) animator.SetInteger("State", (int)AnimationState.Idle);

        if (MoveUp.Any(key => Input.GetKey(key))) Move(Vector2.up);
        if (MoveLeft.Any(key => Input.GetKey(key))) Move(Vector2.left);
        if (MoveDown.Any(key => Input.GetKey(key))) Move(Vector2.down);
        if (MoveRight.Any(key => Input.GetKey(key))) Move(Vector2.right);

        GameCamera.Focus(transform.position);

        if ((hit = Physics2D.Raycast(transform.position, transform.forward, 1000f)).collider != null) {
            SpriteRenderer backgroundRenderer = hit.collider.GetComponent<SpriteRenderer>();
            Texture2D backgroundTexture = backgroundRenderer.sprite.texture;

            Vector2 point = new Vector2(
                backgroundScale.x * ((hit.point.x - backgroundRenderer.transform.position.x) / backgroundRenderer.transform.localScale.x + backgroundRenderer.size.x / 2),
                backgroundScale.y * ((hit.point.y - backgroundRenderer.transform.position.y) / backgroundRenderer.transform.localScale.y + backgroundRenderer.size.y / 2 - renderer.size.y * renderer.transform.localScale.y));

            backgroundSize = backgroundRenderer.size;
            backgroundScale = new Vector2(
                backgroundTexture.width / backgroundSize.x,
                backgroundTexture.height / backgroundSize.y);

            Color color = backgroundTexture.GetPixel(
                (int)point.x,
                (int)point.y);

            renderer.color = color;

            //Texture2D sample = new Texture2D(150, 150);
            //sample.SetPixels(backgroundTexture.GetPixels(
            //    (int)Mathf.Clamp(point.x - 75, 0, backgroundTexture.width - 150),
            //    (int)Mathf.Clamp(point.y - 75, 0, backgroundTexture.height - 150),
            //    sample.width,
            //    sample.height));

            //int centreSize = 10;
            //Color[] centre = new Color[centreSize * centreSize];
            //Color highlight = Color.white;
            //for (int i = 0; i < centre.Length; i++) {
            //    centre[i] = highlight;
            //}
            //sample.SetPixels(
            //    sample.width / 2 - centreSize / 2,
            //    sample.height / 2 - centreSize / 2,
            //    centreSize,
            //    centreSize,
            //    centre);

            //sample.Apply();

            //ColorSquare.sprite = Sprite.Create(
            //    sample,
            //    new Rect(
            //        0,
            //        0,
            //        sample.width,
            //        sample.height),
            //    Vector2.zero);
        }
    }

    void Move(Vector2 velocity) {
        rb.velocity += velocity * Speed;

        animator.SetInteger("State", (int) AnimationState.Walking);
    }

    private enum AnimationState {
        Idle = 0,
        Walking = 1
    }
}
