using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechSpawn : MonoBehaviour {

    [SerializeField]
    GameObject[] circles;
    int number = -1;

	// Use this for initialization
	void Start () {
        SpawnObject();
    }


    void SpawnObject() {
        Invoke("MakeObject", 5f);
        Invoke("MakeObject", 5.2f);

        Invoke("MakeObject", 8f);
        Invoke("MakeObject", 8.2f);
        Invoke("MakeObject", 8.6f);
    }

    void MakeObject() {
        number++;
        GameObject prefab = Instantiate(circles[number], transform.position, Quaternion.identity);
        prefab.transform.SetParent(transform, false);
        int index = transform.GetSiblingIndex();
        prefab.transform.SetSiblingIndex(index - 1);
    }
}
