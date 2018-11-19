using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

    GameObject selectedButton;
    GUIButton changeState;
    Color blueColour = Color.blue;
    Color whiteColour = Color.white;

    public void ButtonClicked(GameObject button) {
        if (selectedButton == button) {
            button.GetComponent<GUIButton>().TurnOff();
            selectedButton = null;
        }
        else {
            if (selectedButton != null)
                selectedButton.GetComponent<GUIButton>().TurnOff();
            button.GetComponent<GUIButton>().TurnOn();
            selectedButton = button;
        }
    }
}
