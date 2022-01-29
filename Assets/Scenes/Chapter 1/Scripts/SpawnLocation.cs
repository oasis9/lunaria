using System;
using UnityEngine;

[Serializable]
public class SpawnLocation {
    public string LastLevelName;
    public Vector2 Location;
    public bool FacingRight;
    public Transition Transition;
}
