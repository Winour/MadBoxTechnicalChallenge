using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbeableObstacle : Obstacle
{
    [SerializeField] private Transform _topPosition;
    protected override void ProcessObstacleBehaviour(Collider other)
    {
        base.ProcessObstacleBehaviour(other);
        PlayerController playerController = other.GetComponent<PlayerController>();

        if(playerController)
            playerController.SetPlayerClimbTarget(_topPosition.position.y);
    }
}
