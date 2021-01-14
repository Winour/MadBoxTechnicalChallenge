using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerCollisionController _playerCollisionController;
    private PlayerMovement _playerMovement;

    private PlayerTapProcessor _playerTapProcessor;

    private void Awake()
    {
        _playerCollisionController = this.GetComponent<PlayerCollisionController>();
        if(!_playerCollisionController)
            _playerCollisionController = this.gameObject.AddComponent<PlayerCollisionController>();

        _playerMovement = new PlayerMovement();
        _playerMovement.Initialize(this.GetComponent<Rigidbody>());

        InitializePlayerTapProcessor();
    }

    private void InitializePlayerTapProcessor()
    {
        _playerTapProcessor = new PlayerTapProcessor();
        _playerTapProcessor.Initialize();

        //_playerTapProcessor.AddOnStartTappingUpAction(_playerMovement.);
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
}
