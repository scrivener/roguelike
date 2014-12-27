using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayPower : MonoBehaviour {

    public GameObject player;
    RoguelikeCharacterController controller;
    Text powerText;

	// Use this for initialization
	void Start () {
        controller = player.GetComponent<RoguelikeCharacterController>();
        powerText = GetComponentInChildren<Text>();
        powerText.text = controller.power.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
