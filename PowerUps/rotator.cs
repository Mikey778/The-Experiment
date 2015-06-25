using UnityEngine;
using System.Collections;

public class rotator : MonoBehaviour {
//simple script doesnt to give the powerups a active rotation
//update is called once per frame
void Update(){

		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	
	}//end Update

}//end class
