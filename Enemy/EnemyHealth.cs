using UnityEngine;

public class EnemyHealth : MonoBehaviour{

public int startingHealth = 100;
public int currentHealth;
public float sinkSpeed = 2.5f;
public int scoreValue = 10;
public AudioClip deathClip;

Animator anim;
AudioSource enemyAudio;
ParticleSystem hitParticles;
CapsuleCollider capsuleCollider;
bool isDead;
bool isSinking;


void Awake (){
        
		//get components 
		anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();
		//initialize currentHealth
        currentHealth = startingHealth;
}//end Awake


void Update (){
        
		// if isSinking then start sinking
		if(isSinking){
            
			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        
		}//end if
}//end Update

// TakeDamage function
public void TakeDamage (int amount, Vector3 hitPoint)
{
	// is enemy dead?
	if(isDead)
		//if is dead return
		return;
	//play hurt audio clip
	enemyAudio.Play ();
		//decrease current health
	currentHealth -= amount;
	//call the particle effects at hitPoint
	//and play the animation.
	hitParticles.transform.position = hitPoint;
	hitParticles.Play();
		//if the enemy/gameobject currenthealth <= 0
		//call death()
	if(currentHealth <= 0){
	    Death ();
	}//end if 
}// end TakeDamage()


void Death (){

	//set isDead to true
	isDead = true;
	//set Trigger to true
	capsuleCollider.isTrigger = true;
	//Set animation Trigger to Dead
	//this will activate death animation
	anim.SetTrigger ("Dead");
	//play the Death Audio file
	enemyAudio.clip = deathClip;
	enemyAudio.Play ();

}//end Death()


public void StartSinking (){

	//set nav agent to false to stop movment and sink
	//set isKinematic = true this will allow the 
	//enemy to fall through the floor
	GetComponent <NavMeshAgent> ().enabled = false;
	GetComponent <Rigidbody> ().isKinematic = true;
	isSinking = true;
	//update score
	ScoreManager.score += scoreValue;
	//update enemy count
	WaveScript.enemycount--;
	Debug.Log ("Minus");
	//destroy game object after 2 sec. 
	Destroy (gameObject, 2f);

}//end StartSinking

}//end class
