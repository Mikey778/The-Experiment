using UnityEngine;
using System.Collections;

public class Pickupx: MonoBehaviour {
	

	public int amount;			//Amount to heal
	PlayerHealth playerHealth;	//Reference to Player health script
	GameObject player;			// Reference to the player.
	
	
void Awake (){

	//get references
	player = GameObject.FindGameObjectWithTag ("Player");
	playerHealth = player.GetComponent <PlayerHealth> ();
	
}//end Awake


//on trigger enter
void OnTriggerEnter (Collider other){

	//if other = player
	if (other.gameObject == player) {
		//call the AddHealth function from playerHealth script
		playerHealth.AddHealth (amount); 
		//Destroy this gameObject
		Destroy (gameObject);
	}//end if 
}//end void onTriggerEnter

}//end class