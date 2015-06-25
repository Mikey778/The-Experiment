using UnityEngine;
using System.Collections;

public class WaveScript : MonoBehaviour{

public static int enemycount;
public PlayerHealth playerHealth;
public GameObject[] enemy;
public int EnemyCount;
public float spawnWait;
public float startWait;
public float waveWait;
public Transform[] spawnpoint;
bool spawn;

void Awake (){
	
	//initialize variables
	enemycount = 0;
	WaveManager.Wavenum = 0;

}//end Awake

void Update(){
	
	// if there is no enemies
	if (enemycount <= 0) {
		
		spawn = true;

	}//end if 
	else {
		
		spawn = false;
	
	}//end else
	
	//SpawnWaves
	StartCoroutine (SpawnWaves ()); 
}//end Update

IEnumerator SpawnWaves (){
	//wait for startWait time before spawning the first wave.
	yield return new WaitForSeconds (startWait);

	//while spawn is true
	while (spawn) {

			// forloop that runs until i > enemycount
			for (int i = 0; i < EnemyCount; i++) {

				//pick random enemy and random position to spawn
				int ranpos = Random.Range (0, 3);
				int ranenem = Random.Range (0, 3);

				//Spawn random enemy at random point 
				Instantiate (enemy [ranenem], spawnpoint [ranpos].position, spawnpoint [ranpos].rotation);
				//increase enemycount for each enemy spawned
				enemycount++;
				//time between waves
				yield return new WaitForSeconds (spawnWait);

			}//end forloop
				//after each wave increment Wavenum
				++WaveManager.Wavenum;
				//Add 1 more enemy to be spawned for next wave
				EnemyCount++;
			
	}//end while		
					
} // end Spawnwaves method

}//end class