using UnityEngine;

public class LunariaBehaviour : MonoBehaviour {
    public Lunaria Lunaria;

    public virtual void Awake() {
        if (Lunaria == null) Lunaria = GetComponentInParent<Lunaria>();
    }
}
