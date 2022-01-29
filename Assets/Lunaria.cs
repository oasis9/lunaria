using UnityEngine;

public class Lunaria : MonoBehaviour {
    public GameCamera camera;
    public Player player;
    public Background background;

    void Start() {
        camera = GetComponentInChildren<GameCamera>();
        player = GetComponentInChildren<Player>();
        background = GetComponentInChildren<Background>();
    }

    void Update() {

    }
}
