using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

	int health;
	public int maxHealth;

    ParticleSystem damagedParticle;

	// Use this for initialization
	void Start () {
		health = maxHealth;
        damagedParticle = GetComponentInChildren<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public int getHealth() {
		return health;
	}
	public void damage(int damage) {
		health -= damage;
        if (damagedParticle != null) {
            damagedParticle.Play();
        }
        if (health <= 0) {
            die();
        }

	}
    void die() {
        Destroy(gameObject);
    }
}
