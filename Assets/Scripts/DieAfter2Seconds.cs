using UnityEngine;
using System.Collections;

public class DieAfter2Seconds : MonoBehaviour {

	float startTime;

	// Use this for initialization
	void Start () {
	
	}

	void OnLevelWasLoaded(){
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - startTime > 2) {
			Application.LoadLevel("DeathScene");
		}
	}
}
