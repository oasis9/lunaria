using UnityEngine;

public class LunariaBehaviour : MonoBehaviour {
    public Lunaria Lunaria { get; private set; }

    void Awake() {
        Lunaria = GetComponentInParent<Lunaria>();
    }
}
