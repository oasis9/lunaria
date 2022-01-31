using UnityEngine;

public class TitleBackground : Background {

    private Resolution resolution;

    public override void Start() {
        base.Start();

        resolution = Screen.currentResolution;

        FitToCamera();
    }

    public virtual void Update() {
        if (resolution.width != Screen.currentResolution.width
            || resolution.height != Screen.currentResolution.height) FitToCamera();
    }
}
