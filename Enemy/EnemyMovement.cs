using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour{

Transform player;
PlayerHealth playerHealth;
EnemyHealth enemyHealth;
NavMeshAgent nav;


void Awake (){
       
		//find Player GameObject position
		player = GameObject.FindGameObjectWithTag ("Player").transform;
        //get the script PlayerHealth form the player gameobject
		playerHealth = player.GetComponent <PlayerHealth> ();
        //get the enemies current health from the EnemyHealth script
		enemyHealth = GetComponent <EnemyHealth> ();
        //get the navmeshagent component and save it under nav variable
		nav = GetComponent <NavMeshAgent> ();

}//end Awake

//Update() is called every frame
void Update (){
	//if the enemy still has health and the player still has health
	if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0){
    		//move to the player
			nav.SetDestination (player.position);
	}//end if
	else{
    	//then player is dead or enemy is dead 
		//disable the nav mesh meaning the enemy cannot move.
		nav.enabled = false;
	}//end else
}//end Update

}//end class
