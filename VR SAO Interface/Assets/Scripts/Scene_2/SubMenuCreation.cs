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

    void OnEnable(){
        OpenInterface();
    }

    void OnDisable() {
        CloseInterface();
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
        GameObject prefab = Instantiate(content[i], new Vector3(xDistance, (i * DistContent - ((content.Length - 1) * DistContent / 2)), 0), Quaternion.identity);
        prefab.transform.SetParent(transform, false);

        var p = prefab.GetComponent<GUIButton>();
        var x = prefab.transform.parent.transform.parent;
        var pp = x.GetComponent<GUIButton>();

        GUIButton rootObject = null;
        GUIButton last = null;
        if(p.Parent != null) {
            while(true) {
                if(p.Parent == null) {
                    rootObject = last;
                    break;
                }

                last = p.Parent;
            }
        }

        p.Root = rootObject;



        p.Parent = pp;

        yield return null;
    }
}
