using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour{

public static int score;

Text text;

void Awake () {
    //set reference
	text = GetComponent <Text> ();
	//score initialized
    score = 0;

}//end Awake


void Update (){
	//set score UI text
	text.text = "Score: " + score;
    
}//end Update

}//end class
