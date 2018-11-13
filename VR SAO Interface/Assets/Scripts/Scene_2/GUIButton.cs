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

    private float cooldownPress = 1;
    private bool canPress;

    void Start() {
        audioSrc = GetComponent<AudioSource>();
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        canPress = true;
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.CompareTag("Hand") && canPress) {
            audioSrc.PlayOneShot(buttonSounds[0]);
            ChangeState();
            canPress = false;
            StartCoroutine("Cooldown");
        }
    }

    public void ChangeState() {
        state = !state;
        if (state) {
            spriteR.sprite = buttonStates[1];
            foreach (Transform child in this.transform)
                child.gameObject.SetActive(true);
        } else {
            spriteR.sprite = buttonStates[0];
            foreach (Transform child in this.transform)
                child.gameObject.SetActive(false);
        }
    }

    IEnumerator Cooldown() {
        yield return new WaitForSeconds(cooldownPress);
        canPress = true; ;
    }
}
