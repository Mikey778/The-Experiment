using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {
//This script is designed to spawn powerups 
public Transform[] spawnpoint;
public GameObject[] powerup;
	
	
void Start(){
		//repeat invoke every 15 sec. 
		InvokeRepeating("SpawnObject", 0, 15);
}//end start()
	
void SpawnObject(){
		//pick a random powerup and a random 
		//postion in which to spawn the powerup
		int ranpos = Random.Range (0, 4);
		int ranenem = Random.Range (0, 4);

		//use random values to instantiate the random gameobject and positin to spawn
		Instantiate(powerup[ranenem], spawnpoint [ranpos].position, spawnpoint [ranpos].rotation);
}//end SpawnObject function

}// end class