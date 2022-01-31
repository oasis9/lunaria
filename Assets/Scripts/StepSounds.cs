using System;
using UnityEngine;

[Serializable]
public class StepSounds {

    public string Name;
    public Color[] TargetColors = new Color[0];
    public float Threshold = 0.2f;
    public AudioClip[] Sounds = new AudioClip[0];

}
