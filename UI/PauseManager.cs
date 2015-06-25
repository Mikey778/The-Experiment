using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour {
	
Canvas canvas;


void Start(){
	
	//set time scale
	Time.timeScale = 1;
	//get Canvas reference
	//set pause canvas to false
	canvas = GetComponent<Canvas>();
	canvas.enabled = false;

}//end Start

void Update(){

	//if user pushes esc
	if (Input.GetKeyDown(KeyCode.Escape)){

		//pause function
		Pause();

	}//end if
}// end Update

public void Pause(){
	
	//canvas enabled if disabled 
	//canvas disabled if enabled
	canvas.enabled = !canvas.enabled;
	//if timescale == 0 then set to 1 
	//else set to 0
	Time.timeScale = Time.timeScale == 0 ? 1 : 0;
}//end pause

//Quit
public void Quit(){
	
	//exit the application
	#if UNITY_EDITOR 
	EditorApplication.isPlaying = false;
	#else 
	Application.Quit();
	#endif
}//end quit

public void Menu(string levelName){

	//set the canvas to false
	canvas = GetComponent <Canvas>();
	canvas.enabled = false;
	//load mainmenu
	Application.LoadLevel(levelName);
}//end Menu

}//end class