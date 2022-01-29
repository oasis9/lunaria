using UnityEngine;

public class Lunaria : MonoBehaviour {
    public GameCamera GameCamera;
    public Player Player;
    public Background Background;
    public OngoingInteraction Interaction { get; private set; }

    void Awake() {
        GameCamera = GetComponentInChildren<GameCamera>();
        Player = GetComponentInChildren<Player>();
        Background = GetComponentInChildren<Background>();
    }

    void Update() {

    }

    public void StartInteraction(OngoingInteraction interaction) {
        Interaction = interaction;

        Debug.Log(Interaction.Name);
        Player.Animator.enabled = false;
        Player.Renderer.sprite = Interaction.Sprite;
        Player.Renderer.flipX = Interaction.FacingRight;
        GameCamera.Dialogue.sprite = Interaction.Dialogue;

        float orthographicSize = GameCamera.Camera.orthographicSize;
        float height = 2f * GameCamera.Camera.orthographicSize;
        GameCamera.Dialogue.transform.position = new Vector2(0, height - GameCamera.Dialogue.size.y / 2);
        //GameCamera.Dialogue.transform.position = Interaction.DialogueOffset;
    }
}
