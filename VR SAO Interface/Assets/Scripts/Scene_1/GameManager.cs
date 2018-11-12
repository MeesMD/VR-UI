using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    ScreenFade fadeIn;
    bool startFade;

    // Use this for initialization
    void Start () {
        fadeIn = GetComponent<ScreenFade>();
        fadeIn.StartCoroutine("CloseWindow");        
    }
	
	// Update is called once per frame
	void Update () {
        if ((TechAnimation.isDone == 5) && !startFade) {
            startFade = true;
            fadeIn.StartCoroutine("OpenWindow", 1f);
        }
    }
}
