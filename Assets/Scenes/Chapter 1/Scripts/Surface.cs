using UnityEngine;

public class Surface : LunariaBehaviour {

    public string Name;
    public AudioClip[] SoundPool;

    private bool Inside;

    void Start() {

    }

    void Update() {
        if (Inside
            && Lunaria.Player.SoundEndTimestamp < Time.time
            && Lunaria.Player.Rigidbody.velocity.x + Lunaria.Player.Rigidbody.velocity.y > 0) {
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
