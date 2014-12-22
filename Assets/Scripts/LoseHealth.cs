using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoseHealth : MonoBehaviour {

	private Slider healthSlider;

	// Use this for initialization
	void Start () {
		healthSlider = GetComponent<Slider> ();
	}
	
	// Update is called once per frame
	void Update () {
		bleedOut ();  // Lose health per frame, just to demonstrate moving to the death scene.
		if (healthSlider.value == 0) {
			Application.LoadLevel("DeathScene");
		}


	}

	void bleedOut () {
		int health = (int)healthSlider.value;
		if (health == 0) {
				return;
		}
		health -= 2;
		if (health < 0) {
				health = 0;
		}
		healthSlider.value = health;
	}
}
