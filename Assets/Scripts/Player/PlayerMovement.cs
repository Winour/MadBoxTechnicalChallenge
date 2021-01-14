using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    private Rigidbody _rigidBody;
    private Transform _transform;
    private const float _runSpeed = 15f;

    private Quaternion _rotationTarget;
    private bool _hasToRotate;

    public void Initialize(Rigidbody rigidBody, Transform transform)
    {
        _rigidBody = rigidBody;
        _transform = transform;
    }

    public void Rotate()
    {
        _transform.rotation = Quaternion.RotateTowards(_transform.rotation, _rotationTarget, 360f * Time.fixedDeltaTime);
    }

    public void Climb()
    {
    }

    public void Move()
    {
        _rigidBody.velocity = _transform.forward * Mathf.Lerp(_rigidBody.velocity.magnitude, _runSpeed, 10f * Time.fixedDeltaTime);

        if(_hasToRotate)
            Rotate();
    }

    public void Stop()
    {
        if(_rigidBody.velocity != Vector3.zero)
            _rigidBody.velocity = Vector3.Lerp(_rigidBody.velocity, Vector3.zero, 15f * Time.fixedDeltaTime);
    }

    public void SetRotationTarget(Vector3 rotationTarget)
    {
        _hasToRotate = true;
        _rotationTarget = Quaternion.LookRotation(rotationTarget, _transform.up);
    }
}
