using UnityEngine;

public class CurvedFloor : Floor
{
    [SerializeField] private bool _isLeftDirection;

    protected override void ProcessFloorBehaviour(Collider other)
    {
        base.ProcessFloorBehaviour(other);
        PlayerController playerController = other.GetComponent<PlayerController>();

        if(playerController)
            playerController.SetPlayerRotationTarget(_isLeftDirection);
    }
}
