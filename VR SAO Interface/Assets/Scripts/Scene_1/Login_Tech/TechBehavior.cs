using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TechBehavior : MonoBehaviour {

    private SpriteRenderer rend;
    private CanvasGroup canvasGroup;
    [SerializeField]
    private float fadeSpeed = .1f;

    [SerializeField]
    string[] InfoText;
    Text fieldText;

    [SerializeField]
    Vector3[] goToPoint;
    [SerializeField]
    Vector3[] endPoint;
    [SerializeField]
    Vector3[] side;

    private int point;
    private bool pos1;
    private bool pos2;
    public static int isDone;

    [SerializeField]
    private GameObject OK;

    // Use this for initialization
    void Start () {
        canvasGroup = GetComponent<CanvasGroup>();
        fieldText = GetComponentInChildren<Text>();
        fieldText.text = InfoText[point];
    }
    /// <summary>
    /// UI positions are really annoying...
    /// Next time the UI movement will be made in animations.. Because this was hell..
    /// </summary>
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(FadeIn());

        if ((Vector3.Distance(transform.position, goToPoint[point]) <= 5) && !pos1) {
            Debug.Log("Test");
            OK.SetActive(true);
            StopCoroutine("GoToPoint");
            StartCoroutine("GoToEndPoint");
            pos1 = true;
        }

        if ((Vector3.Distance(transform.position, endPoint[point]) <= 375) && !pos2) {
            StopCoroutine("GoToEndPoint");
            isDone++;
            pos2 = true;
        }

        if ((isDone == 5)) {
            Debug.Log("Ending");
            transform.position += side[point] * 600 * Time.deltaTime;
            Destroy(gameObject, 1f);
        }
    }

    IEnumerator FadeIn() {
        while (canvasGroup.alpha < 1) {
            canvasGroup.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }

    public IEnumerator GoToPoint(int getPoint) {
        point = getPoint;
            while ((Vector3.Distance(transform.position, goToPoint[point]) >= 5)) {
                transform.position = Vector3.Lerp(transform.position, goToPoint[point], 3f * Time.deltaTime);
                Debug.Log("Test2");
                yield return null;
            }
    }

    IEnumerator GoToEndPoint() {
        while (Vector3.Distance(transform.position, endPoint[point]) >= 375) {
            Debug.Log("Test3");
            transform.position = Vector3.Lerp(transform.position, endPoint[point], 1f * Time.deltaTime);
            yield return null;
        }
    }
}
