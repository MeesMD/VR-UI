using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TechAnimation : MonoBehaviour {

    Animation anim;
    [SerializeField]
    AnimationClip[] animations;
    [SerializeField]
    private GameObject OK;

    private Image spriteR;
    [SerializeField]
    Image[] oldSprites;
    [SerializeField]
    Sprite[] newSprites;
    [SerializeField]
    AudioClip[] clips;
    [SerializeField]
    AudioSource audioSrc;

    [SerializeField]
    int side;

    public static int isDone;
    bool useOnce;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animation>();
        anim.clip = animations[0];
        anim.Play();
        audioSrc.PlayOneShot(clips[0], 1F);
        audioSrc = GetComponent<AudioSource>();
    }

    void Update() {
        if(isDone == 5) {
            Ending();
        }
    }

    public void changeText() {
        OK.SetActive(true);
        audioSrc.PlayOneShot(clips[2], 1F);
    }

    public void GoToPos() {
        anim.clip = animations[1];
        anim.Play();
        audioSrc.PlayOneShot(clips[1], 1F);
    }

    public void CheckEnding() {
        isDone++;
    }

    void Ending() {
        transform.position += new Vector3(side,0,0) * Time.deltaTime * 100;
        transform.rotation = GameObject.FindGameObjectWithTag("MainCamera").transform.rotation;
        Destroy(gameObject, 1f);
        if (!useOnce) {
            for (int i = 0; i < 3; i++) {
                oldSprites[i].sprite = newSprites[i];
            }
            audioSrc.PlayOneShot(clips[3], 1F);
            useOnce = true;
        }

    }


}
