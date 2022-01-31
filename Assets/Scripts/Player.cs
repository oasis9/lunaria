using System;
using UnityEngine;

public class Player : LunariaBehaviour {

    // Properties
    public Vector2 Speed = Vector2.one;
    public Vector2 ScaleRange = new Vector2(0.3f, 0.3f);
    public SpriteBatch Sprites = new SpriteBatch();
    public SpriteRenderer PinP;
    public StepSounds[] StepSounds = new StepSounds[0];

    // Components
    public SpriteRenderer Renderer;
    public Rigidbody2D Rigidbody;
    public Animator Animator;
    public AudioSource AudioSource;
    public double SoundEndTimestamp;

    private Vector2 backgroundSize;
    private Vector2 backgroundScale;
    private RaycastHit2D hit;

    public virtual void Start() {
        // Components
        Set(ref Renderer);
        Set(ref Rigidbody);
        Set(ref Animator);
        Set(ref AudioSource);
    }

    public virtual void Update() {
        MovePlayer();
    }

    private void MovePlayer() {
        Rigidbody.velocity = Vector2.zero;

        if (Animator.GetInteger("State") != (int)AnimationState.Idle) Animator.SetInteger("State", (int)AnimationState.Idle);

        bool movingUp = Lunaria.IsMovingUp();
        bool movingLeft = Lunaria.IsMovingLeft();
        bool movingDown = Lunaria.IsMovingDown();
        bool movingRight = Lunaria.IsMovingRight();
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

        HandleInteraction();
        FlipPlayer();
        ScalePlayer();
        FocusCamera();
        PlayStepSounds();
    }

    private void HandleInteraction() {
        if (Lunaria.OngoingDialogue != null && Lunaria.DidStartDialogueProgression()) Lunaria.OngoingDialogue.Next();
    }

    private void FlipPlayer() {
        if (Lunaria.DidStartMovingLeft()) Renderer.flipX = false;
        if (Lunaria.DidStartMovingRight()) Renderer.flipX = true;
    }

    private void ScalePlayer() {
        float scale = ScaleRange.x + (ScaleRange.y - ScaleRange.x)
            * Mathf.Clamp(
                (Lunaria.Background.Bounds.size.y / 2 - transform.position.y)
                / Lunaria.Background.Bounds.size.y, 0, 1);
        //Debug.Log("...");
        //Debug.Log("");
        //Debug.Log(scale);
        Renderer.transform.localScale = new Vector2(scale, scale);
    }

    private void FocusCamera() {
        GameCamera camera = Lunaria.GameCamera;
        camera.Focus(transform.position);
    }

    private void PlayStepSounds() {
        if (PinP != null && (hit = Physics2D.Raycast(transform.position, transform.forward, 1000f)).collider != null) {
            Debug.Log("Potato");
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

            Texture2D sample = new Texture2D(150, 150);
            sample.SetPixels(backgroundTexture.GetPixels(
                (int)Mathf.Clamp(point.x - 75, 0, backgroundTexture.width - 150),
                (int)Mathf.Clamp(point.y - 75, 0, backgroundTexture.height - 150),
                sample.width,
                sample.height));

            int centreSize = 10;
            Color[] centre = new Color[centreSize * centreSize];
            Color highlight = Color.white;
            for (int i = 0; i < centre.Length; i++) {
                centre[i] = highlight;
            }
            sample.SetPixels(
                sample.width / 2 - centreSize / 2,
                sample.height / 2 - centreSize / 2,
                centreSize,
                centreSize,
                centre);

            sample.Apply();

            PinP.sprite = Sprite.Create(
                sample,
                new Rect(
                    0,
                    0,
                    sample.width,
                    sample.height),
                Vector2.zero);
        }
    }

    void Move(Vector2 velocity) {
        Rigidbody.velocity += velocity * Speed;

        Animator.SetInteger("State", (int)AnimationState.Walking);
    }

    public void Play(AudioClip audioClip) {
        AudioSource.clip = audioClip;
        SoundEndTimestamp = Time.time + audioClip.length;
        AudioSource.Play();
    }

    private enum AnimationState {
        Idle = 0,
        Walking = 1
    }
}
