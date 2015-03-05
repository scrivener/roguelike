using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterSheetMovement : MonoBehaviour {

    private Animator anim;
    bool sheetShown = false;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("ShowCharacterSheet")) {
            if (sheetShown) {
                slideOut();
                sheetShown = false;
            } else {
                slideIn();
                sheetShown = true;
            }
        }

	}

    void slideIn() {
        //enable the animator component
        anim.enabled = true;
        //play the Slidein animation
        anim.Play("CharacterSheetSlideIn");
        //        //freeze the timescale
        //        Time.timeScale = 0;
    }
    void slideOut() {
        //enable the animator component
        anim.enabled = true;
        //play the Slidein animation
        anim.Play("CharacterSheetSlideOut");
        //        //freeze the timescale
        //        Time.timeScale = 0;
    }
}
