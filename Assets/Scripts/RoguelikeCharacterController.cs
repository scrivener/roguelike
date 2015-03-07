using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RoguelikeCharacterController : MonoBehaviour {

    public int power = 12;
    public GameObject healthBar;
    private Slider healthSlider;
    ParticleSystem damagedParticle;

    public GameObject MonsterController;
    MonsterManager monsterManager;

    public List<Item> inventory = new List<Item>();

    // Use this for initialization
    void Start () {
        healthSlider = healthBar.GetComponent<Slider>();
        damagedParticle = GetComponentInChildren<ParticleSystem>();
        monsterManager = MonsterController.GetComponent<MonsterManager>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown ("Up")) {
            moveCommand(Vector2.up);
        } else if (Input.GetButtonDown ("Down")) {
            moveCommand(-Vector2.up);
        } else if (Input.GetButtonDown ("Right")) {
            moveCommand(Vector2.right);
        } else if (Input.GetButtonDown ("Left")) {
            moveCommand(-Vector2.right);
        }

    }

    void moveCommand(Vector3 where) {
        RaycastHit2D hitEnemy = Physics2D.Raycast (transform.position, where, 1f, 1 << LayerMask.NameToLayer ("Enemy"));
        RaycastHit2D hitStairs = Physics2D.Raycast (transform.position, where, 1f, 1 << LayerMask.NameToLayer ("Stairs"));
		RaycastHit2D hitWall = Physics2D.Raycast (transform.position, where, 1f, 1 << LayerMask.NameToLayer ("Walls"));
        RaycastHit2D hitItem = Physics2D.Raycast (transform.position, where, 1f, 1 << LayerMask.NameToLayer ("Items"));
        if (!hitEnemy && !hitStairs && !hitWall && !hitItem) {
            transform.position += where;
            monsterManager.tick();
        } else if (hitEnemy) {
            resolveHit(hitEnemy);
            monsterManager.tick();
        } else if (hitStairs) {
            win();
        } else if (hitItem) {
            transform.position += where;
            Inventory.instance.inventory.Add(hitItem.collider.GetComponent<Item>());
            Debug.Log("Inventory length is now: " + inventory.Count);
            hitItem.collider.gameObject.SetActive(false);   
        } else {
            // Wat.
        }
    }

    void win() {
        Application.LoadLevel("VictoryScene");
    }

    public void damage(int amount) {
        int health = (int) healthSlider.value;
        health -= amount;
        healthSlider.value = health;
        if (damagedParticle != null) {
            damagedParticle.Play();
        }
        if (health <= 0) {
            Application.LoadLevel("DeathScene");
        }
        Debug.Log(health);  
    }

    void resolveHit(RaycastHit2D hit) {
		Monster m = hit.collider.GetComponentInParent<Monster>();
		if (m != null) {
			Debug.Log (Inventory.instance.getOffense());
			m.damage (this.power + Inventory.instance.getOffense());
            this.damage(m.power);
		}
		Debug.Log (m.getHealth());
	}

}
