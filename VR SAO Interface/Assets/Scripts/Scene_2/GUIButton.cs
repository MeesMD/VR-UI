using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIButton : MonoBehaviour {

    private SpriteRenderer spriteR;
    [SerializeField]
    private Sprite[] buttonStates;
    [SerializeField]
    private AudioClip[] buttonSounds;
    [SerializeField]
    private GameObject[] content;
    private AudioSource audioSrc;
    private bool state;
    private GameObject buttonManager;
    private ButtonManager scriptManager;

    private float cooldownPress = .5f;
    private bool canPress;
    public bool isActive;

    void Start() {
        audioSrc = GetComponent<AudioSource>();
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        buttonManager = GameObject.Find("Interface");
        scriptManager = buttonManager.GetComponent<ButtonManager>();
        canPress = true;
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.CompareTag("Hand") && canPress) {
            audioSrc.PlayOneShot(buttonSounds[0]);
            scriptManager.ButtonClicked(this.gameObject);
            canPress = false;
            StartCoroutine("Cooldown");
        }
    }

    public void TurnOn() {
        spriteR.sprite = buttonStates[1];
        for (int i = 0; i < content.Length; i++) {
            content[i].SetActive(true);
            isActive = true;
        }
    }

    public void TurnOff() {
        spriteR.sprite = buttonStates[0];
        for (int i = 0; i < content.Length; i++) {
            content[i].SetActive(false);
            isActive = false;
        }
    }

    IEnumerator Cooldown() {
        yield return new WaitForSeconds(cooldownPress);
        canPress = true; ;
    }
}
