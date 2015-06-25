using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

public void NextLevelButton(string levelName){

	Application.LoadLevel(levelName);

}//end playbutton

public void Quit(){
		Application.Quit ();
}//end Quit()

}//end mainmenu class
