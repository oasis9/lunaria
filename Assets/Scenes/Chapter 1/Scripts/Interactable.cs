using UnityEngine;

public class Interactable : LunariaBehaviour {
    public virtual bool PlayerNearby { get; protected set; }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player") {
            PlayerNearby = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.tag == "Player") {
            PlayerNearby = false;
        }
    }
}
