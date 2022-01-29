using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : LunariaBehaviour {

    public string SceneName;
    public Collider2D Collider;
    public bool Inside;

    public override void Awake() {
        base.Awake();

        Collider = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (!Inside && collider.tag == "Player") SceneManager.LoadSceneAsync(SceneName);
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.tag == "Player") Inside = false;
    }
}
