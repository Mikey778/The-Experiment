using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour{

public int startingHealth = 100;
public int currentHealth;
public Slider healthSlider;
public Image damageImage;
public AudioClip deathClip;
public float flashSpeed = 5f;
public Color flashColor = new Color(1f, 0f, 0f, 0.1f);



Animator anim; 
AudioSource playerAudio;
PlayerMovement playerMovement;
PlayerShooting playerShooting;
bool isDead;
bool damaged;


void Awake (){

	//get components and set them to variables
	anim = GetComponent <Animator> ();
	playerAudio = GetComponent <AudioSource> ();
	playerMovement = GetComponent <PlayerMovement> ();
	playerShooting = GetComponentInChildren <PlayerShooting> ();

	//set current health = to starting health
	currentHealth = startingHealth;

}//end Awake()


void Update (){

	//if damaged = true flash damageImage
	if(damaged){

    	damageImage.color = flashColor;

	}//end if
	else{

		//change damageImage color to clear using Lerp for smooth transition
    	damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);

	}//end else

	//set damaged back to false
	damaged = false;

}//end Update


public void TakeDamage (int amount){

	//set damage = true
	damaged = true;
	//subtract from current health
	currentHealth -= amount;
	// set health slider value 
	healthSlider.value = currentHealth;
	//Play player hurt audio
	playerAudio.Play ();
	// if the players health is <= 0 and player not dead
	if(currentHealth <= 0 && !isDead){

	    //call Dead()
		Death ();
	}//end if
}//end TakeDamage


void Death (){

	//set isDead to true
	isDead = true;
	//disable shooting
	playerShooting.DisableEffects ();
	//start death animation
	anim.SetTrigger ("Die");
	//Play death audio clip
	playerAudio.clip = deathClip;
	playerAudio.Play ();
	//set player shooting and movement to false
	playerMovement.enabled = false;
	playerShooting.enabled = false;

}//end Death()
//this function is activated upon collision with 
//Healing powerup
public void AddHealth (int amount){

	//add heal amount to current health
	currentHealth += amount;
	//set slider to new current health
	healthSlider.value = currentHealth;
	//if the player is dead they stay dead
	if (currentHealth  <= 0) {
		currentHealth  = 0;
	}//end if 
	// if the players health is >=100 
	// set it to 100 so health cant increase past 100
	if (currentHealth  >= 100) {
		currentHealth  = 100;
	}// end if
}// end AddHealth()

public void RestartLevel (){

	//restart level
	Application.LoadLevel (Application.loadedLevel);
}//end RestartLevel()

}//end class
