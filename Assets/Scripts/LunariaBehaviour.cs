using System.Linq;
using UnityEngine;

public class LunariaBehaviour : MonoBehaviour {
    internal Lunaria Lunaria;

    public virtual void Awake() {
        SetFromParent(ref Lunaria);
    }

    public void Set<T>(ref T set) {
        if (ShouldSet(set)) set = GetComponent<T>();
    }

    public void SetFromParent<T>(ref T set) {
        if (ShouldSet(set)) set = GetComponentInParent<T>();
    }

    public void SetFromChildren<T>(ref T set) {
        if (ShouldSet(set)) set = GetComponentInChildren<T>();
    }

    private bool ShouldSet<T>(T set) {
        return set == null || set.Equals(null);
    }
}
