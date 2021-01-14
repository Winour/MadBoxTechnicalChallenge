using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerCollisionController _playerCollisionController;
    private PlayerMovement _playerMovement;

    private PlayerTapProcessor _playerTapProcessor;

    private void Awake()
    {
        InitializePlayerCollisionController();

        InitializePlayerMovement();

        InitializePlayerTapProcessor();
    }

    private void InitializePlayerCollisionController()
    {        
        _playerCollisionController = this.GetComponent<PlayerCollisionController>();
        if(!_playerCollisionController)
            _playerCollisionController = this.gameObject.AddComponent<PlayerCollisionController>();
    }

    private void InitializePlayerMovement()
    {
        _playerMovement = new PlayerMovement();
        _playerMovement.Initialize(this.GetComponent<Rigidbody>(), this.transform);
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
        if(!_playerTapProcessor.IsTappingScreen)
        {
            _playerMovement.Stop();
            return;
        }

        _playerMovement.Move();
    }

    public void SetPlayerRotationTarget(bool isLeftDirection)
    {

        _playerMovement.SetRotationTarget(isLeftDirection ? -this.transform.right : this.transform.right);
    }
}
