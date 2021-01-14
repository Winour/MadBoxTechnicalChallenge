using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    private Rigidbody _rigidBody;
    private Transform _transform;
    private Animator _animator;

    private const float _runSpeed = 15f;

    private bool _hasToRotate;
    private const float _rotationSpeed = 360f;
    private Quaternion _rotationTarget;

    private bool _hasToClimb;
    private bool _isClimbing;
    private bool _isInClimbTransition;
    private const float _climbSpeed = 15f;
    private float _climbHeightTarget;

    private bool IsHorizontallyMoving => _rigidBody.velocity.x != 0 || _rigidBody.velocity.z != 0;
    private bool IsVerticallyMoving => _rigidBody.velocity.y != 0;

    public void Initialize(Rigidbody rigidBody, Transform transform, Animator animator)
    {
        _rigidBody = rigidBody;
        _transform = transform;
        _animator = animator;
    }

    public void Rotate()
    {
        _transform.rotation = Quaternion.RotateTowards(_transform.rotation, _rotationTarget, _rotationSpeed * Time.fixedDeltaTime);
    }

    public void Climb()
    {
        if(!_isClimbing)
        {
            if(!_isInClimbTransition)
                CoroutineHandler.Instance.StartCoroutine(ClimbTransitionInIE());
            return;
        }

        if(HasClimbedToTheTop())
        {
            CoroutineHandler.Instance.StartCoroutine(ClimbTransitionOutIE());
            return;
        }

        _rigidBody.velocity = _transform.up * Mathf.Lerp(_rigidBody.velocity.magnitude, _climbSpeed, 10f * Time.fixedDeltaTime);
    }

    private IEnumerator ClimbTransitionInIE()
    {
        _isInClimbTransition = true;

        Stop(false);
        yield return new WaitForSeconds(0.75f);

        _isClimbing = true;
        _isInClimbTransition = false;
    }

    private IEnumerator ClimbTransitionOutIE()
    {
        _isInClimbTransition = true;

        Stop(false);
        yield return new WaitForSeconds(0.75f);

        _isClimbing = false;
        _hasToClimb = false;
        _isInClimbTransition = false;
    }

    private bool HasClimbedToTheTop()
    {
        return _climbHeightTarget < _transform.position.y;
    }

    public void MoveAction()
    {
        if(_hasToRotate)
            Rotate();

        if(_hasToClimb)
        {
            Climb();
            return;
        }
     
        Move();
    }

    private void Move()
    {
        _animator.SetBool("IsRunning", true);
        _rigidBody.velocity = _transform.forward * Mathf.Lerp(_rigidBody.velocity.magnitude, _runSpeed, 10f * Time.fixedDeltaTime);
    }

    public void Stop(bool smoothly = true)
    {
        _animator.SetBool("IsRunning", false);

        if(_rigidBody.velocity == Vector3.zero)
            return;

        if(smoothly)
            _rigidBody.velocity = Vector3.Lerp(_rigidBody.velocity, Vector3.zero, 15f * Time.fixedDeltaTime);
        else
            _rigidBody.velocity = Vector3.zero;
    }

    public void SetRotationTarget(Vector3 rotationTarget)
    {
        _hasToRotate = true;
        _rotationTarget = Quaternion.LookRotation(rotationTarget, _transform.up);
    }

    public void SetClimbTarget(float heightTarget)
    {
        _hasToClimb = true;
        _climbHeightTarget = heightTarget;
    }
}
