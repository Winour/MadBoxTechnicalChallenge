﻿using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ProcessObstacleBehaviour(other);
    }

    protected virtual void ProcessObstacleBehaviour(Collider other) { }
}
