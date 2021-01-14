using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    private Rigidbody _rigidBody;
    private float _runSpeed;

    public void Initialize(Rigidbody rigidBody)
    {
        _rigidBody = rigidBody;
    }

    public void Rotate()
    {
    }

    public void Climb()
    {
    }

    public void Move()
    {
        _runSpeed = 15;
        _rigidBody.velocity = new Vector3(0, 0, Mathf.Lerp(_rigidBody.velocity.z, _runSpeed, 10f * Time.fixedDeltaTime));
    }

    public void Stop()
    {
        if(_rigidBody.velocity != Vector3.zero)
            _rigidBody.velocity = Vector3.Lerp(_rigidBody.velocity, Vector3.zero, 15f * Time.fixedDeltaTime);
    }
}
