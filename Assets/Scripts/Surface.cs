using UnityEngine;

public class Surface : LunariaBehaviour {

    public AudioClip[] SoundPool;
    public double Delay;

    private bool Inside;
    private double LastPlayTimestamp;

    void Start() {

    }

    void Update() {
        if (Inside
            && LastPlayTimestamp < Time.time
            && Lunaria.IsMoving()) {
            LastPlayTimestamp = Time.time + Delay;
            Lunaria.Player.Play(SoundPool[Random.Range(0, SoundPool.Length)]);
        }
    }

    private void OnTriggerStay2D(Collider2D collider) {
        if (!Inside && collider.tag == "Player") Inside = true;
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.tag == "Player") Inside = false;
    }
}
