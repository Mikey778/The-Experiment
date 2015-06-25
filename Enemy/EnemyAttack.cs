using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour{

public float timeBetweenAttacks = 0.5f;
public int attackDamage = 10;
bool canAttk;
Animator anim;
GameObject player;
PlayerHealth playerHealth;
EnemyHealth enemyHealth;
bool playerInRange;
float timer;


void Awake (){

        //set the player variable with tag
		player = GameObject.FindGameObjectWithTag ("Player");
        //access the script component on player and
		//get the script "Playerhealth"
		playerHealth = player.GetComponent <PlayerHealth> ();
        //get the script off of this gameobject and animator
		enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();

}//end Awake

// when entering the Collider
void OnTriggerEnter (Collider other){

	//if the player is detected in the collider
	if(other.gameObject == player){

    	//set playerInRange = true
		playerInRange = true;

	}//end if 
}//end ontriggerenter()

//when exiting the Collider
void OnTriggerExit (Collider other){

	//if the player is detected exiting the collider
	if(other.gameObject == player){

    //player in range = false
	playerInRange = false;


	}//end if 
}//end ontriggerexit()


void Update ()
{
	//create a timer variable that will keep
	//track of time for Attack()
	timer += Time.deltaTime;
	//if the time between attacks has passed and the player is in range
	//and the enemy is alive then Attack()
	if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0){

    	Attack ();

	}//end if
	
	//if the player is dead
	if(playerHealth.currentHealth <= 0){

   		//set the animator trigger to "PlayerDead"
		anim.SetTrigger ("PlayerDead");

	}//end if
	
	//call animating function
	Animating ();
}//end Update


void Attack (){

	timer = 0f;

	if(playerHealth.currentHealth > 0){

    	playerHealth.TakeDamage (attackDamage);

	}//end if 

}//end attack()

void Animating(){

	//if the player is in range and the enemy still has health
	//set the animator Attack to true starting the animation
	bool Attack = playerInRange && enemyHealth.currentHealth > 0;
	anim.SetBool ("Attack", Attack);

}//end Animating

}//end class
