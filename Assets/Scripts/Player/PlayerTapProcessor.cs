using System;
using UnityEngine.Events;

public class PlayerTapProcessor
{
    public bool IsTappingScreen { private set; get; }

    private UnityEvent _onStartTappingDown;
    private UnityEvent _onStartTappingUp;

    public void Initialize()
    {
        InputManager.onScreenTapDown += ProcessTapDown;
        InputManager.onScreenTapUp += ProcessTapUp;
    }

    public void Reset()
    {
        InputManager.onScreenTapDown -= ProcessTapDown;
        InputManager.onScreenTapUp -= ProcessTapUp;

        if(_onStartTappingDown != null)
            _onStartTappingDown.RemoveAllListeners();

        if(_onStartTappingUp != null)
            _onStartTappingUp.RemoveAllListeners();
    }

    public void AddOnStartTappingDownAction(UnityAction unityAction)
    {
        _onStartTappingDown.AddListener(unityAction);
    }

    public void AddOnStartTappingUpAction(UnityAction unityAction)
    {
        _onStartTappingUp.AddListener(unityAction);
    }

    public void RemoveOnStartTappingDownAction(UnityAction unityAction)
    {
        _onStartTappingDown.RemoveListener(unityAction);
    }

    public void RemoveOnStartTappingUpAction(UnityAction unityAction)
    {
        _onStartTappingUp.RemoveListener(unityAction);
    }

    private void ProcessTapDown()
    {
        IsTappingScreen = true;
        _onStartTappingDown?.Invoke();
    }

    private void ProcessTapUp()
    {
        IsTappingScreen = false;
        _onStartTappingUp?.Invoke();
    }
}
