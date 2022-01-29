using UnityEngine;

public class Lunaria : MonoBehaviour {
    public GameCamera GameCamera;
    public Player Player;
    public Background Background;

    void Awake() {
        GameCamera = GetComponentInChildren<GameCamera>();
        Player = GetComponentInChildren<Player>();
        Background = GetComponentInChildren<Background>();
    }

    void Update() {

    }
}
