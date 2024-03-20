using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class VRHeightOnButton : MonoBehaviour
{
    // Time that the button is set inactive after release
    public float deadTime = 1.0f;

    // Boolean used to lock down button during its set dead time
    public bool _deadTimeActive = false;

    // public unity events that we can use in the editor and tie other functions to
    public UnityEvent onPressed;

    // Checks if the current collider entering is the Button and sets off the onPressed Event.
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "HeightButtonOn" && !_deadTimeActive)
        {
            onPressed.Invoke();
            Debug.Log("The height on button has been pressed");
        }
    }

}
