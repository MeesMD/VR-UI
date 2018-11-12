using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleBehavior : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private float lifeTime;

    [SerializeField]
    private Material[] materials;
    private Renderer rend;
    float distance;

	// Use this for initialization
	void Start () {
        rend = GetComponentInChildren<Renderer>();
        rend.material = materials[Random.Range(0,materials.Length)];

        Color c = rend.material.color;
        c.a = 0f;
        rend.material.color = c;

        StartCoroutine("FadeIn");
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(lifeTime);
        lifeTime -= Time.deltaTime;
        if (lifeTime > 0) {
            transform.Translate(-Vector3.up * speed * Time.deltaTime);
        } else {
            Destroy(gameObject);
        }
	}

    IEnumerator FadeIn() {
        for(float f = 0.05f; f <= 1; f += 0.05f) {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }


}
