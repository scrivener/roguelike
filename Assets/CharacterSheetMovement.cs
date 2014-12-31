using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterSheetMovement : MonoBehaviour {

    CanvasGroup canvasGroup;
    float increment = -0.01f;
    private Animator anim;
    bool sheetShown = false;

	// Use this for initialization
	void Start () {
        canvasGroup = GetComponent<CanvasGroup>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
//        if (canvasGroup != null) {
//            canvasGroup.alpha = canvasGroup.alpha + increment;  
//            if (canvasGroup.alpha <= 0 || canvasGroup.alpha >= 1) {
//                increment *= -1;
//            }
//        }
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
