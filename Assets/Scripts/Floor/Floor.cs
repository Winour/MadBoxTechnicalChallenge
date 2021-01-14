using UnityEngine;

public abstract class Floor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ProcessFloorBehaviour(other);
    }

    protected virtual void ProcessFloorBehaviour(Collider other) { }
}
