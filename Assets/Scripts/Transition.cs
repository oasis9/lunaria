using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : LunariaBehaviour {

    public string SceneName;
    public Collider2D Collider;
    private AsyncOperation asyncOperation;

    public override void Awake() {
        base.Awake();

        Collider = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player") StartCoroutine("Load");
    }

    IEnumerator Load() {
        string currentScene = SceneManager.GetActiveScene().name;
        asyncOperation = SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
        asyncOperation.allowSceneActivation = true;
        yield return asyncOperation;
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
