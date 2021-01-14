using UnityEngine;

public class FinishFloor : Floor
{
    protected override void ProcessFloorBehaviour(Collider other)
    {
        base.ProcessFloorBehaviour(other);
        PlayerController playerController = other.GetComponent<PlayerController>();

        if(playerController)
            playerController.SetFinishState();
    }
}