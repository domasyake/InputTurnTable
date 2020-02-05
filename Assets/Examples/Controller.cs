using InputTurntable;
using UnityEngine;
using UnityEngine.UI;

namespace Examples{
	public class Controller : MonoBehaviour{
		[SerializeField] private Mover red;
		[SerializeField] private Toggle redToggle;
		[SerializeField] private Mover green;
		[SerializeField] private Toggle greenToggle;

		private void Start(){
			InputTt.ChangeReceiver(red);
			redToggle.isOn = true;
			greenToggle.isOn = false;
			
			redToggle.onValueChanged.AddListener((n)=>{
				if (n){
					InputTt.ChangeReceiver(red);
					greenToggle.isOn = false;
				}else{
					InputTt.ChangeReceiver(green);
					greenToggle.isOn = true;
				}});
			greenToggle.onValueChanged.AddListener((n) => {
				if (n){
					redToggle.isOn = false;
				}else{
					redToggle.isOn = true;
				}
			});
		}
	}
}