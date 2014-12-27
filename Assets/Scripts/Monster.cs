using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Monster : MonoBehaviour {

	int health;
	public int maxHealth;
    public int power;  // Damage done on hit.
	Slider healthSlider;

    ParticleSystem damagedParticle;

	// Use this for initialization
	void Start () {
		health = maxHealth;
        damagedParticle = GetComponentInChildren<ParticleSystem>();
		healthSlider = GetComponentInChildren<Slider>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public int getHealth() {
		return health;
	}
	public void damage(int damage) {
		health -= damage;
		healthSlider.value = health;
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
