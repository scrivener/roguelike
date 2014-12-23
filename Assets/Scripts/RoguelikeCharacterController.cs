using UnityEngine;
using System.Collections;

public class RoguelikeCharacterController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Up")) {
			moveCommand(new Vector3(0, 1, 0));
		} else if (Input.GetButtonDown ("Down")) {
			moveCommand(new Vector3(0, -1, 0));
		} else if (Input.GetButtonDown ("Right")) {
			moveCommand(new Vector3(1, 0, 0));
		} else if (Input.GetButtonDown ("Left")) {
			moveCommand(new Vector3(-1, 0, 0));
		}
	}

	void moveCommand(Vector3 where) {
		transform.position += where;
	}
}
