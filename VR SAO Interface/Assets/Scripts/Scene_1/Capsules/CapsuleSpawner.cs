using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleSpawner : MonoBehaviour {

    [SerializeField]
    private float boxWidth;
    [SerializeField]
    private GameObject Capsule;
    [SerializeField]
    private GameObject Camera;
    [SerializeField]
    private float distanceFromCam;

    [SerializeField]
    private float timer;

    // Update is called once per frame
    void Update() {
        if (timer > -1) {
            Timer();
        }
    }

    void Timer() {
        boxWidth -= 5 * Time.deltaTime;
        timer -= Time.deltaTime;
        for (int i = 0; i < 4; i++) {
            Spawn();
        }
    }

    void Spawn() {
        Vector3 randomPosWithin;
        randomPosWithin = new Vector3(Random.Range(-boxWidth, boxWidth), distanceFromCam, Random.Range(-boxWidth, boxWidth));
        randomPosWithin = transform.TransformPoint(randomPosWithin * .5f);
        GameObject capsule = Instantiate(Capsule, randomPosWithin, transform.rotation);
        capsule.transform.parent = gameObject.transform;
        var cpos = capsule.transform.position;
        if ((cpos.x < 1 && cpos.x > -1) || (cpos.z < 1 && cpos.z > -1)) {
            Destroy(capsule.gameObject);
        }
    }
}
