using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour {

    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    State currentState;

	// Use this for initialization
	void Start () {
        currentState = startingState;
        textComponent.text = currentState.GetStateStory();
	}
	
	// Update is called once per frame
	void Update () {
        ManageState();
	}

    private void ManageState()
    {
        var nextStates = currentState.GetNextStates();

        for(int index = 0; index < nextStates.Length; index++)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1 + index))
            {
                currentState = nextStates[index];
            }
        }


 /*       if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentState = nextStates[0];
           
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentState = nextStates[1];
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentState = nextStates[2];
        }
        else if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentState = nextStates[3];
        }
*/
        textComponent.text = currentState.GetStateStory();
    }
}
