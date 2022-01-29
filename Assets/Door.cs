using System.Collections;
using UnityEngine;

public class Door : Interactable {
    public OngoingInteraction[] Interactions;
    private AudioSource audioSource;

    public override void Awake() {
        base.Awake();

        audioSource = GetComponentInChildren<AudioSource>();
    }

    public delegate void Callback();
    void Update() {
        if (PlayerNearby && Input.GetKeyDown(KeyCode.E)) {
            audioSource.Play();
            //if (Interactions.Length > 0) {
            //    StartCoroutine(Delayed(audioSource.clip.length, () => {
            //        Lunaria.Player.Renderer.sprite = Lunaria.Player.Sprites.GetSprite("Idle01").Sprite;
            //        StartCoroutine(Delayed(1, () => Lunaria.StartInteraction(Interactions[0])));
            //    }));
            //}
        }
    }

    IEnumerator Delayed(float length, Callback callback) {
        yield return new WaitForSeconds(length);
        callback();
    }
}
