using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

	int health;
	public int maxHealth;

	// Use this for initialization
	void Start () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int getHealth() {
		return health;
	}
	public void damage(int damage) {
		health -= damage;
	}
}
