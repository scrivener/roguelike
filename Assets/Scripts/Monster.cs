using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Monster : MonoBehaviour {
	
	int health;
	public int maxHealth;
	public int power;  // Damage done on hit.
	Slider healthSlider;
	KillCounter killCounter;

	GameObject _player;

	ParticleSystem damagedParticle;

	private const float CHASE_PLAYER_PROBABILITY = 0.60f;


	// Use this for initialization
	void Start () {
		health = maxHealth;
		damagedParticle = GetComponentInChildren<ParticleSystem>();
		healthSlider = GetComponentInChildren<Slider>();
		killCounter = GameObject.FindGameObjectWithTag("Player").GetComponent<KillCounter>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private GameObject getPlayer() {
		if (_player == null) {
			_player = GameObject.FindGameObjectWithTag("Player");
		}
		return _player;
	}

	private Vector2 getChaseDirection(GameObject p) {
		if (p == null) {
			Debug.LogError("Couldn't find player in monster AI routine");
			return Vector2.up;
		}

		if (p.transform.position.x > transform.position.x) {
			return Vector2.right;
		} else if (p.transform.position.y > transform.position.y) {
			return Vector2.up;
		} else if (p.transform.position.x < transform.position.x) {
			return -Vector2.right;
		} else {
			return -Vector2.up;
		}
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
		killCounter.kills++;
		Destroy(gameObject);
	}
	public void tick() {
		Vector2 where;

		if (Random.value < CHASE_PLAYER_PROBABILITY) {
			where = getChaseDirection(getPlayer());
		} else {
			float randomDirectionChoice = Random.value;
			if (randomDirectionChoice < 0.25) {
				where = Vector2.up;
			} else if (randomDirectionChoice < 0.5) {
				where = -Vector2.up;
			} else if (randomDirectionChoice < 0.75) {
				where = Vector2.right;
			} else {
				where = -Vector2.right;
			}
		}
		int layerMask = (1 << LayerMask.NameToLayer("Enemy")) | 
			(1 << LayerMask.NameToLayer("Stairs")) |
				(1 << LayerMask.NameToLayer("Walls")) |
				(1 << LayerMask.NameToLayer("Player"));
		
		// Turn off our own collider to avoid raycast hitting ourself.
		// This is a hack, but really the whole raycast-to-find-things thing is a hack.
		BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
		if (collider != null) {
			collider.enabled = false;
			RaycastHit2D hit = Physics2D.Raycast(transform.position, where, 1f, layerMask);
			collider.enabled = true;
			if (!hit) {
				transform.position += (Vector3)where;
			} else {
				Debug.Log(hit.collider.tag);
			}
		}
		
		
		
	}
}

