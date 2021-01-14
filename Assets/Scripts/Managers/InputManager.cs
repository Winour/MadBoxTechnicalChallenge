using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public delegate void ScreenTap();
    public static event ScreenTap onScreenTapDown;
    public static event ScreenTap onScreenTapUp;

    private bool _isPressingScreen;

    void Update()
    {
        if(GetPressScreenDown() && !IsOverUI())
            onScreenTapDown?.Invoke();

        if(GetPressScreenUp())
            onScreenTapUp?.Invoke();
    }

    private bool GetPressScreenDown()
    {
        if(_isPressingScreen)
            return false;

#if UNITY_EDITOR
        if(!Input.GetMouseButtonDown(0))
            return false;
#else
        if(Input.touchCount == 0 || Input.touches[0].phase != TouchPhase.Began)
            return false;
#endif
        _isPressingScreen = true;
        return true;
    }

    private bool GetPressScreenUp()
    {
        if(!_isPressingScreen)
            return false;

#if UNITY_EDITOR
        if(!Input.GetMouseButtonUp(0))
            return false;
#else
        if(Input.touchCount == 0 || Input.touches[0].phase != TouchPhase.Ended)
            return false;
#endif
        _isPressingScreen = false;
        return true;
    }

    private bool IsOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
