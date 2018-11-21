using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class HandSwipe : MonoBehaviour {

    public Transform coreJoints;
    Vector3 startingPos;
    private float endPos = 0.3f;

    private bool menuReady;
    private bool menuRoutine;

    private float menuTimer = 0f;
    private float menuMultiplier = 1f;
    private float menuTimeLimit = 3f;

    void CheckmenuState()
    {
        //startingPos = new Vector3(0, 0, coreJoints.position.z);

        if (startingPos.z <= endPos)
        {
            Debug.Log("Menu ready for use, extend fingers to unlock.");
            menuReady = true;
            //menuRoutine = true;
        }
        else if (startingPos.z >= endPos)
        {
            print("Hand not in range");
        }
    }

    public void ActivateMenu()
    {
        if (menuReady)
        {
            Debug.Log("Menu activated");
            StartCoroutine("menuEnum");
        } 
        menuTimer = 0;
    }

    /*
    public void DeactivateMenu()
    {
        print("Menu deactivated");
        menuTimer = 0;
        menuReady = false;
    }
    */

    void SwipeMenu()
    {
        if (startingPos.z >= endPos)
        {
            Debug.Log("Swiped");
            menuTimer = 0;
            //menuRoutine = false;
            menuReady = false;
            StopCoroutine("menuEnum");
        }

        /*
        if (startingPos.z >= endPos)
        {
            print("Swiped");
        }
        else if (startingPos.z <= endPos)
        {
            print("Can't swipe");
        }
        */
    }

    void Update()
    {
        startingPos = coreJoints.position;
        Debug.Log(menuReady);

        //SwipeMenu();
        CheckmenuState();

        /*
        if (menuTimer >= menuTimeLimit && menuRoutine)
        {
            menuReady = false;
            menuRoutine = false;
        }
        */
    }

    IEnumerator menuEnum()
    {
        menuRoutine = true;

        while (menuReady)
        {
            SwipeMenu();
            if (menuTimer <= menuTimeLimit)
            {
                menuTimer += menuMultiplier * Time.deltaTime;
                Debug.Log("You have 5 minutes to swipe.");
            }
            else if (menuTimer >= menuTimeLimit)
            {
                Debug.Log("Time ran out.");
                menuReady = false;
            }
            yield return null;
        }
        yield return null;
    }
}
