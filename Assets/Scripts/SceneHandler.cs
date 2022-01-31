using UnityEngine;

public class SceneHandler : LunariaBehaviour {

    public SpawnLocation[] Spawns = new SpawnLocation[0];

    public new void Awake() {
        base.Awake();

        string lastLevelName = PlayerPrefs.GetString("LevelName", null);
        PlayerPrefs.SetString("LastLevelName", lastLevelName);
        PlayerPrefs.SetString("LevelName", gameObject.scene.name);

        foreach (SpawnLocation spawn in Spawns) {
            if (spawn.LastLevelName == lastLevelName) {
                Lunaria.Player.transform.position = spawn.Location;
                Lunaria.Player.Renderer.flipX = spawn.FacingRight;
            }
        }
    }
}
