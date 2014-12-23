using UnityEngine;
using System.Collections;

public class RoguelikeCharacterController : MonoBehaviour {

    public int damage = 12;

    // Use this for initialization
    void Start () {
    
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
        RaycastHit2D hit = Physics2D.Raycast (transform.position, where, 1f, 1 << LayerMask.NameToLayer ("Enemy"));
        if (!hit) {
            transform.position += where;
        } else {
            resolveHit(hit);
        }
    }

    void resolveHit(RaycastHit2D hit) {
		Monster m = hit.collider.GetComponentInParent<Monster>();
		if (m != null) {
			m.damage (damage);
		}
		Debug.Log (m.getHealth());
	}

}
