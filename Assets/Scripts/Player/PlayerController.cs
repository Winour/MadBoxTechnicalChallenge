using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    private PlayerTapProcessor _playerTapProcessor;

    private Vector3 _initialPosition;
    private Quaternion _initialRotation;

    private bool _canPlay;

    private void Awake()
    {
        InitializePlayerMovement();

        InitializePlayerTapProcessor();

        SaveInitialTransform();

        _canPlay = true;
    }

    private void SaveInitialTransform()
    {
        _initialPosition = this.transform.position;
        _initialRotation = this.transform.rotation;
    }

    private void InitializePlayerMovement()
    {
        _playerMovement = new PlayerMovement();
        _playerMovement.Initialize(this.GetComponent<Rigidbody>(), this.transform, this.GetComponent<Animator>());
    }

    private void InitializePlayerTapProcessor()
    {
        _playerTapProcessor = new PlayerTapProcessor();
        _playerTapProcessor.Initialize();
    }

    private void OnDestroy()
    {
        _playerTapProcessor.Reset();
    }

    private void FixedUpdate()
    {
        if(!_canPlay)
            return;

        if(!_playerTapProcessor.IsTappingScreen)
        {
            _playerMovement.Stop();
            return;
        }

        _playerMovement.MoveAction();
    }

    public void SetPlayerRotationTarget(bool isLeftDirection)
    {
        _playerMovement.SetRotationTarget(isLeftDirection ? -this.transform.right : this.transform.right);
    }

    public void SetPlayerClimbTarget(float heightTarget)
    {
        _playerMovement.SetClimbTarget(heightTarget);
    }

    public void SetFinishState()
    {
        _canPlay = false;
        _playerMovement.SetFinishState();
        StartCoroutine(WaitToReplayIE());
    }

    private IEnumerator WaitToReplayIE()
    {
        yield return new WaitForSeconds(3f);
        ResetPlayer();
    }

    public void ResetPlayer()
    {
        ResetPlayerPosition();
        _playerMovement.ResetPlayer();
        _canPlay = true;
    }

    private void ResetPlayerPosition()
    {
        transform.position = _initialPosition;
        transform.rotation = _initialRotation;
    }
}
