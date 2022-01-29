using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidgroundsPlayer : Player {

    public override void Start() {
        base.Start();

        string lastLevelName = PlayerPrefs.GetString("LastLevelName", null);
        if (lastLevelName == null) {
            Debug.Log("yay");
        }
    }

    public override void Update() {
        base.Update();


    }
}
