using System;
using System.Linq;
using UnityEngine;

public class Lunaria : MonoBehaviour {
    public GameCamera GameCamera;
    public Player Player;
    public Background Background;

    public KeyCode[] MoveUp = { KeyCode.UpArrow, KeyCode.W };
    public KeyCode[] MoveLeft = { KeyCode.LeftArrow, KeyCode.A };
    public KeyCode[] MoveDown = { KeyCode.DownArrow, KeyCode.S };
    public KeyCode[] MoveRight = { KeyCode.RightArrow, KeyCode.D };
    public KeyCode[] Interact = { KeyCode.E };
    public KeyCode[] DialogueProgression = { KeyCode.Space, KeyCode.X, KeyCode.Z };

    public bool StopMovement = false;
    public bool StopInteraction = false;
    public bool StopDialogueProgression = false;
    public Dialogue OngoingDialogue { get; private set; }

    void Awake() {
        GameCamera = GetComponentInChildren<GameCamera>();
        Player = GetComponentInChildren<Player>();
        Background = GetComponentInChildren<Background>();
    }

    void Update() {

    }

    public bool GetKeysDown(KeyCode[] keys) {
        return keys.Any(key => Input.GetKeyDown(key));
    }
    public bool GetKeys(KeyCode[] keys) {
        return keys.Any(key => Input.GetKey(key));
    }

    public bool DidStartMoving(KeyCode[] keys) {
        return !StopMovement && GetKeysDown(keys);
    }
    public bool IsMoving(KeyCode[] keys) {
        return !StopMovement && GetKeys(keys);
    }


    public bool IsMoving() {
        return IsMovingUp()
            || IsMovingLeft()
            || IsMovingDown()
            || IsMovingRight();
    }

    public bool DidStartMovingUp() {
        return DidStartMoving(MoveUp);
    }
    public bool IsMovingUp() {
        return IsMoving(MoveUp);
    }

    public bool DidStartMovingLeft() {
        return DidStartMoving(MoveLeft);
    }
    public bool IsMovingLeft() {
        return IsMoving(MoveLeft);
    }

    public bool DidStartMovingDown() {
        return DidStartMoving(MoveDown);
    }
    public bool IsMovingDown() {
        return IsMoving(MoveDown);
    }

    public bool DidStartMovingRight() {
        return DidStartMoving(MoveRight);
    }
    public bool IsMovingRight() {
        return IsMoving(MoveRight);
    }

    public bool DidStartInteract() {
        return !StopInteraction && GetKeysDown(Interact);
    }
    public bool IsInteracting() {
        return !StopInteraction && GetKeys(Interact);
    }

    public bool DidStartDialogueProgression() {
        return !StopDialogueProgression && GetKeysDown(DialogueProgression);
    }
    public bool IsDialogueProgression() {
        return !StopDialogueProgression && GetKeys(DialogueProgression);
    }

    public void ShowDialogues(Dialogue[] dialogues, int i) {
        if (dialogues.Length > i) {
            if (dialogues.Length > i + 1 && dialogues[i].Next == null) dialogues[i].Next = NextInteraction(dialogues, i + 1);
            if (dialogues[dialogues.Length - 1].Next == null) {
                dialogues[dialogues.Length - 1].Next = () => {
                    OngoingDialogue = null;
                    GameCamera.Dialogue.sprite = null;
                    StopMovement = StopInteraction = false;
                };
            }
            ShowDialogue(dialogues[i]);
        }
    }

    public void ShowDialogues(Dialogue[] dialogues, int i, Action finished) {
        dialogues[dialogues.Length - 1].Next = () => {
            OngoingDialogue = null;
            GameCamera.Dialogue.sprite = null;
            finished();
        };
        ShowDialogues(dialogues, i);
    }

    public void ShowDialogue(Dialogue dialogue) {
        StopMovement = StopInteraction = true;

        OngoingDialogue = dialogue;

        Debug.Log(OngoingDialogue.Name);
        Player.Animator.enabled = false;

        if (OngoingDialogue.Sprite != null) Player.Renderer.sprite = OngoingDialogue.Sprite;

        Player.Renderer.flipX = OngoingDialogue.FacingRight;
        GameCamera.Dialogue.sprite = OngoingDialogue.DialogueSprite;

        float orthographicSize = GameCamera.Camera.orthographicSize;
        float height = 2f * GameCamera.Camera.orthographicSize;
        //GameCamera.Dialogue.transform.position = Interaction.DialogueOffset;

        GameCamera.Dialogue.transform.localPosition = new Vector2(0, -height);
    }

    public Action NextInteraction(Dialogue[] dialogues, int i) {
        return () => {
            if (dialogues.Length > i) {
                if (dialogues.Length > i + 1 && dialogues[i].Next == null) dialogues[i].Next = NextInteraction(dialogues, i);
                ShowDialogue(dialogues[i]);
            } else {
                OngoingDialogue = null;
            }
        };
    }
}
