using UnityEngine;

namespace InputTurnout {
    public interface IInputSupplier{
        bool anyKey{ get; }
        bool anyKeyDown{ get; }
        Vector3 mousePosition{ get; }
        Vector2 mouseScrollDelta{ get; }
        float GetAxis (string axisName);
        float GetAxisRaw (string axisName);
        bool GetButton (string buttonName);
        bool GetButtonDown (string buttonName);
        bool GetButtonUp (string buttonName);
        string[] GetJoystickNames ();
        bool GetKey (string name);
        bool GetKey (KeyCode key);
        bool GetKeyDown (string name);
        bool GetKeyDown (KeyCode key);
        bool GetKeyUp (string name);
        bool GetKeyUp (KeyCode key);
        bool GetMouseButton (int button);
        bool GetMouseButtonDown (int button);
        bool GetMouseButtonUp (int button);
        Touch GetTouch (int index);
    }
}