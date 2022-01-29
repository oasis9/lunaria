using System;
using UnityEngine;

[Serializable]
public class OngoingInteraction {

    public string Name;
    public Sprite Sprite;
    public bool FacingRight;
    public Sprite Dialogue;
    public Vector2 DialogueOffset;
    public OngoingInteraction NextInteraction;

}