using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveManager : MonoBehaviour
{
	public static int Wavenum;
	
	
	Text text;
	
	
	void Awake ()
	{
		text = GetComponent <Text> ();
		Wavenum = 0;
	}
	
	
	void Update ()
	{
		text.text = "Wave: " + Wavenum;
	}
}