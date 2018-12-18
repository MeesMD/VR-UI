using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

    GameObject selectedButton;
    Color blueColour = Color.blue;
    Color whiteColour = Color.white;

    public void ButtonClicked(GameObject button) {
        if (selectedButton == button) {
            var newButton = button.GetComponent<GUIButton>();
            newButton.TurnOff();
            if (newButton.Parent == null)
                selectedButton = null;
            else
                selectedButton = newButton.Parent.gameObject;

        }
        else {
            var newButton = button.GetComponent<GUIButton>();

            if (selectedButton != null) { 

                var sb = selectedButton.GetComponent<GUIButton>();

                bool ok = newButton.Parent == sb;

                if (sb.Parent == newButton.Parent) {
                    sb.TurnOff();
                }
                else {

                    var lButton = sb;
                    while (lButton.Parent != null && !ok) {
                        if (lButton == newButton.Parent) {
                            lButton.TurnOff();
                            break;
                        }

                        lButton.TurnOff();
                        lButton = lButton.Parent;
                    }

                    if (lButton.Parent == null && !ok) {
                        lButton.TurnOff();
                    }
                }
            }   

            if(selectedButton != null && selectedButton.GetComponent<GUIButton>().Root == newButton) {
                newButton.TurnOff();
                return;
            }

            newButton.TurnOn();
            selectedButton = button;


        }
    }
}
