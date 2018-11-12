using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMenuCreation : MonoBehaviour {

    [SerializeField]
    private GameObject[] content;
    [SerializeField]
    private float xDistance = 0;
    private bool isActive;
    private float DistContent = 2;

    // Update is called once per frame
    void Update() {
        if (gameObject.activeSelf && !isActive) {
            OpenInterface();
        }

        if (Input.GetKeyDown(KeyCode.Keypad0)) {
            CloseInterface();
        }
    }

    public void OpenInterface() {
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
        GameObject prefab = Instantiate(content[i], new Vector3(xDistance, (i * DistContent - ((content.Length - 1) * DistContent / 2)), 0), transform.rotation);
        prefab.transform.SetParent(transform, false);
        yield return null;
    }
}
