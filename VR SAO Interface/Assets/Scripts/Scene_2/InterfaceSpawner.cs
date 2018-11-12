using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] content;
    private bool isActive;
    private float DistContent = 3;
    private float contentSpeed = 4;
    private float waitTime = 1;

    private AudioSource audioSrc;

    void Start() {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("space") && !isActive) {
            OpenInterface();
        }

        if (Input.GetKeyDown("escape")) {
            CloseInterface();
        }
    }

    public void OpenInterface() {
        audioSrc.PlayOneShot(audioSrc.clip);
        for (int i = 0; i < content.Length; i++) {
            StartCoroutine("SpawnContent", i);
            isActive = true;
        }
    }

    public void CloseInterface() {
        Debug.Log("close");
        foreach (Transform child in this.transform)
            Destroy(child.gameObject);
        isActive = false;
    }


    IEnumerator SpawnContent(int i) {
        GameObject prefab = Instantiate(content[i], transform.position + new Vector3(0, (((content.Length - 1) * DistContent / 2) + 5), 0), transform.rotation);
        prefab.transform.SetParent(transform, false);

        float elapsedTime = 0;
        while (elapsedTime < contentSpeed) {
            prefab.transform.position = Vector3.Lerp(prefab.transform.position, transform.position - new Vector3(0,(i* DistContent - ((content.Length - 1) * DistContent / 2)),0), (elapsedTime / contentSpeed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
}