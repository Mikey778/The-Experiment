using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

public int amount;				
PlayerHealth playerHealth;		
GameObject player;				
		
		
void Awake (){
	//references
	player = GameObject.FindGameObjectWithTag ("Player");
	playerHealth = player.GetComponent <PlayerHealth> ();
}//end Awake
		
//on trigger enter
void OnTriggerEnter (Collider other){
	// if the gameObject is player access the 
	//playerHealth script and call function
	//Destroy the powerup
	if (other.gameObject == player) {
		playerHealth.AddHealth (amount); 
		Destroy (gameObject);
	}//end if gameObject = player
}//end on trigger enter
}// end main