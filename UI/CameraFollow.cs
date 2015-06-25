using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour{
//This script will develop a camera movement system.  
public Transform player;          
public float smoothing = 5f;       

Vector3 offset;                    
	
void Start ()
{
	//set the offset of the camera by subtracting
	//cameras current location from the players current position
	offset = transform.position - player.position;
}//end Start
void FixedUpdate ()
{
	// This handles the camera movement using Lerp to smooth the movement.
	Vector3 targetCamPos = player.position + offset;
	transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);

}//end FixedUpdate

}//end class
