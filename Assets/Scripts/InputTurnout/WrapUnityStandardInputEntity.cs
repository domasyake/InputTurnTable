using UnityEngine;

namespace InputTurnout{
	public class WrapUnityStandardInputEntity:IInputSupplier{
		public bool anyKey => Input.anyKey;
		public bool anyKeyDown => Input.anyKeyDown;
		public Vector3 mousePosition => Input.mousePosition;
		public Vector2 mouseScrollDelta => Input.mouseScrollDelta;
		public float GetAxis(string axisName) => Input.GetAxis(axisName);
		public float GetAxisRaw(string axisName) => Input.GetAxisRaw(axisName);
		public bool GetButton(string buttonName) => Input.GetButton(buttonName);
		public bool GetButtonDown(string buttonName) => Input.GetButtonDown(buttonName);
		public bool GetButtonUp(string buttonName) => Input.GetButtonUp(buttonName);
		public string[] GetJoystickNames() => Input.GetJoystickNames();
		public bool GetKey(string name) => Input.GetKey(name);
		public bool GetKey(KeyCode key) => Input.GetKey(key);
		public bool GetKeyDown(string name) => Input.GetKeyDown(name);
		public bool GetKeyDown(KeyCode key) => Input.GetKeyDown(key);
		public bool GetKeyUp(string name) => Input.GetKeyUp(name);
		public bool GetKeyUp(KeyCode key) => Input.GetKeyUp(key);
		public bool GetMouseButton(int button) => Input.GetMouseButton(button);
		public bool GetMouseButtonDown(int button) => Input.GetMouseButtonDown(button);
		public bool GetMouseButtonUp(int button) => Input.GetMouseButtonUp(button);
		public Touch GetTouch(int index) => Input.GetTouch(index);
	}
}