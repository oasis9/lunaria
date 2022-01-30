using System;
using System.Collections;
using UnityEngine;

public class Door : Interactable {
    public Dialogue[] Interactions;
    public bool FacingRight;
    private AudioSource audioSource;

    public override void Awake() {
        base.Awake();

        audioSource = GetComponentInChildren<AudioSource>();
    }

    void Update() {
        if (PlayerNearby && Lunaria.IsInteracting()) {
            audioSource.Play();

            Lunaria.Player.Animator.enabled = false;

            Lunaria.Player.Renderer.sprite = Lunaria.Player.Sprites.GetSprite("Walk01").Sprite;
            Lunaria.Player.Renderer.flipX = FacingRight;

            Lunaria.StopMovement = Lunaria.StopInteraction = true;

            StartCoroutine(Delayed(audioSource.clip.length, () => {
                if (Interactions.Length > 0) {
                    StartCoroutine(Delayed(1, () => Lunaria.ShowDialogues(Interactions, 0, () => {
                        Lunaria.Player.Animator.enabled = true;
                        Lunaria.StopMovement = Lunaria.StopInteraction = false;
                    })));
                } else {
                    Lunaria.Player.Animator.enabled = true;
                    Lunaria.StopMovement = Lunaria.StopInteraction = false;
                    Lunaria.Player.Renderer.sprite = Lunaria.Player.Sprites.GetSprite("Idle01").Sprite;
                }
            }));
        }
    }

    public delegate void Callback();
    IEnumerator Delayed(float length, Callback callback) {
        yield return new WaitForSeconds(length);
        callback();
    }
}
