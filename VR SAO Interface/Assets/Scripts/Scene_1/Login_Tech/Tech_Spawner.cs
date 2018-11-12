using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tech_Spawner : MonoBehaviour {

    [SerializeField]
    GameObject techPrefab;
    [SerializeField]
    Vector3[] spawnPoints;
    int point = -1;

    // Use this for initialization
    void Start () {
        SpawnObject();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnObject() {
        Invoke("MakeObject", 5f);
        Invoke("MakeObject", 5.2f);

        Invoke("MakeObject", 7f);
        Invoke("MakeObject", 7.2f);
        Invoke("MakeObject", 7.6f);
    }


    void MakeObject() {
        point++;
        GameObject prefab = Instantiate(techPrefab, transform.position, transform.rotation);
        prefab.transform.SetParent(transform, false);
        prefab.transform.position = spawnPoints[point];
        int index = transform.GetSiblingIndex();
        prefab.transform.SetSiblingIndex(index - 1);

        TechBehavior script = prefab.GetComponent<TechBehavior>();
        script.StartCoroutine("GoToPoint", point);
    }
}
