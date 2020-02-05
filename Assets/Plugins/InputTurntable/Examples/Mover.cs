using InputTurntable;
using UnityEngine;

namespace Examples{
    public class Mover : MonoBehaviour{
        [SerializeField] private float speed=1;

        private void Update(){
            if (InputTt.Input(this).GetKeyDown(KeyCode.W)){
                transform.position+=Vector3.up*speed;
            }
            
            if (InputTt.Input(this).GetKeyDown(KeyCode.A)){
                transform.position+=Vector3.left*speed;
            }
            
            if (InputTt.Input(this).GetKeyDown(KeyCode.S)){
                transform.position+=Vector3.down*speed;
            }
            
            if (InputTt.Input(this).GetKeyDown(KeyCode.D)){
                transform.position+=Vector3.right*speed;
            }
        }
    }
}
