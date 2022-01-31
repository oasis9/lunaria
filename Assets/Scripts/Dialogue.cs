using System;
using UnityEngine;

[Serializable]
public class Dialogue {

    public string Name;
    public Sprite Sprite;
    public bool FacingRight;
    public Sprite DialogueSprite;
    public Vector2 DialogueOffset;

    public Action Next;

}