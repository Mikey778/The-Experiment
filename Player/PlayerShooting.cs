using UnityEngine;


public class PlayerShooting : MonoBehaviour{
	
public int damagePerShot = 20;               
public float timeBetweenBullets = 0.15f;        
public float range = 100f;                     

float timer;                                    
Ray shootRay;                                   
RaycastHit shootHit;                            
int shootableMask;                              
ParticleSystem gunParticles;                    
LineRenderer gunLine;                           
AudioSource gunAudio;                          
Light gunLight;                                 
float effectsDisplayTime = 0.2f;                
float Ftime = 10f;
float Ptime = 10f;
bool israpid = false;
bool ispower = false;


	
void Awake (){

	// create a layer mask for Shootable
	shootableMask = LayerMask.GetMask ("Shootable");

	// Set up the references.
	gunParticles = GetComponent<ParticleSystem> ();
	gunLine = GetComponent <LineRenderer> ();
	gunAudio = GetComponent<AudioSource> ();
	gunLight = GetComponent<Light> ();

}//end Awake

void Update (){

	//keep track of time in sec.
	timer += Time.deltaTime;
	//one shot kill power up
	Power();
	//if ispower 

	if(ispower == true){

		//start decrementing Ptime
		Ptime -= Time.deltaTime;
	}//end if
	//fast shooting powerup
	fast ();
	//if israpid 

	if(israpid == true){

		//start decrementing Ftime
		Ftime -=Time.deltaTime;
	
	}//end if

	// If Fire1 is pressed and the time between 
	//shot is greater than timeBetweenBullets
	if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets){

		// Shoot!
		Shoot ();

	}//end if

	// if time is shorter than effects
	if(timer >= timeBetweenBullets * effectsDisplayTime){

		// disable effects
		DisableEffects ();
		
	}//end if 

}//end Update

public void DisableEffects (){

	// Disables Light and raycast line
	gunLine.enabled = false;
	gunLight.enabled = false;

}//end DisableEffects()

void Shoot (){

	// set timer to 0
	timer = 0f;

	// play shot audio
	gunAudio.Play ();

	// Enable the light.
	gunLight.enabled = true;

	// stop the currently playing particles
	// play the new particles so no overlaping
	//occurs
	gunParticles.Stop ();
	gunParticles.Play ();

	// Enable line renderer
	gunLine.enabled = true;
	//start the line at the end of the gun
	gunLine.SetPosition (0, transform.position);

	// shoot ray form the end of the barrel 
	//in the foward direction
	shootRay.origin = transform.position;
	shootRay.direction = transform.forward;

	// if raycast hits anything on the shootable layer
	if(Physics.Raycast (shootRay, out shootHit, range, shootableMask)){

		// find enemy health script
		EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();

		//if the component exists
		if(enemyHealth != null){

			//damage the enemy
			enemyHealth.TakeDamage (damagePerShot, shootHit.point);
	
		}// end if 

		// set the ending position of the line to the hit target
		gunLine.SetPosition (1, shootHit.point);
	}// end if
	//did not hit shootable layer
	else{

		//set the ending position of the line to range
		gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
	}//end else
	
}//end Shoot

//on trigger enter
void OnTriggerEnter(Collider other){

	//if gameobject is FastShooter
	if (other.gameObject.name == "FastShooter(Clone)") {
				
		//set israpid true and destroy powerup
		israpid = true;
		Destroy (other.gameObject);
	}//end if
	
	//if gameonject is 1Shot
	if (other.gameObject.name == "1Shot(Clone)") {
		//set is power true and destroy powerup
		ispower = true;
		Destroy (other.gameObject);
	}//end if

}//end on trigger enter


void fast(){

	// if is rapid is true
	if (israpid == true){

		//if you still have Ftime
		if (Ftime > 0 ){
		//decrease time between shots(faster shooting)
		timeBetweenBullets = .05f;


		}//end if
		else{
			//reset the timer Ftime, israpid, and 
			//timeBetweenBullets to default
			israpid = false;
			timeBetweenBullets = .15f;
			Ftime = 10f;
		}//end else

	}//end if
}//end fast()

void Power(){

	//if ispower is true
	if (ispower == true){

		//if you still have Ptime
		if (Ptime > 0 ){
		//increase damage
		damagePerShot = 1000;

		}//end if
		else{
			//no more Ptime
			//ispower = false
			//reset damage to default and reset Ptime
			ispower = false;
			damagePerShot  = 20;
			Ptime = 10f;
		}//end else



	}//end if
}//end power()

}//end class
															


