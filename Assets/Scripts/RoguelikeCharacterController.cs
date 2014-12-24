using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoguelikeCharacterController : MonoBehaviour {

    public int power = 12;
    public GameObject healthBar;
    private Slider healthSlider;
    ParticleSystem damagedParticle;


    
    // Use this for initialization
    void Start () {
        healthSlider = healthBar.GetComponent<Slider>();
        damagedParticle = GetComponentInChildren<ParticleSystem>();

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
        if (!hitEnemy && !hitStairs) {
            transform.position += where;
        } else if (hitEnemy) {
            resolveHit(hitEnemy);
        } else if (hitStairs) {
            win();
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
			m.damage (this.power);
            this.damage(m.power);
		}
		Debug.Log (m.getHealth());
	}

}
