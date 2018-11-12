using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tech_Rotate : MonoBehaviour {

    [SerializeField]
    private GameObject[] circles;
    [SerializeField]
    private float rotateSpeed;
     
	
	// Update is called once per frame
	void Update () {
		circles[0].transform.Rotate(0,0, rotateSpeed * Time.deltaTime, Space.Self);
        circles[1].transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime, Space.Self);
        circles[2].transform.Rotate(0, 0, rotateSpeed * Time.deltaTime, Space.Self);
    }
}
