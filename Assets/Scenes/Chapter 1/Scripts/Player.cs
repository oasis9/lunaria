using System;
using System.Linq;
using UnityEngine;

public class Player : LunariaBehaviour {

    // Properties
    public Vector2 Speed = Vector2.one;
    public LayerMask HideLayers;
    public KeyCode[] MoveUp = { KeyCode.UpArrow, KeyCode.W };
    public KeyCode[] MoveLeft = { KeyCode.LeftArrow, KeyCode.A };
    public KeyCode[] MoveDown = { KeyCode.DownArrow, KeyCode.S };
    public KeyCode[] MoveRight = { KeyCode.RightArrow, KeyCode.D };

    // Components
    public SpriteRenderer Renderer;
    public Rigidbody2D Rigidbody;
    public Animator Animator;

    private Vector2 backgroundSize;
    private Vector2 backgroundScale;
    private RaycastHit2D hit;

    public virtual void Start() {
        // Components
        if (Renderer == null) {
            Renderer = GetComponent<SpriteRenderer>();
        }
        if (Rigidbody == null) {
            Rigidbody = GetComponent<Rigidbody2D>();
        }
        if (Animator == null) {
            Animator = GetComponent<Animator>();
        }
    }

    public virtual void Update() {
        Rigidbody.velocity = Vector2.zero;

        if (Animator.GetInteger("State") != (int) AnimationState.Idle) Animator.SetInteger("State", (int)AnimationState.Idle);

        bool movingUp = MoveUp.Any(key => Input.GetKey(key));
        bool movingLeft = MoveLeft.Any(key => Input.GetKey(key));
        bool movingDown = MoveDown.Any(key => Input.GetKey(key));
        bool movingRight = MoveRight.Any(key => Input.GetKey(key));
        if (!(movingUp && movingDown)) {
            if (movingUp) Move(Vector2.up);
            else if (movingDown) Move(Vector2.down);
        }
        if (!(movingLeft && movingRight)) {
            if (movingLeft) {
                Move(Vector2.left);
                Renderer.flipX = false;
            } else if (movingRight) {
                Move(Vector2.right);
                Renderer.flipX = true;
            }
        }

        if (MoveLeft.Any(key => Input.GetKeyDown(key))) Renderer.flipX = false;
        if (MoveRight.Any(key => Input.GetKeyDown(key))) Renderer.flipX = true;

        GameCamera camera = Lunaria.GameCamera;
        camera.Focus(transform.position);

        if ((hit = Physics2D.Raycast(transform.position, transform.forward, 1000f)).collider != null) {
            SpriteRenderer backgroundRenderer = hit.collider.GetComponent<SpriteRenderer>();
            Texture2D backgroundTexture = backgroundRenderer.sprite.texture;

            Vector2 point = new Vector2(
                backgroundScale.x * (
                    (hit.point.x - backgroundRenderer.transform.position.x) / backgroundRenderer.transform.localScale.x
                    + backgroundRenderer.size.x / 2),
                backgroundScale.y * (
                    (hit.point.y - backgroundRenderer.transform.position.y) / backgroundRenderer.transform.localScale.y
                    + backgroundRenderer.size.y / 2
                    - Renderer.size.y * Renderer.transform.localScale.y));

            backgroundSize = backgroundRenderer.size;
            backgroundScale = new Vector2(
                backgroundTexture.width / backgroundSize.x,
                backgroundTexture.height / backgroundSize.y);

            Color color = backgroundTexture.GetPixel(
                (int)point.x,
                (int)point.y);

            Renderer.color = color;

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
        Rigidbody.velocity += velocity * Speed;

        Animator.SetInteger("State", (int) AnimationState.Walking);
    }

    private enum AnimationState {
        Idle = 0,
        Walking = 1
    }
}
