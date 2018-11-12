using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIButton : MonoBehaviour {

    private SpriteRenderer spriteR;
    [SerializeField]
    private Sprite[] buttonStates;
    [SerializeField]
    private AudioClip[] buttonSounds;
    private AudioSource audioSrc;
    private bool state;

    // Use this for initialization
    void Start() {
        audioSrc = GetComponent<AudioSource>();
        spriteR = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.CompareTag("Hand")) {
            audioSrc.PlayOneShot(buttonSounds[0]);
            ChangeState();
        }
    }

    public void ChangeState() {
        state = !state;
        if (state) {
            spriteR.sprite = buttonStates[1];
        } else {
            spriteR.sprite = buttonStates[0];
        }
    }
}
