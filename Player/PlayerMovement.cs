using UnityEngine;

public class PlayerMovement : MonoBehaviour{

public float speed = 6f;
float timer;
Vector3 movement;
Animator anim;
Rigidbody playerRigidbody;
int floorMask;
float camRaytLength = 100f;
float Stime = 15f;
bool isfast = false;

void Awake(){

	//getMask Floor
	//get animator component 
	//get rigidybody component
	floorMask = LayerMask.GetMask ("Floor");
	anim = GetComponent <Animator> ();
	playerRigidbody = GetComponent<Rigidbody> ();

}//end Awake

void FixedUpdate(){

	// get the input Axis this will return a 1, -1 or 0
	float h = Input.GetAxisRaw ("Horizontal");
	float v = Input.GetAxisRaw ("Vertical");

	//keeps time in sec.
	timer += Time.deltaTime;
	//speed increase power up function
	//checks to see if isfast is true and 
	//sets isfast to false when Stime <=0
	flash ();
	//if the player isfast
	if(isfast == true){

		//decrease Stime(15sec)
		Stime -= Time.deltaTime;
	}//end if 

	Move (h, v);

	Turning ();

	Animating(h,v);

}//end Fixed Update

void Move (float h, float v){

	//set movement to current vector3
	movement.Set (h, 0f, v);
	//normalization keeps the same direction and make it proportional to speed/sec
	movement = movement.normalized * speed * Time.deltaTime;
	//Move the player to current position
	playerRigidbody.MovePosition (transform.position + movement);
}//end Move

void Turning(){

	//Create a ray form the mouse on the screen to the direction of the camera
	Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
	//var to store information about what
	//was hit
	RaycastHit floorHit;
	//if the raycast hits something on the floor layer
	if (Physics.Raycast (camRay, out floorHit, camRaytLength, floorMask)) {
		//Create vector from the player to the mouse cursor
		Vector3 playerToMouse = floorHit.point - transform.position;
		playerToMouse.y = 0f;
		//Create a rotation from the vector 3 to mouse click
		Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
		//rotate the player
		playerRigidbody.MoveRotation (newRotation);

	}//end if 
}//end Turning()

void Animating(float h, float v){

	// set walking to true if input axis !=0
	bool walking = h != 0f || v != 0f;
	anim.SetBool ("IsWalking", walking);

}//end Animating

// on trigger enter 
void OnTriggerEnter(Collider other){

	//if the gameObject named 
	//Speed(Clone) enters the collider
	if (other.gameObject.name == "Speed(Clone)") {
		//set isfast
		//Destroy the Speed object
		isfast = true;
		Destroy (other.gameObject);

	}//end if 

}//end on trigger enter

void flash(){

	if (isfast == true){

		//if you still got Stime
		if (Stime > 0 ){
			//increase speed
			speed = 12f;

		}//end if 
		else{
			//else no more Stime 
			//set speed back to 6 and 
			//set Stime back to 15
			isfast = false;
			speed = 6;
			Stime = 15f;
		}//end else

	}//end if 
}//end flash()

}//end class


