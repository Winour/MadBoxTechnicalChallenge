using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingObstacle : Obstacle
{
    protected override void ProcessObstacleBehaviour(Collider other)
    {
        base.ProcessObstacleBehaviour(other);
        PlayerController playerController = other.GetComponent<PlayerController>();

        if(playerController)
            playerController.ResetPlayer();
    }
}
