using UnityEngine;

namespace InputTurntable{
	public class WrapUnityStandardInputEmpty:IInputSupplier{
		public bool anyKey=> false;
		public bool anyKeyDown => false;
		public Vector3 mousePosition => Vector3.zero;
		public Vector2 mouseScrollDelta => Vector2.zero;
		public float GetAxis(string axisName) => 0f;
		public float GetAxisRaw(string axisName) => 0f;
		public bool GetButton(string buttonName) => false;
		public bool GetButtonDown(string buttonName) => false;
		public bool GetButtonUp(string buttonName) => false;
		public string[] GetJoystickNames() => new string[0];
		public bool GetKey(string name) => false;
		public bool GetKey(KeyCode key) => false;
		public bool GetKeyDown(string name) => false;
		public bool GetKeyDown(KeyCode key) => false;
		public bool GetKeyUp(string name) => false;
		public bool GetKeyUp(KeyCode key) => false;
		public bool GetMouseButton(int button) => false;
		public bool GetMouseButtonDown(int button) => false;
		public bool GetMouseButtonUp(int button) => false;
		public Touch GetTouch(int index) => new Touch();
	}
}