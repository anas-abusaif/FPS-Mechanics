using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    public virtual void Jump() { }
    public virtual void ApplyMovement(Vector3 Direction) { }
}