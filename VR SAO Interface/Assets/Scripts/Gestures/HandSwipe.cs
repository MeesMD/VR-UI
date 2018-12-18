using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class HandSwipe : MonoBehaviour {

    public Transform coreJoints;
    Vector3 startingPos;
    private float endPos = -0.1f;

    private bool menuReady;
    private bool menuRoutine;

    private float menuTimer = 0f;
    private float menuMultiplier = 1f;
    private float menuTimeLimit = 3f;

    void CheckmenuState()
    {
        startingPos = new Vector3(0, coreJoints.position.y, 0);

        if (startingPos.y >= 0 && menuTimer <= menuTimeLimit)
        {
            print("Menu ready for use, extend fingers to unlock.");
            menuReady = true;
            menuRoutine = true;
        }
        else if (startingPos.y <= 0 || menuTimer >= menuTimeLimit)
        {
            print("Menu not able to be activated");
            if (menuTimer >= menuTimeLimit)
            {
                print("Time ran out.");
                menuReady = false;
                menuRoutine = false;
            }
        }
    }

    public void ActivateMenu()
    {
        if (menuRoutine)
        {
            print("Menu activated");
            StartCoroutine("menuEnum");
        }
    }

    public void DeactivateMenu()
    {
        print("Menu deactivated");
        menuTimer = 0;
        menuReady = false;
    }

    void SwipeMenu()
    {
        if (startingPos.y <= endPos)
        {
            print("Swiped");
            menuTimer = 0;
            menuRoutine = false;
            menuReady = false;
        }
    }

    void Update()
    {
        Debug.Log(menuReady);

        //SwipeMenu();
        CheckmenuState();
    }

    IEnumerator menuEnum()
    {
        print("You have 3 seconds to swipe down for unlocking the menu.");

        while (menuReady)
        {
            if (menuTimer <= menuTimeLimit)
            {
                menuTimer += menuMultiplier * Time.deltaTime;
                SwipeMenu();
            }
            yield return null;
        }
        yield return null;
    }
}
